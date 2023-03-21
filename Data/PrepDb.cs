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
                        Name = "TEST", 
                        Amount = "TEST", 
                        Price = "TEST"
                    },
                    new Portfolio()
                    {
                        Name = "TEST", 
                        Amount = "TEST", 
                        Price = "TEST"
                    },
                    new Portfolio() 
                    {
                        Name = "TEST", 
                        Amount = "TEST", 
                        Price = "TEST"
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