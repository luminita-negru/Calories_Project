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
    public class DetailsModel : PageModel
    {
        private readonly Calories_Project.Data.Calories_ProjectContext _context;

        public DetailsModel(Calories_Project.Data.Calories_ProjectContext context)
        {
            _context = context;
        }

      public MealItem MealItem { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.MealItem == null)
            {
                return NotFound();
            }

            var mealitem = await _context.MealItem.FirstOrDefaultAsync(m => m.MealItemId == id);
            if (mealitem == null)
            {
                return NotFound();
            }
            else 
            {
                MealItem = mealitem;
            }
            return Page();
        }
    }
}
