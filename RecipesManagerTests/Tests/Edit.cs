using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipesData.Setup;
using System.IO;
using RecipesData.Models;
using Moq;
using System.Data.Entity;
using RecipesData.Context;

namespace RecipesManagerTests
{
    /// <summary>
    /// Contains unit tests for <see cref="DbManager.EditItem(object)"/>
    /// </summary>
    [TestClass]
    public class Edit
    {
        private DbManager dbManager;

        public Edit()
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
        /// Edit a category
        /// </summary>
        [TestMethod]
        public void EditCategory()
        {
            var drink = dbManager.ReadItem(new Category { Id = 6 });

            if (drink != null)
            {
                var editedItem = dbManager.EditItem(new Category
                {
                    Id = ((Category)drink).Id,
                    Name = "cocktail"
                });

                Assert.IsTrue(editedItem);
            }
        }

        /// <summary>
        /// Edit an ingredient
        /// </summary>
        [TestMethod]
        public void EditIngredient()
        {
            var porkRibs = dbManager.ReadItem(new Ingredient { Id = 1 });

            if (porkRibs != null)
            {
                var editedItem = dbManager.EditItem(new Ingredient
                {
                    Id = ((Ingredient)porkRibs).Id,
                    Name = "pork loin"
                });

                Assert.IsTrue(editedItem);
            }
        }

        /// <summary>
        /// Edit a recipe
        /// </summary>
        [TestMethod]
        public void EditRecipe()
        {
            var record = dbManager.ReadItem(new Recipe { Id = 2 });

            if (record != null)
            {
                var risotto = (Recipe)record;

                var editedItem = dbManager.EditItem(new Recipe
                {
                    Id = risotto.Id,
                    Name = "chicken and mushroom risotto",
                    CategoryId = 3,
                    Serves = 5,
                    PreparationTime = 15,
                    KcalPerServe = 450,
                    Method = @"         1 - Place the stock into a medium saucepan and place over a medium heat. Bring to a simmer, and then remove the pan from the heat and cover with a lid to keep hot.
                                        2 - ...
                                     "
                });

                Assert.IsTrue(editedItem);
            }
        }

        /// <summary>
        /// Edit an ingredient quantity record
        /// </summary>
        [TestMethod]
        public void EditIngredientQuantity()
        {
            var record = dbManager.ReadItem(new IngredientQuantity { Id = 6 });

            if (record != null)
            {
                var darkBeerInThaiSoup = (IngredientQuantity)record;

                // Let's ruin some recipes :)
                var editedItem = dbManager.EditItem(new IngredientQuantity
                {
                    Id = darkBeerInThaiSoup.Id,
                    RecipeId = 3,
                    IngredientId = 54,
                    Quantity = "1 litre"
                });

                Assert.IsTrue(editedItem);
            }
        }
    }
}
