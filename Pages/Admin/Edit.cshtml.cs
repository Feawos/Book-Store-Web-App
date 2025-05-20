using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStore.Data;
using BookStore.Models;

namespace BookStore.Pages.Admin
{
    public class EditModel : PageModel
    {
        private readonly BookStoreContext _context;

        public EditModel(BookStoreContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        [BindProperty]
        public IFormFile? ImageFile { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            Book = book;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var bookToUpdate = await _context.Books.FindAsync(Book.Id);
            if (bookToUpdate == null)
            {
                return NotFound();
            }

            if (ImageFile != null)
            {
                var fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName())
                                + Path.GetExtension(ImageFile.FileName);

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                Directory.CreateDirectory(Path.GetDirectoryName(filePath) ?? throw new InvalidOperationException("Image directory path is null."));

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(fileStream);
                }

                Book.ImagePath = $"/images/{fileName}";
            }
            // Update other properties
            if (await TryUpdateModelAsync(
                bookToUpdate,
                "Book",
                b => b.Title, b => b.ISBN, b => b.Author, b => b.Category, b => b.Price, b => b.Stock))
            {
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(Book.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToPage("./AdminIndex");
            }

            return Page();
        }

 

        private bool BookExists(int id)
        {
            return (_context.Books?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
