using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lab4.Data;
using Lab4.Models;
using Azure.Storage.Blobs;

namespace Lab4.Pages.News
{
    public class CreateModel : PageModel
    {
        private readonly Lab4.Data.SportsDbContext _context; 
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string newscontainer = "news";

        public CreateModel(Lab4.Data.SportsDbContext context, BlobServiceClient blobServiceClient) {
            _context = context;
            _blobServiceClient = blobServiceClient;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.News News { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.News.Add(News);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
