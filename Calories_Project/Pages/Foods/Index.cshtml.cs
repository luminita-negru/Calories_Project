using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Calories_Project.Data;
using Calories_Project.Models;

namespace Calories_Project.Pages.Foods
{
    public class IndexModel : PageModel
    {
        private readonly Calories_Project.Data.Calories_ProjectContext _context;

        public IndexModel(Calories_Project.Data.Calories_ProjectContext context)
        {
            _context = context;
        }

        public IList<Food> Food { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Food != null)
            {
                Food = await _context.Food
                .Include(f => f.Category).ToListAsync();
            }
        }
    }
}
