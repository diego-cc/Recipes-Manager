using RecipesData.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace RecipesData.Context
{
    public interface IRecipesContext : IDisposable
    {
        DbSet<Ingredient> Ingredients { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<IngredientQuantity> IngredientQuantities { get; set; }
        DbSet<Recipe> Recipes { get; set; }
    }
}
