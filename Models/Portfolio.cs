using System.ComponentModel.DataAnnotations;

namespace PortfolioService.Models
{
    public class Portfolio
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Amount { get; set; }
        
        [Required]
        public string? Price { get; set; }
    }
}
