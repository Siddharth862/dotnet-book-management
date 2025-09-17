using System.ComponentModel.DataAnnotations.Schema; // Add this using statement

namespace Dal_Book
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18, 4)")]
        public decimal Price { get; set; }
    }
}