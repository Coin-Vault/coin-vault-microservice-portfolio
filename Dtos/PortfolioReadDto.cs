namespace PortfolioService.Dtos
{
    public class PortfolioReadDto
    {
        public int Id { get; set; }
        
        public string? Name { get; set; }

        public string? Amount { get; set; }
        
        public string? Price { get; set; }
    }
}