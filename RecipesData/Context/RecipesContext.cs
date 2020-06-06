using RecipesData.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesData.Context
{
    public class RecipesContext : DbContext, IRecipesContext
    {
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<IngredientQuantity> IngredientQuantities { get; set; }
        public DbSet<Recipe> Recipes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        { 
        }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified);

            foreach (var entry in modifiedEntries)
            {
                ((ModelBase)entry.Entity).UpdatedAt = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("W. Australia Standard Time"));
            }

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync()
        {
            var modifiedEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified);

            foreach (var entry in modifiedEntries)
            {
                ((ModelBase)entry.Entity).UpdatedAt = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("W. Australia Standard Time"));
            }

            return base.SaveChangesAsync();
        }
    }
}
