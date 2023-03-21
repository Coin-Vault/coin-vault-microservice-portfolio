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

        public Portfolio GetPortfolioById(int id)
        {
            return _context.Portfolios.FirstOrDefault(t => t.Id == id);
        }

        public bool SaveChanges()
        {
            return(_context.SaveChanges() >= 0);
        }
    }
}