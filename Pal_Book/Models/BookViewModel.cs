using System.ComponentModel.DataAnnotations;

namespace Pal_Book.Models
{
    // This class must contain all the properties you want to use in your views.
    public class BookViewModel
    {
        public int BookId { get; set; }

        [Required(ErrorMessage = "Please enter a title.")]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter an author.")]
        [StringLength(100)]
        public string Author { get; set; } = string.Empty;

        public string Genre { get; set; } = string.Empty;

        [Required]
        [Range(0.01, 10000.00, ErrorMessage = "Price must be between 0.01 and 10,000.00")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}