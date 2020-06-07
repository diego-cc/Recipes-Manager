using RecipesData.Context;
using RecipesData.Models;
using System;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;

namespace RecipesData.Setup
{
    /// <summary>
    /// Main implementation of the IDbManager interface
    /// </summary>
    public class DbManager : IDbManager
    {
        public IRecipesContext RecipesContext
        {
            get => _recipesContext;
            set
            {
                _recipesContext = value;
            }
        }

        private IRecipesContext _recipesContext;

        /// <summary>
        /// Constructor for testing purposes
        /// </summary>
        /// <param name="recipesContext"></param>
        public DbManager(IRecipesContext recipesContext)
        {
            RecipesContext = recipesContext;
        }

        public DbManager() { }

        public bool AddItem(object item)
        {
            if (item == null) return false;

            if (_recipesContext is RecipesContext)
            {
                using (var ctx = new RecipesContext())
                {
                    try
                    {
                        switch (item)
                        {
                            case Category c:
                                ctx.Entry(c).State = EntityState.Added;
                                break;

                            case Ingredient i:
                                ctx.Entry(i).State = EntityState.Added;
                                break;

                            case Recipe r:
                                ctx.Entry(r).State = EntityState.Added;
                                break;

                            case IngredientQuantity iq:
                                ctx.Entry(iq).State = EntityState.Added;
                                break;

                            default:
                                Console.WriteLine("Could not add new item: invalid object type");
                                return false;
                        }
                        ctx.SaveChanges();
                        return true;
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        Console.WriteLine("Could not add new item: concurrency issues");
                        Console.WriteLine(ex.Message);

                        return false;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Could not add new item: SQL errors");
                        Console.WriteLine(ex.Message);

                        return false;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Could not add new item");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("\n");
                        Console.WriteLine(ex.InnerException);
                        Console.WriteLine("\n");
                        Console.WriteLine(ex.StackTrace);

                        return false;
                    }
                }
            }
            else
            {
                using (var ctx = new RecipesTestContext())
                {
                    try
                    {
                        switch (item)
                        {
                            case Category c:
                                ctx.Entry(c).State = EntityState.Added;
                                break;

                            case Ingredient i:
                                ctx.Entry(i).State = EntityState.Added;
                                break;

                            case Recipe r:
                                ctx.Entry(r).State = EntityState.Added;
                                break;

                            case IngredientQuantity iq:
                                ctx.Entry(iq).State = EntityState.Added;
                                break;

                            default:
                                Console.WriteLine("Could not add new item: invalid object type");
                                return false;
                        }
                        ctx.SaveChanges();
                        return true;
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        Console.WriteLine("Could not add new item: concurrency issues");
                        Console.WriteLine(ex.Message);

                        return false;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Could not add new item: SQL errors");
                        Console.WriteLine(ex.Message);

                        return false;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Could not add new item");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("\n");
                        Console.WriteLine(ex.InnerException);
                        Console.WriteLine("\n");
                        Console.WriteLine(ex.StackTrace);

                        return false;
                    }
                }
            }
        }

