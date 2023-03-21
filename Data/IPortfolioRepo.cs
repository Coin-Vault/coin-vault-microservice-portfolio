using PortfolioService.Models;

namespace PortfolioService.Data
{
    public interface IPortfolioRepo
    {
        bool SaveChanges();
        IEnumerable<Portfolio> GetAllPortfolios();
        Portfolio GetPortfolioById(int id);
        void CreatePortfolio(Portfolio portfolio);
    }
}