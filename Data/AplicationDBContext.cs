using Microsoft.EntityFrameworkCore;
using StockMarket.Models;

namespace StockMarket.Data
{
    public class AplicationDBContext: DbContext
    {
        public AplicationDBContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
            
        }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
