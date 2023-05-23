namespace PortfolioService.Dtos
{
    public class PortfolioReadDto
    {
        public int Id { get; set; }

        public int TradeId { get; set; }

        public string? UserId { get; set; }

        public string? Name { get; set; }

        public double? Amount { get; set; }
        
        public double? Price { get; set; }
    }
}