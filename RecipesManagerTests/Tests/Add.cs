using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipesData.Models;
using RecipesData.Setup;

namespace RecipesManagerTests
{
    [TestClass]
    public class Add
    {
        private IDbManager _dbManager;

        [TestInitialize]
        public void TestInitialize()
        {
            _dbManager = new DbManager();
        }
        
        // Reset database state after each test
        [TestCleanup]
        public void TestCleanup()
        {            
            _dbManager.ResetDatabaseState();
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

            var itemAdded = _dbManager.AddItem(category);

            Assert.IsTrue(itemAdded);
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

            var ingredientAdded = _dbManager.AddItem(ingredient);

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

            if (_dbManager.AddItem(category))
            {
                var recipe = new Recipe
                {
                    Id = 1,
                    Name = "ice cream",
                    CategoryId = category.Id
                };

                var recipeAdded = _dbManager.AddItem(recipe);

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

            if (_dbManager.AddItem(thyme))
            {
                var salad = new Category
                {
                    Id = 1,
                    Name = "salad"
                };

                if (_dbManager.AddItem(salad))
                {
                    var ltd = new Recipe
                    {
                        Id = 1,
                        Name = "lemon thyme dressing",
                        CategoryId = salad.Id
                    };

                    if (_dbManager.AddItem(ltd))
                    {
                        var iq = new IngredientQuantity
                        {
                            Id = 1,
                            IngredientId = thyme.Id,
                            RecipeId = ltd.Id,
                            Quantity = "10 leaves"
                        };

                        var iqAdded = _dbManager.AddItem(iq);

                        Assert.IsTrue(iqAdded);
                    }
                }
            }
        }
    }
}
