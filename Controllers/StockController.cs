using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockMarket.Data;
using StockMarket.Dtos.Stock;
using StockMarket.Mappers;

namespace StockMarket.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly AplicationDBContext _context;

        public StockController(AplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            var stocks = await _context.Stocks.ToListAsync();
            var stockDto = stocks.Select(s => s.ToStockDto());
            return Ok(stockDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getById([FromRoute] int id)
        {
            var stock = await _context.Stocks.FindAsync(id);
            if(stock == null)
            {
                return NotFound();
            }

            return Ok(stock.ToStockDto());
        }


        [HttpPost]
        public async Task<IActionResult> createStock([FromBody] CreateStockRequestDto stockDto)
        {
            var stockmodel = stockDto.ToStockFromCreateDto();
            await _context.Stocks.AddAsync(stockmodel);
            await _context.SaveChangesAsync();
            return Ok();
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> updateStock([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
        {
            var stockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
            if(stockModel == null)
            {
                return NotFound();
            }

            stockModel.Symbol = updateDto.Symbol;
            stockModel.CompanyName = updateDto.CompanyName;
            stockModel.Purchase = updateDto.Purchase;
            stockModel.LastDiv = updateDto.LastDiv;
            stockModel.Industry = updateDto.Industry;
            stockModel.MarketCap = updateDto.MarketCap;

            await _context.SaveChangesAsync();
            return Ok(stockModel.ToStockDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> deleteStock([FromRoute] int id)
        {
            var stockToDelete = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
            if (stockToDelete == null)
            {
                return NotFound();
            }

            _context.Stocks.Remove(stockToDelete);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
