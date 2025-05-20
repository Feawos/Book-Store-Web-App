using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Pages
{
    public class IndexModel : PageModel
    {
        private readonly BookStore.Data.BookStoreContext _context;

        public IndexModel(BookStore.Data.BookStoreContext context)
        {
            _context = context;
        }

        public required IList<CustomerBookViewModel> Books { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public int QuantityToBuy { get; private set; }

        public async Task OnGetAsync()
        {
            ViewData["SearchString"] = SearchString; // Pass SearchString to ViewData

            var booksQuery = from b in _context.Books
                             select new CustomerBookViewModel
                             {
                                 Id = b.Id,
                                 Title = b.Title,
                                 Image = b.ImagePath,
                                 ISBN = b.ISBN,
                                 Author = b.Author,
                                 Category = b.Category,
                                 Price = b.Price,
                                 Stock = b.Stock
                             };

            if (!string.IsNullOrEmpty(SearchString))
            {
                booksQuery = booksQuery.Where(b =>
                    b.Category.Contains(SearchString) ||
                    b.Title.Contains(SearchString) ||
                    b.ISBN.Contains(SearchString));
            }

            Books = await booksQuery.ToListAsync();
        }

        public async Task<IActionResult> OnPostBuyAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null || book.Stock <= 0 || book.Stock < QuantityToBuy || QuantityToBuy < 1 || QuantityToBuy > 5)
            {
                return Page();
            }

            book.Stock -= QuantityToBuy;
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}
