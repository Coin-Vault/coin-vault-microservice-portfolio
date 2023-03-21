using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PortfolioService.Data;
using PortfolioService.Dtos;
using PortfolioService.Models;

namespace PortfolioService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioRepo _repository;
        private readonly IMapper _mapper;

        public PortfolioController(IPortfolioRepo repository, IMapper mapper)
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

        [HttpGet("{id}", Name = "GetPortfolioById")]
        public ActionResult<PortfolioReadDto> GetPortfolioById(int id)
        {
            var trade = _repository.GetPortfolioById(id);

            if (trade != null) {
                return Ok(_mapper.Map<PortfolioReadDto>(trade));
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

            return CreatedAtRoute(nameof(GetPortfolioById), new { Id = portfolioReadDto.Id}, portfolioReadDto);
        }
    }
}