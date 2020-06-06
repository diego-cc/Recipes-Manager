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

        /// <summary>
        /// Set timestamps before saving entries
        /// Note: currently not working for CreatedAt
        /// Possible bug/quirk in EF6 that is not present in EF Core?
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            //var addedEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Added);

            //foreach (var entry in addedEntries)
            //{
            //    entry.Property("CreatedAt").CurrentValue = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("W. Australia Standard Time"));
            //}

            var modifiedEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified);

            TimeZoneInfo timeZoneInfo;

            try
            {
                timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("W. Australia Standard Time");

                foreach (var entry in modifiedEntries)
                {
                    ((ModelBase)entry.Entity).UpdatedAt = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneInfo);
                }
            }
            catch (Exception)
            {
                foreach (var entry in modifiedEntries)
                {
                    ((ModelBase)entry.Entity).UpdatedAt = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync()
        {
            var modifiedEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified);

            TimeZoneInfo timeZoneInfo;

            try
            {
                timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("W. Australia Standard Time");

                foreach (var entry in modifiedEntries)
                {
                    ((ModelBase)entry.Entity).UpdatedAt = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneInfo);
                }
            }
            catch (Exception)
            {
                foreach (var entry in modifiedEntries)
                {
                    ((ModelBase)entry.Entity).UpdatedAt = DateTime.Now;
                }
            }
            return base.SaveChangesAsync();
        }
    }
}
