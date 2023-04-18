using PortfolioService.Models;

namespace PortfolioService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope()) 
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if(!context.Portfolios.Any()) 
            {
                Console.WriteLine("Seeding Data..."); 

                context.Portfolios.AddRange(
                    new Portfolio() 
                    {
                        TradeId = 100, 
                        UserId = 11111, 
                        Name = "BITCOIN",
                        Amount = 5.5,
                        Price = 25555.5
                    },
                    new Portfolio()
                    {
                        TradeId = 101, 
                        UserId = 22222, 
                        Name = "BITCOIN",
                        Amount = 5.5,
                        Price = 25555.5
                    },
                    new Portfolio() 
                    {
                    	TradeId = 101, 
                        UserId = 33333, 
                        Name = "BITCOIN",
                        Amount = 5.5,
                        Price = 25555.5
                    }
                );

                context.SaveChanges();
            }
            else 
            {
                Console.WriteLine("Already Data (Portfolios) In the Database..."); 
            }
        }
    }
}