using PortfolioService.Models;

namespace PortfolioService.Data
{
    public class PortfolioRepo : IPortfolioRepo
    {
        private readonly AppDbContext _context;

        public PortfolioRepo(AppDbContext context)
        {
            _context = context;       
        }

        public void CreatePortfolio(Portfolio portfolio)
        {
            if(portfolio == null)
            {
                throw new ArgumentNullException(nameof(portfolio));
            }

            _context.Portfolios.Add(portfolio);
        }

        public IEnumerable<Portfolio> GetAllPortfolios()
        {
            return _context.Portfolios.ToList();
        }

        public IEnumerable<Portfolio> GetPortfolioByUserId(int userId)
        {
            return _context.Portfolios.Where(t => t.UserId == userId);
        }

        public bool SaveChanges()
        {
            return(_context.SaveChanges() >= 0);
        }
    }
}