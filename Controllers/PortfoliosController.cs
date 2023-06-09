using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioService.Data;
using PortfolioService.Dtos;
using PortfolioService.Models;

namespace PortfolioService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfoliosController : ControllerBase
    {
        private readonly IPortfolioRepo _repository;
        private readonly IMapper _mapper;

        public PortfoliosController(IPortfolioRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("{userId}", Name = "GetPortfolioByUserId")]
        public ActionResult<IEnumerable<PortfolioReadDto>> GetPortfolioByUserId(string userId)
        {
            Console.WriteLine($"Getting Portfolios For User: {userId}");

            var trades = _repository.GetPortfolioByUserId(userId);

            if (trades != null)
            {
                return Ok(_mapper.Map<IEnumerable<PortfolioReadDto>>(trades));
            }

            return NotFound();
        }

        [Authorize]
        [HttpPost]
        public ActionResult<PortfolioReadDto> CreatePortfolio(PortfolioCreateDto portfolioCreateDto)
        {
            var portfolioModel = _mapper.Map<Portfolio>(portfolioCreateDto);
            _repository.CreatePortfolio(portfolioModel);
            _repository.SaveChanges();

            var portfolioReadDto = _mapper.Map<PortfolioReadDto>(portfolioModel);

            return CreatedAtRoute(nameof(GetPortfolioByUserId), new { Id = portfolioReadDto.Id }, portfolioReadDto);
        }
    }
}