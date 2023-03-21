using Microsoft.EntityFrameworkCore;
using PortfolioService.Models;

namespace PortfolioService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) 
        {
            
        }

        public DbSet<Portfolio>? Portfolios { get; set; }
    }
}