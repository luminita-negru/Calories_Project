using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Calories_Project.Models;

namespace Calories_Project.Data
{
    public class Calories_ProjectContext : DbContext
    {
        public Calories_ProjectContext (DbContextOptions<Calories_ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Calories_Project.Models.Category> Category { get; set; } = default!;

        public DbSet<Calories_Project.Models.Food>? Food { get; set; }

        public DbSet<Calories_Project.Models.Meal>? Meal { get; set; }

        public DbSet<Calories_Project.Models.MealItem>? MealItem { get; set; }

        public DbSet<Calories_Project.Models.Member>? Member { get; set; }
    }
}
