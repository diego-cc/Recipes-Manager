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
    /// Contains unit tests for <see cref="DbManager.DeleteItem(object)"/>
    /// </summary>
    [TestClass]
    public class Delete
    {
        private DbManager dbManager;

        public Delete()
        {
            var mockSet = new Mock<DbSet<Category>>();
            var mockContext = new Mock<RecipesTestContext>();

            mockContext.Setup(m => m.Categories).Returns(mockSet.Object);

            dbManager = new DbManager(mockContext.Object);
            dbManager.ResetDatabaseState();
        }

        /// <summary>
        /// Reset database state after each test
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {
            dbManager.ResetDatabaseState();
        }

        /// <summary>
        /// Seed database before each test
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            dbManager.SeedDatabase(
                   Path.GetFullPath(Path.Combine("../", "../", "../", "Database", "SeedData.sql"))
                   );
        }

        /// <summary>
        /// Delete a category
        /// </summary>
        [TestMethod]
        public void DeleteCategory()
        {
            var previousNumOfRecords = dbManager.BrowseItems(typeof(Category)).Length;

            var categoryDeleted = dbManager.DeleteItem(new Category { Id = 1 });

            if (categoryDeleted)
            {
                var newNumOfRecords = dbManager.BrowseItems(typeof(Category)).Length;

                Assert.AreEqual(previousNumOfRecords - 1, newNumOfRecords);
            }
        }

        /// <summary>
        /// Delete an ingredient
        /// </summary>
        [TestMethod]
        public void DeleteIngredient()
        {
            var previousNumOfRecords = dbManager.BrowseItems(typeof(Ingredient)).Length;

            var ingredientDeleted = dbManager.DeleteItem(new Ingredient { Id = 1 });

            if (ingredientDeleted)
            {
                var newNumOfRecords = dbManager.BrowseItems(typeof(Ingredient)).Length;

                Assert.AreEqual(previousNumOfRecords - 1, newNumOfRecords);
            }
        }

        /// <summary>
        /// Delete a recipe
        /// </summary>
        [TestMethod]
        public void DeleteRecipe()
        {
            var previousNumOfRecords = dbManager.BrowseItems(typeof(Recipe)).Length;

            var recipeDeleted = dbManager.DeleteItem(new Recipe { Id = 1 });

            if (recipeDeleted)
            {
                var newNumOfRecords = dbManager.BrowseItems(typeof(Recipe)).Length;

                Assert.AreEqual(previousNumOfRecords - 1, newNumOfRecords);
            }
        }

        /// <summary>
        /// Delete an ingredient quantity record
        /// </summary>
        [TestMethod]
        public void DeleteIngredientQuantity()
        {
            var previousNumOfRecords = dbManager.BrowseItems(typeof(IngredientQuantity)).Length;

            var iqDeleted = dbManager.DeleteItem(new IngredientQuantity { Id = 1 });

            if (iqDeleted)
            {
                var newNumOfRecords = dbManager.BrowseItems(typeof(IngredientQuantity)).Length;

                Assert.AreEqual(previousNumOfRecords - 1, newNumOfRecords);
            }
        }
    }
}