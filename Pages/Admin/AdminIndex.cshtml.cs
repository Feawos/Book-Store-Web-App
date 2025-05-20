using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookStore.Data;
using BookStore.Models;

namespace BookStore.Pages.Admin
{
    public class AdminIndexModel : PageModel
    {
        private readonly BookStore.Data.BookStoreContext _context;

        public AdminIndexModel(BookStore.Data.BookStoreContext context)
        {
            _context = context;
        }

        public IList<Book> Books { get; set; } = new List<Book>();

        public async Task OnGetAsync()
        {
            if (_context.Books != null)
            {
                Books = await _context.Books.ToListAsync();
            }
        }
    }
}
