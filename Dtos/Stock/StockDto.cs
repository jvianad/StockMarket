﻿using StockMarket.Dtos.Comment;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockMarket.Dtos.Stock
{
    public class StockDto
    {
        public int Id { get; set; }
        public String Symbol { get; set; } = string.Empty;
        public String CompanyName { get; set; } = string.Empty;
        public decimal Purchase { get; set; }
        public decimal LastDiv { get; set; }
        public string Industry { get; set; } = string.Empty;
        public long MarketCap { get; set; }
        public List<CommentDto> Comments { get; set; }
    }
}