        public object[] BrowseItems(Type entityType)
        {
            if (_recipesContext is RecipesContext)
            {
                using (var ctx = new RecipesContext())
                {
                    try
                    {
                        switch (entityType.Name)
                        {
                            case "Category":
                                return ctx.Categories.ToArray();

                            case "Ingredient":
                                return ctx.Ingredients.ToArray();

                            case "Recipe":
                                return ctx.Recipes.Include(m => m.Category).ToArray();

                            case "IngredientQuantity":
                                return ctx
                                            .IngredientQuantities
                                            .Include(m => m.Ingredient)
                                            .Include(m => m.Recipe)
                                            .ToArray();

                            default:
                                Console.WriteLine("Could not browse items: invalid object type");
                                return new object[] { };
                        }
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        Console.WriteLine("Could not browse items: concurrency issues");
                        Console.WriteLine(ex.Message);

                        return new object[] { };
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Could not browse items: SQL errors");
                        Console.WriteLine(ex.Message);

                        return new object[] { };
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Could not browse items");
                        Console.WriteLine(ex.Message);

                        return new object[] { };
                    }
                }
            }
            else
            {
                using (var ctx = new RecipesTestContext())
                {
                    try
                    {
                        switch (entityType.Name)
                        {
                            case "Category":
                                return ctx.Categories.ToArray();

                            case "Ingredient":
                                return ctx.Ingredients.ToArray();

                            case "Recipe":
                                return ctx.Recipes.Include(m => m.Category).ToArray();

                            case "IngredientQuantity":
                                return ctx
                                            .IngredientQuantities
                                            .Include(m => m.Ingredient)
                                            .Include(m => m.Recipe)
                                            .ToArray();

                            default:
                                Console.WriteLine("Could not browse items: invalid object type");
                                return new object[] { };
                        }
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        Console.WriteLine("Could not browse items: concurrency issues");
                        Console.WriteLine(ex.Message);

                        return new object[] { };
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Could not browse items: SQL errors");
                        Console.WriteLine(ex.Message);

                        return new object[] { };
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Could not browse items");
                        Console.WriteLine(ex.Message);

                        return new object[] { };
                    }
                }
            }
            
        }

        public bool DeleteItem(object item)
        {
            if (item == null) return false;

            if (_recipesContext is RecipesContext)
            {
                using (var ctx = new RecipesContext())
                {
                    try
                    {
                        switch (item)
                        {
                            case Category c:
                                ctx.Entry(c).State = EntityState.Deleted;
                                break;

                            case Ingredient i:
                                ctx.Entry(i).State = EntityState.Deleted;
                                break;

                            case Recipe r:
                                ctx.Entry(r).State = EntityState.Deleted;
                                break;

                            case IngredientQuantity iq:
                                ctx.Entry(iq).State = EntityState.Deleted;
                                break;

                            default:
                                Console.WriteLine("Could not add new item: invalid object type");
                                return false;
                        }

                        ctx.SaveChanges();
                        return true;
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        Console.WriteLine("Could not delete item: concurrency issues");
                        Console.WriteLine(ex.Message);

                        return false;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Could not delete item: SQL errors");
                        Console.WriteLine(ex.Message);

                        return false;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Could not delete item");
                        Console.WriteLine(ex.Message);

                        return false;
                    }
                }
            }
            else
            {
                using (var ctx = new RecipesTestContext())
                {
                    try
                    {
                        switch (item)
                        {
                            case Category c:
                                ctx.Entry(c).State = EntityState.Deleted;
                                break;

                            case Ingredient i:
                                ctx.Entry(i).State = EntityState.Deleted;
                                break;

                            case Recipe r:
                                ctx.Entry(r).State = EntityState.Deleted;
                                break;

                            case IngredientQuantity iq:
                                ctx.Entry(iq).State = EntityState.Deleted;
                                break;

                            default:
                                Console.WriteLine("Could not add new item: invalid object type");
                                return false;
                        }

                        ctx.SaveChanges();
                        return true;
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        Console.WriteLine("Could not delete item: concurrency issues");
                        Console.WriteLine(ex.Message);

                        return false;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Could not delete item: SQL errors");
                        Console.WriteLine(ex.Message);

                        return false;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Could not delete item");
                        Console.WriteLine(ex.Message);

                        return false;
                    }
                }
            }
        }

