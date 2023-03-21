using System.ComponentModel.DataAnnotations;

namespace PortfolioService.Dtos
{
    public class PortfolioCreateDto
    {   
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Amount { get; set; }
        
        [Required]
        public string? Price { get; set; }
    }
}