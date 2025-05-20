using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using BookStore.Data;
using BookStore.Models;

namespace BookStore.Pages.Admin
{
    public class CreateModel : PageModel
    {
        private readonly BookStore.Data.BookStoreContext _context;
        private readonly ILogger<CreateModel> _logger;

        public CreateModel(BookStore.Data.BookStoreContext context, ILogger<CreateModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        [BindProperty]
        public IFormFile? ImageFile { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            // Ensure the model is valid before attempting to save
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Handle the image upload if present
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

                // Save the image path to the book
                Book.ImagePath = $"/images/{fileName}";
            }
            try
            {
                _context.Books.Add(Book);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (you could log it to a file, the console, or any other logging service)
                Console.WriteLine($"An error occurred while saving the book: {ex.Message}");
                throw; // Re-throw the exception to see the details
            }

            // Redirect to index page after creation
            return RedirectToPage("./AdminIndex");
        }
    }
}
