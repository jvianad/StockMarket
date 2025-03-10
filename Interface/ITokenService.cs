using StockMarket.Models;

namespace StockMarket.Interface
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
