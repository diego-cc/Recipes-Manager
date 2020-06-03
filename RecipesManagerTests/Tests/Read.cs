using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipesData.Models;
using RecipesData.Setup;
using System.IO;

namespace RecipesManagerTests
{
    [TestClass]
    public class Read
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
        /// Read a category record
        /// </summary>
        [TestMethod]
        public void ReadCategory()
        {
            var record = _dbManager.ReadItem(new Category { Id = 6 });

            if (record != null)
            {
                var drink = (Category)record;

                Assert.IsTrue(drink.Name == "drink");
            }
        }

        /// <summary>
        /// Read an ingredient
        /// </summary>
        [TestMethod]
        public void ReadIngredient()
        {
            var record = _dbManager.ReadItem(new Ingredient { Id = 34 });

            if (record != null)
            {
                var pumpkin = (Ingredient)record;

                Assert.IsTrue(pumpkin.Name == "pumpkin");
            }
        }

        /// <summary>
        /// Read a recipe
        /// </summary>
        [TestMethod]
        public void ReadRecipe()
        {
            var record = _dbManager.ReadItem(new Recipe { Id = 2 });

            if (record != null)
            {
                var risotto = (Recipe)record;

                Assert.IsTrue(
                    risotto.Name == "risotto" &&
                    risotto.Category.Name == "main" &&
                    risotto.Serves == 4 &&
                    risotto.PreparationTime == 40 &&
                    risotto.KcalPerServe == 429
                    );
            }
        }

        /// <summary>
        /// Read an ingredient quantity
        /// </summary>
        [TestMethod]
        public void ReadIngredientQuantity()
        {
            var record = _dbManager.ReadItem(new IngredientQuantity { Id = 1 });

            if (record != null)
            {
                var flourInFishAndChips = (IngredientQuantity)record;

                Assert.IsTrue(
                        flourInFishAndChips.Recipe.Name == "fish and chips" &&
                        flourInFishAndChips.Ingredient.Name == "flour" &&
                        flourInFishAndChips.Quantity == null &&
                        flourInFishAndChips.Amount == 55
                    );
            }
        }
    }
}