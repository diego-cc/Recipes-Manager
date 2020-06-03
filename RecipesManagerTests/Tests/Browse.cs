using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipesData.Models;
using RecipesData.Setup;

namespace RecipesManagerTests
{
    [TestClass]
    public class Browse
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
        /// Browse all categories
        /// </summary>
        [TestMethod]
        public void BrowseCategories()
        {
            var allCategories = _dbManager.BrowseItems(typeof(Category));

            Assert.AreEqual(6, allCategories.Length);
        }

        /// <summary>
        /// Browse all ingredients
        /// </summary>
        [TestMethod]
        public void BrowseIngredients()
        {
            var allIngredients = _dbManager.BrowseItems(typeof(Ingredient));

            Assert.AreEqual(56, allIngredients.Length);
        }

        /// <summary>
        /// Browse all recipes
        /// </summary>
        [TestMethod]
        public void BrowseRecipes()
        {
            var allRecipes = _dbManager.BrowseItems(typeof(Recipe));

            Assert.AreEqual(7, allRecipes.Length);
        }

        /// <summary>
        /// Browse all ingredient quantities
        /// </summary>
        [TestMethod]
        public void BrowseIngredientQuantities()
        {
            var allIngredientQuantities = _dbManager.BrowseItems(typeof(IngredientQuantity));

            Assert.AreEqual(65, allIngredientQuantities.Length);
        }
    }
}
