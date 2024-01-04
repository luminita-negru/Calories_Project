using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Calories_Project.Data;
using Calories_Project.Models;

namespace Calories_Project.Pages.MealItems
{
    public class IndexModel : PageModel
    {
        private readonly Calories_Project.Data.Calories_ProjectContext _context;

        public IndexModel(Calories_Project.Data.Calories_ProjectContext context)
        {
            _context = context;
        }

        public IList<MealItem> MealItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.MealItem != null)
            {
                MealItem = await _context.MealItem
                .Include(m => m.Food)
                .Include(m => m.Meal).ToListAsync();
            }
        }
    }
}
