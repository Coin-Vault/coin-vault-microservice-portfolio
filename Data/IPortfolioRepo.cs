using PortfolioService.Models;

namespace PortfolioService.Data
{
    public interface IPortfolioRepo
    {
        bool SaveChanges();
        IEnumerable<Portfolio> GetAllPortfolios();
        IEnumerable<Portfolio> GetPortfolioByUserId(int userId);
        void CreatePortfolio(Portfolio portfolio);
    }
}