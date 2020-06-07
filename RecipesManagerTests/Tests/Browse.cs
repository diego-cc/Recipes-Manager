using System.Data.Entity;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RecipesData.Context;
using RecipesData.Models;
using RecipesData.Setup;

namespace RecipesManagerTests
{
    /// <summary>
    /// Contains unit tests for <see cref="DbManager.BrowseItems(System.Type)"/>
    /// </summary>
    [TestClass]
    public class Browse
    {
        private DbManager dbManager;

        public Browse()
        {
            var mockSet = new Mock<DbSet<Category>>();
            var mockContext = new Mock<RecipesTestContext>();

            mockContext.Setup(m => m.Categories).Returns(mockSet.Object);

            dbManager = new DbManager(mockContext.Object);
            dbManager.ResetDatabaseState();

            // Seed categories
            dbManager.AddItem(new Category { Id = 1, Name = "main" });
            dbManager.AddItem(new Category { Id = 2, Name = "dessert" });

            // Seed ingredients
            dbManager.AddItem(new Ingredient { Id = 1, Name = "short-grain rice" });
            dbManager.AddItem(new Ingredient { Id = 2, Name = "apple" });
            dbManager.AddItem(new Ingredient { Id = 3, Name = "fish" });

            // Seed recipes
            dbManager.AddItem(new Recipe { Id = 1, Name = "risotto", CategoryId = 1, KcalPerServe = 429, Favourite = false, Serves = 4, PreparationTime = 40 });
            dbManager.AddItem(new Recipe { Id = 2, Name = "fish and chips", CategoryId = 1, KcalPerServe = 479, Serves = 4, PreparationTime = 40, Favourite = true });
            dbManager.AddItem(new Recipe { Id = 3, Name = "apple and butterscotch pie", CategoryId = 2, Favourite = false, KcalPerServe = 311, Serves = 8, PreparationTime = 105 });

            // Seed ingredient quantities
            dbManager.AddItem(new IngredientQuantity { Id = 1, RecipeId = 1, IngredientId = 2, Amount = 300 });
            dbManager.AddItem(new IngredientQuantity { Id = 2, RecipeId = 2, IngredientId = 3, Amount = 300 });
            dbManager.AddItem(new IngredientQuantity { Id = 3, RecipeId = 3, IngredientId = 1, Quantity = "a few slices" });
        }

        /// <summary>
        /// Reset database state after each test
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {
        }

        /// <summary>
        /// Seed database before each test
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            
        }

        /// <summary>
        /// Browse all categories
        /// </summary>
        [TestMethod]
        public void BrowseCategories()
        {
            Assert.AreEqual(2, dbManager.BrowseItems(typeof(Category)).Length);
        }

        /// <summary>
        /// Browse all ingredients
        /// </summary>
        [TestMethod]
        public void BrowseIngredients()
        {
            Assert.AreEqual(3, dbManager.BrowseItems(typeof(Ingredient)).Length);
        }

        /// <summary>
        /// Browse all recipes
        /// </summary>
        [TestMethod]
        public void BrowseRecipes()
        {
            Assert.AreEqual(3, dbManager.BrowseItems(typeof(Recipe)).Length);
        }

        ///// <summary>
        ///// Browse all ingredient quantities
        ///// </summary>
        [TestMethod]
        public void BrowseIngredientQuantities()
        {
            Assert.AreEqual(3, dbManager.BrowseItems(typeof(IngredientQuantity)).Length);
        }
    }
}
