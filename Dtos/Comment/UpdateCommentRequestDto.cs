using System.ComponentModel.DataAnnotations;

namespace StockMarket.Dtos.Comment
{
    public class UpdateCommentRequestDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "title must be 5 chars")]
        [MaxLength(280, ErrorMessage = "title cant be over 280 chars")]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MinLength(5, ErrorMessage = "content must be 5 chars")]
        [MaxLength(280, ErrorMessage = "content cant be over 280 chars")]
        public string Content { get; set; } = string.Empty;
    }
}
