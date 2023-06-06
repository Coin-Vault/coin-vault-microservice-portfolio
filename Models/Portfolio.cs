using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace PortfolioService.Models
{
    public class Portfolio
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int TradeId { get; set; }

        [Required]
        public string? UserId { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public double? Amount { get; set; }

        [Required]
        public double? Price { get; set; }
    }
}
