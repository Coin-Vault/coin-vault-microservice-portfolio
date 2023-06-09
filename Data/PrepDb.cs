using Microsoft.EntityFrameworkCore;
using PortfolioService.Models;

namespace PortfolioService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProd)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProd);
            }
        }

        private static void SeedData(AppDbContext context, bool isProd)
        {
            if (isProd)
            {
                try
                {
                    Console.WriteLine("Attampting to apply migrations");
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Could not run migrations: {ex.Message}");
                }
            }

            if (!context.Portfolios.Any())
            {
                Console.WriteLine("Seeding Data...");

                context.Portfolios.AddRange(
                    new Portfolio()
                    {
                        TradeId = 1,
                        UserId = "google-oauth2|107328215575499709402",
                        Name = "BITCOIN",
                        Amount = 5,
                        Price = 25555.5
                    },
                    new Portfolio()
                    {
                        TradeId = 2,
                        UserId = "google-oauth2|107328215575499709402",
                        Name = "BITCOIN",
                        Amount = 10,
                        Price = 25555.5
                    },
                    new Portfolio()
                    {
                        TradeId = 3,
                        UserId = "google-oauth2|107328215575499709402",
                        Name = "BITCOIN",
                        Amount = 15.5,
                        Price = 25555.5
                    }
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Already Data (Portfolios) In the Database...new");
            }
        }
    }
}