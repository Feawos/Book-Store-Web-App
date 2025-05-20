using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BookStore.Pages
{
    public class PurchaseModel : PageModel
    {
        private readonly BookStoreContext _context;

        public PurchaseModel(BookStoreContext context)
        {
            _context = context;
            Purchase = new PurchaseViewModel
            {
                Title = string.Empty, // Initialize to an empty string
                BookId = 0, // Initialize to a default value
                Quantity = 1 // Initialize to a default value
            };
        }

        [BindProperty]
        public PurchaseViewModel Purchase { get; set; }
      
        public Book? Book { get; set; } = default!;
        public string ErrorMessage { get; set; } = string.Empty;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Book = await _context.Books.FindAsync(id);

            if (Book == null)
            {
                return NotFound();
            }

            Purchase!.Title = Book.Title;
            Purchase.BookId = Book.Id;
            Purchase.Quantity = 1; // Default quantity

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Purchase == null)
            {
                return BadRequest("Purchase details are missing.");
            }

            Book = await _context.Books.FindAsync(Purchase.BookId);

            if (Book == null)
            {
                return NotFound();
            }

            // Validate Quantity
            if (Purchase.Quantity < 1 || Purchase.Quantity > 5)
            {
                ErrorMessage = "You can only purchase between 1 and 5 copies of a book.";
                return Page();
            }

            // Check if enough stock is available
            if (Purchase.Quantity > Book.Stock)
            {
                ErrorMessage = "Not enough stock available.";
                return Page();
            }

            // Calculate total price
            Purchase.TotalPrice = Purchase.Quantity * Book.Price;

            // Deduct the quantity from stock
            Book.Stock -= Purchase.Quantity;

            _context.Attach(Book).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            // Redirect to Order Summary page and pass relevant data
            return RedirectToPage("OrderSummary", new
            {
                bookTitle = Purchase.Title,
                quantity = Purchase.Quantity,
                totalPrice = Purchase.TotalPrice
            });
        }
    }
}

