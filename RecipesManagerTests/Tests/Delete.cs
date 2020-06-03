using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipesData.Models;
using RecipesData.Setup;

namespace RecipesManagerTests
{
    [TestClass]
    public class Delete
    {
        private IDbManager _dbManager;

        /// <summary>
        /// Reset database state after each test
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {
            _dbManager.ResetDatabaseState();
        }

        /// <summary>
        /// Seed database before each test
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            _dbManager = new DbManager();

            _dbManager.SeedDatabase(
                   Path.GetFullPath(Path.Combine("../", "../", "../", "Database", "SeedData.sql"))
                   );
        }

        /// <summary>
        /// Delete a category
        /// </summary>
        [TestMethod]
        public void DeleteCategory()
        {
            var previousNumOfRecords = _dbManager.BrowseItems(typeof(Category)).Length;

            var categoryDeleted = _dbManager.DeleteItem(new Category { Id = 1 });

            if (categoryDeleted)
            {
                var newNumOfRecords = _dbManager.BrowseItems(typeof(Category)).Length;

                Assert.AreEqual(previousNumOfRecords - 1, newNumOfRecords);
            }
        }

        /// <summary>
        /// Delete an ingredient
        /// </summary>
        [TestMethod]
        public void DeleteIngredient()
        {
            var previousNumOfRecords = _dbManager.BrowseItems(typeof(Ingredient)).Length;

            var ingredientDeleted = _dbManager.DeleteItem(new Ingredient { Id = 1 });

            if (ingredientDeleted)
            {
                var newNumOfRecords = _dbManager.BrowseItems(typeof(Ingredient)).Length;

                Assert.AreEqual(previousNumOfRecords - 1, newNumOfRecords);
            }
        }

        /// <summary>
        /// Delete a recipe
        /// </summary>
        [TestMethod]
        public void DeleteRecipe()
        {
            var previousNumOfRecords = _dbManager.BrowseItems(typeof(Recipe)).Length;

            var recipeDeleted = _dbManager.DeleteItem(new Recipe { Id = 1 });

            if (recipeDeleted)
            {
                var newNumOfRecords = _dbManager.BrowseItems(typeof(Recipe)).Length;

                Assert.AreEqual(previousNumOfRecords - 1, newNumOfRecords);
            }
        }

        /// <summary>
        /// Delete an ingredient quantity record
        /// </summary>
        [TestMethod]
        public void DeleteIngredientQuantity()
        {
            var previousNumOfRecords = _dbManager.BrowseItems(typeof(IngredientQuantity)).Length;

            var iqDeleted = _dbManager.DeleteItem(new IngredientQuantity { Id = 1 });

            if (iqDeleted)
            {
                var newNumOfRecords = _dbManager.BrowseItems(typeof(IngredientQuantity)).Length;

                Assert.AreEqual(previousNumOfRecords - 1, newNumOfRecords);
            }
        }
    }
}