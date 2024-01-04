﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Calories_Project.Data;
using Calories_Project.Models;

namespace Calories_Project.Pages.Meals
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
            return Page();
        }

        [BindProperty]
        public Meal Meal { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Meal == null || Meal == null)
            {
                return Page();
            }

            _context.Meal.Add(Meal);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
