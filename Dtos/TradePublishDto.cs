namespace PortfolioService.Dtos
{
    public class TradePublishDto
    {   
        public int Id { get; set; }
        
        public string? Name { get; set; }

        public double? Amount { get; set; }

        public double? Price { get; set; }

        public string? Event { get; set; }
    }
}