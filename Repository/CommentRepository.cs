using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using StockMarket.Data;
using StockMarket.Interface;
using StockMarket.Models;

namespace StockMarket.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AplicationDBContext _context;
        public CommentRepository(AplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Comment> CreateAsync(Comment commentModel)
        {
            await _context.Comments.AddAsync(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
            var commentModel = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);

            if(commentModel == null)
            {
                return null;
            }

            _context.Comments.Remove(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;

        }

        public async Task<List<Comment>> getAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> getByIdAsync(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task<Comment?> UpdateAsync(int id, Comment commnetModel)
        {
            var existingComment = await _context.Comments.FindAsync(id);

            if(existingComment == null)
            {
                return null;
            }

            existingComment.Title = commnetModel.Title;
            existingComment.Content = commnetModel.Content;

            await _context.SaveChangesAsync();

            return existingComment;
        }
    }
}
