using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab4.Data;
using Lab4.Models;
using Azure.Storage.Blobs;

namespace Lab4.Pages.News
{
    public class DeleteModel : PageModel
    {
        private readonly Lab4.Data.SportsDbContext _context;
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string newscontainer = "news";
        public DeleteModel(Lab4.Data.SportsDbContext context, BlobServiceClient blobServiceClient) {
            _context = context;
            _blobServiceClient = blobServiceClient;
        }

        [BindProperty]
      public Models.News News { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.News == null)
            {
                return NotFound();
            }

            var news = await _context.News.FirstOrDefaultAsync(m => m.Id == id);

            if (news == null)
            {
                return NotFound();
            }
            else 
            {
                News = news;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.News == null)
            {
                return NotFound();
            }
            var news = await _context.News.FindAsync(id);

            if (news != null)
            {
                News = news;
                _context.News.Remove(News);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
