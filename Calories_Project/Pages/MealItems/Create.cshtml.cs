using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Calories_Project.Data;
using Calories_Project.Models;

namespace Calories_Project.Pages.MealItems
{
    public class CreateModel : PageModel
    {
        private readonly Calories_Project.Data.Calories_ProjectContext _context;

        public CreateModel(Calories_Project.Data.Calories_ProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["FoodId"] = new SelectList(_context.Food, "FoodId", "FoodId");
        ViewData["MealId"] = new SelectList(_context.Meal, "MealId", "MealId");
            return Page();
        }

        [BindProperty]
        public MealItem MealItem { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.MealItem == null || MealItem == null)
            {
                return Page();
            }

            _context.MealItem.Add(MealItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
