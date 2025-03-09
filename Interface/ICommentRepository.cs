using StockMarket.Models;

namespace StockMarket.Interface
{
    public interface ICommentRepository
    {
        Task<List<Comment>> getAllAsync();
        Task<Comment?> getByIdAsync(int id);
        Task<Comment> CreateAsync(Comment commentModel);
        Task<Comment?> UpdateAsync(int id, Comment commnetModel);
        Task<Comment?> DeleteAsync(int id);
    }
}
