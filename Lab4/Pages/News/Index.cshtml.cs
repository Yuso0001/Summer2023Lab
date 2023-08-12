using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab4.Data;
using Lab4.Models;

namespace Lab4.Pages.News
{
    public class IndexModel : PageModel
    {
        private readonly Lab4.Data.SportsDbContext _context;

        public IndexModel(Lab4.Data.SportsDbContext context)
        {
            _context = context;
        }

        public IList<Models.News> News { get;set; } = default!;

        [BindProperty]
        public string SportsId { get; set; }
        public async Task OnGetAsync(string id)
        {
            if (_context.News != null)
            {
                SportsId = id;
                News = await _context.News.ToListAsync();
            }
        }
    }
}
