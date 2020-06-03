namespace RecipesContextLibrary.Context
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using RecipesContextLibrary.Models;

    public partial class RecipesContext : DbContext
    {
        public RecipesContext()
            : base("name=RecipesContext")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<IngredientsQuantity> IngredientsQuantities { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Recipes)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ingredient>()
                .HasMany(e => e.IngredientsQuantities)
                .WithRequired(e => e.Ingredient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IngredientsQuantity>()
                .Property(e => e.Amount)
                .HasPrecision(7, 2);

            modelBuilder.Entity<Recipe>()
                .Property(e => e.Method)
                .IsUnicode(false);

            modelBuilder.Entity<Recipe>()
                .HasMany(e => e.IngredientsQuantities)
                .WithRequired(e => e.Recipe)
                .WillCascadeOnDelete(false);
        }
    }
}
