using System.ComponentModel.DataAnnotations;

namespace StockMarket.Dtos.Stock
{
    public class UpdateStockRequestDto
    {
        [Required]
        [MaxLength(10, ErrorMessage = "symbol cant be over 10 chars")]
        public String Symbol { get; set; } = string.Empty;
        [Required]
        [MaxLength(10, ErrorMessage = "c name cant be over 10 chars")]
        public String CompanyName { get; set; } = string.Empty;
        [Required]
        [Range(1, 100000000)]
        public decimal Purchase { get; set; }
        [Required]
        [Range(0.001, 100)]
        public decimal LastDiv { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage = "industry cant be over 10 chars")]
        public string Industry { get; set; } = string.Empty;
        [Range(1, 100000)]
        public long MarketCap { get; set; }
    }
}
