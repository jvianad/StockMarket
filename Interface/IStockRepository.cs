namespace StockMarket.Interface
{
    public interface IStockRepository
    {
        Task<bool> StockExist(int id);
    }
}