        public bool EditItem(object item)
        {
            if (item == null) return false;

            if (_recipesContext is RecipesContext)
            {
                using (var ctx = new RecipesContext())
                {
                    try
                    {
                        switch (item)
                        {
                            case Category c:
                                ctx.Entry(c).State = EntityState.Modified;
                                break;

                            case Ingredient i:
                                ctx.Entry(i).State = EntityState.Modified;
                                break;

                            case Recipe r:
                                ctx.Entry(r).State = EntityState.Modified;
                                break;

                            case IngredientQuantity iq:
                                ctx.Entry(iq).State = EntityState.Modified;
                                break;

                            default:
                                Console.WriteLine("Could not edit item: invalid object type");
                                return false;
                        }

                        ctx.SaveChanges();
                        return true;
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        Console.WriteLine("Could not edit item: concurrency issues");
                        Console.WriteLine(ex.Message);

                        return false;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Could not edit item: SQL errors");
                        Console.WriteLine(ex.Message);

                        return false;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Could not edit item");
                        Console.WriteLine(ex.Message);

                        return false;
                    }
                }
            }
            else
            {
                using (var ctx = new RecipesTestContext())
                {
                    try
                    {
                        switch (item)
                        {
                            case Category c:
                                ctx.Entry(c).State = EntityState.Modified;
                                break;

                            case Ingredient i:
                                ctx.Entry(i).State = EntityState.Modified;
                                break;

                            case Recipe r:
                                ctx.Entry(r).State = EntityState.Modified;
                                break;

                            case IngredientQuantity iq:
                                ctx.Entry(iq).State = EntityState.Modified;
                                break;

                            default:
                                Console.WriteLine("Could not edit item: invalid object type");
                                return false;
                        }

                        ctx.SaveChanges();
                        return true;
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        Console.WriteLine("Could not edit item: concurrency issues");
                        Console.WriteLine(ex.Message);

                        return false;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Could not edit item: SQL errors");
                        Console.WriteLine(ex.Message);

                        return false;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Could not edit item");
                        Console.WriteLine(ex.Message);

                        return false;
                    }
                }
            }
            
        }

        public object ReadItem(object item)
        {
            if (item == null) return false;

            using (_recipesContext = new RecipesContext())
            {
                try
                {
                    switch (item)
                    {
                        case Category c:
                            return _recipesContext.Categories.FirstOrDefault(
                                    e => e.Id == c.Id || e.Name == c.Name
                                );

                        case Ingredient i:
                            return _recipesContext.Ingredients.FirstOrDefault(
                                     e => e.Id == i.Id || e.Name == i.Name
                                 );

                        case Recipe r:
                            return _recipesContext
                                        .Recipes
                                        .Include(e => e.Category)
                                        .FirstOrDefault(
                                            e => e.Id == r.Id || e.Name.Trim().ToLower() == r.Name.Trim().ToLower()
                                        );

                        case IngredientQuantity iq:
                            return _recipesContext
                                        .IngredientQuantities
                                        .Include(e => e.Ingredient)
                                        .Include(e => e.Recipe)
                                        .FirstOrDefault(
                                           e => e.Id == iq.Id || 
                                           (e.IngredientId == iq.IngredientId && 
                                           e.RecipeId == iq.RecipeId)
                                        );

                        default:
                            Console.WriteLine("Could not read item: invalid object type");
                            return null;
                    }
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    Console.WriteLine("Could not edit item: concurrency issues");
                    Console.WriteLine(ex.Message);

                    return null;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Could not edit item: SQL errors");
                    Console.WriteLine(ex.Message);

                    return null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Could not edit item");
                    Console.WriteLine(ex.Message);

                    return null;
                }
            }
        }

