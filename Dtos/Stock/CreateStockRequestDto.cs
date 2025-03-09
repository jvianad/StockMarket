﻿using System.ComponentModel.DataAnnotations.Schema;

namespace StockMarket.Dtos.Stock
{
    public class CreateStockRequestDto
    {
        public String Symbol { get; set; } = string.Empty;
        public String CompanyName { get; set; } = string.Empty;
        public decimal Purchase { get; set; }
        public decimal LastDiv { get; set; }
        public string Industry { get; set; } = string.Empty;
        public long MarketCap { get; set; }
    }
}
