using RecipesData.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesData.Context
{
    /// <summary>
    /// Context used by the main application (<see cref="RecipesManager"/>)
    /// </summary>
    public class RecipesContext : DbContext, IRecipesContext
    {
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<IngredientQuantity> IngredientQuantities { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }

        public RecipesContext() { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        { 
        }

        /// <summary>
        /// Set timestamps before saving entries
        /// <para>Note: currently not working for CreatedAt</para>
        /// <para>Possible bug/quirk in EF6 that is not present in EF Core?</para>
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
