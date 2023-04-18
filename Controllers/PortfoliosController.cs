using AutoMapper;
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

        [HttpGet]
        public ActionResult<IEnumerable<PortfolioReadDto>> GetPortfolios()
        {
            Console.WriteLine("Getting Portfolios");

            var trades = _repository.GetAllPortfolios();

            return Ok(_mapper.Map<IEnumerable<PortfolioReadDto>>(trades));
        }

        [HttpGet("{userId}", Name = "GetPortfolioByUserId")]
        public ActionResult<IEnumerable<PortfolioReadDto>> GetPortfolioByUserId(int userId)
        {
            Console.WriteLine($"Getting Portfolios For User: {userId}");

            var trades = _repository.GetPortfolioByUserId(userId);

            if (trades != null) {
                return Ok(_mapper.Map<IEnumerable<PortfolioReadDto>>(trades));
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<PortfolioReadDto> CreatePortfolio(PortfolioCreateDto portfolioCreateDto)
        {
            var portfolioModel = _mapper.Map<Portfolio>(portfolioCreateDto);
            _repository.CreatePortfolio(portfolioModel);
            _repository.SaveChanges();

            var portfolioReadDto = _mapper.Map<PortfolioReadDto>(portfolioModel);

            return CreatedAtRoute(nameof(GetPortfolioByUserId), new { Id = portfolioReadDto.Id}, portfolioReadDto);
        }
    }
}