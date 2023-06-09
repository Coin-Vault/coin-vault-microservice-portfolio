using PortfolioService.Models;

namespace PortfolioService.Data
{
    public interface IPortfolioRepo
    {
        bool SaveChanges();
        IEnumerable<Portfolio> GetAllPortfolios();
        IEnumerable<Portfolio> GetPortfolioByUserId(string userId);
        void CreatePortfolio(Portfolio portfolio);
    }
}