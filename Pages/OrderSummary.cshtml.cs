using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.Pages
{
    public class OrderSummaryModel : PageModel
    {
        public string BookTitle { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

        public void OnGet(string title, int quantity, decimal totalPrice)
        {
            BookTitle = title;
            Quantity = quantity;
            TotalPrice = totalPrice;
        }
    }
}
