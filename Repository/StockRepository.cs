using Microsoft.EntityFrameworkCore;
using StockMarket.Data;
using StockMarket.Interface;

namespace StockMarket.Repository
{
    public class StockRepository : IStockRepository
    {

        private readonly AplicationDBContext _context;

        public StockRepository(AplicationDBContext context)
        {
            _context = context;
        }

        public Task<bool> StockExist(int id)
        {
            return _context.Stocks.AnyAsync(s => s.Id == id);
        }
    }
}