        public void ResetDatabaseState()
        {
            if (_recipesContext is RecipesContext)
            {
                using (var ctx = new RecipesContext())
                {
                    try
                    {
                        ctx.Database.ExecuteSqlCommand("DELETE FROM Recipes");
                        ctx.Database.ExecuteSqlCommand("DELETE FROM IngredientQuantities");

                        ctx.SaveChanges();

                        ctx.Database.ExecuteSqlCommand("DELETE FROM Categories");
                        ctx.Database.ExecuteSqlCommand("DELETE FROM Ingredients");

                        ctx.SaveChanges();
                    }
                    catch (NullReferenceException e)
                    {
                        Console.WriteLine("Could not reset database state: recipesContext was null.");
                        Console.WriteLine(e.Message);
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine("Could not reset database state: SQL error");
                        Console.WriteLine(e.Message);
                    }
                    catch (DbUpdateConcurrencyException e)
                    {
                        Console.WriteLine("Could not reset database state: unable to save changes due to concurrency issues.");
                        Console.WriteLine(e.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Could not reset database state");
                        Console.WriteLine(e);
                    }
                }
            }
            else
            {
                using (var ctx = new RecipesTestContext())
                {
                    try
                    {
                        ctx.Database.ExecuteSqlCommand("DELETE FROM Recipes");
                        ctx.Database.ExecuteSqlCommand("DELETE FROM IngredientQuantities");

                        ctx.SaveChanges();

                        ctx.Database.ExecuteSqlCommand("DELETE FROM Categories");
                        ctx.Database.ExecuteSqlCommand("DELETE FROM Ingredients");

                        ctx.SaveChanges();
                    }
                    catch (NullReferenceException e)
                    {
                        Console.WriteLine("Could not reset database state: recipesContext was null.");
                        Console.WriteLine(e.Message);
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine("Could not reset database state: SQL error");
                        Console.WriteLine(e.Message);
                    }
                    catch (DbUpdateConcurrencyException e)
                    {
                        Console.WriteLine("Could not reset database state: unable to save changes due to concurrency issues.");
                        Console.WriteLine(e.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Could not reset database state");
                        Console.WriteLine(e);
                    }
                }
            }
        }

        public void SeedDatabase(string seedDataPath)
        {
            if (_recipesContext is RecipesContext)
            {
                using (var ctx = new RecipesContext())
                {
                    try
                    {
                        // Read SeedData.sql file
                        string seedData = File.ReadAllText(seedDataPath);

                        ctx.Database.ExecuteSqlCommand(seedData);
                        ctx.SaveChanges();
                    }
                    catch (FileNotFoundException e)
                    {
                        Console.WriteLine("SeedData.sql was not found");
                        Console.WriteLine(e.Message);
                    }
                    catch (DirectoryNotFoundException e)
                    {
                        Console.WriteLine("Database directory was not found");
                        Console.WriteLine(e.Message);
                    }
                    catch (IOException e)
                    {
                        Console.WriteLine("Could not read seed data sql file");
                        Console.WriteLine(e.Message);
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine("SQL error");
                        Console.WriteLine(e.Message);
                    }
                    catch (DbUpdateConcurrencyException e)
                    {
                        Console.WriteLine("Could not seed data: unable to save changes due to concurrency issues.");
                        Console.WriteLine(e.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Could not seed data");
                        Console.WriteLine(e.Message);
                    }
                }
            }
            else
            {

            }
            
        }

        public async Task<object[]> BrowseItemsAsync(Type entityType)
        {
            using (_recipesContext = new RecipesContext())
            {
                try
                {
                    switch (entityType.Name)
                    {
                        case "Category":
                            var categories = await _recipesContext.Categories.ToArrayAsync();
                            return categories;

                        case "Ingredient":
                            var ingredients = await _recipesContext.Ingredients.ToArrayAsync();
                            return ingredients;

                        case "Recipe":
                            var recipes = await _recipesContext.Recipes.Include(r => r.Category).ToArrayAsync();
                            return recipes;

                        case "IngredientQuantity":
                            var iq = await _recipesContext
                                        .IngredientQuantities
                                        .Include(m => m.Ingredient)
                                        .Include(m => m.Recipe)
                                        .ToArrayAsync();
                            return iq;

                        default:
                            Console.WriteLine("Could not browse items: invalid object type");
                            return new object[] { };
                    }
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    Console.WriteLine("Could not browse items: concurrency issues");
                    Console.WriteLine(ex.Message);

                    return new object[] { };
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Could not browse items: SQL errors");
                    Console.WriteLine(ex.Message);

                    return new object[] { };
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Could not browse items");
                    Console.WriteLine(ex.Message);

                    return new object[] { };
                }
            }
        }
    }
}
