using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public required string Title { get; set; }

        public string? ImagePath { get; set; }

        [Required]
        public required string ISBN { get; set; }

        [Required]
        public required string Author { get; set; }

        [Required]
        public required string Category { get; set; }

        [Required]
        [Range(0.01, 10000.00)]
        public decimal Price { get; set; }

        [Required]
        [Range(0, 1000)]
        public int Stock { get; set; }
    }
}
