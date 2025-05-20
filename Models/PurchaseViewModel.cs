namespace BookStore.Models
{
    public class PurchaseViewModel
    {
        public int BookId { get; set; }
        public required string Title { get; set; } = string.Empty;
        public int Quantity { get; set; } = 1;  // Number of copies to purchase
        public decimal TotalPrice { get; set; }
    }
}
