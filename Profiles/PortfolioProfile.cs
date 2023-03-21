using AutoMapper;
using PortfolioService.Dtos;
using PortfolioService.Models;

namespace PortfolioService.Profiles
{
    public class PortfolioProfile : Profile
    {
        public PortfolioProfile()
        {
            CreateMap<Portfolio, PortfolioReadDto>();
            CreateMap<PortfolioCreateDto, Portfolio>();
        }
    }
}
