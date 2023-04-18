using System.ComponentModel.DataAnnotations;

namespace PortfolioService.Dtos
{
    public class PortfolioCreateDto
    {   
        [Required]
        public int TradeId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public double? Amount { get; set; }
        
        [Required]
        public double? Price { get; set; }
    }
}