using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RecipesData.Context;
using RecipesData.Models;
using RecipesData.Setup;
using System.Data.Entity;

namespace RecipesManagerTests
{
    /// <summary>
    /// Contains unit tests for <see cref="DbManager.AddItem(object)"/>
    /// </summary>
    [TestClass]
    public class Add
    {
        private DbManager dbManager;

        public Add()
        {
            var mockSet = new Mock<DbSet<Category>>();
            var mockContext = new Mock<RecipesTestContext>();

            mockContext.Setup(m => m.Categories).Returns(mockSet.Object);

            dbManager = new DbManager(mockContext.Object);
            dbManager.ResetDatabaseState();
        }

        [TestInitialize]
        public void TestInitialize()
        {
        }
        
        // Reset database state after each test
        [TestCleanup]
        public void TestCleanup()
        {
            dbManager.ResetDatabaseState();
        }

        /// <summary>
        /// Add a category
        /// </summary>
        [TestMethod]
        public void AddCategory()
        {
            var category = new Category
            {
                Id = 1,
                Name = "main"
            };

            var categoryAdded = dbManager.AddItem(category);

            Assert.IsTrue(categoryAdded);
        }

        /// <summary>
        /// Add an ingredient
        /// </summary>
        [TestMethod]
        public void AddIngredient()
        {
            var ingredient = new Ingredient
            {
                Id = 1,
                Name = "whiting"
            };

            var ingredientAdded = dbManager.AddItem(ingredient);

            Assert.IsTrue(ingredientAdded);
        }

        /// <summary>
        /// Add a recipe
        /// </summary>
        [TestMethod]
        public void AddRecipe()
        {
            var category = new Category
            {
                Id = 1,
                Name = "dessert"
            };

            if (dbManager.AddItem(category))
            {
                var recipe = new Recipe
                {
                    Id = 1,
                    Name = "ice cream",
                    CategoryId = category.Id
                };

                var recipeAdded = dbManager.AddItem(recipe);

                Assert.IsTrue(recipeAdded);
            }
        }

        /// <summary>
        /// Add ingredient quantity
        /// </summary>
        [TestMethod]
        public void AddIngredientQuantity()
        {
            var thyme = new Ingredient
            {
                Id = 1,
                Name = "thyme"
            };

            if (dbManager.AddItem(thyme))
            {
                var salad = new Category
                {
                    Id = 1,
                    Name = "salad"
                };

                if (dbManager.AddItem(salad))
                {
                    var ltd = new Recipe
                    {
                        Id = 1,
                        Name = "lemon thyme dressing",
                        CategoryId = salad.Id
                    };

                    if (dbManager.AddItem(ltd))
                    {
                        var iq = new IngredientQuantity
                        {
                            Id = 1,
                            IngredientId = thyme.Id,
                            RecipeId = ltd.Id,
                            Quantity = "10 leaves"
                        };

                        var iqAdded = dbManager.AddItem(iq);

                        Assert.IsTrue(iqAdded);
                    }
                }
            }
        }
    }
}
