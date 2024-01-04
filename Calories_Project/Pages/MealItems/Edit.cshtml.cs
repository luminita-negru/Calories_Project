using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Calories_Project.Data;
using Calories_Project.Models;

namespace Calories_Project.Pages.MealItems
{
    public class EditModel : PageModel
    {
        private readonly Calories_Project.Data.Calories_ProjectContext _context;

        public EditModel(Calories_Project.Data.Calories_ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MealItem MealItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.MealItem == null)
            {
                return NotFound();
            }

            var mealitem =  await _context.MealItem.FirstOrDefaultAsync(m => m.MealItemId == id);
            if (mealitem == null)
            {
                return NotFound();
            }
            MealItem = mealitem;
           ViewData["FoodId"] = new SelectList(_context.Food, "FoodId", "FoodId");
           ViewData["MealId"] = new SelectList(_context.Meal, "MealId", "MealId");
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

            _context.Attach(MealItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MealItemExists(MealItem.MealItemId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MealItemExists(int id)
        {
          return (_context.MealItem?.Any(e => e.MealItemId == id)).GetValueOrDefault();
        }
    }
}
