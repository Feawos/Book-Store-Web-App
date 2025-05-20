

namespace BookStore.Models
{
    public class CustomerBookViewModel
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Image { get; set; }
        public required string ISBN { get; set; }
        public required string Author { get; set; }
        public required string Category { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int QuantityToBuy { get; set; }
    }
}
