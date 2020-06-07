namespace RecipesData.Migrations
{
    using RecipesData.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RecipesData.Context.RecipesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RecipesData.Context.RecipesContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            // CATEGORIES
            var category1 = new Category { Id = 1, Name = "main" };
            var category2 = new Category { Id = 2, Name = "dessert" };
            var category3 = new Category { Id = 3, Name = "snack" };
            var category4 = new Category { Id = 4, Name = "salad" };
            var category5 = new Category { Id = 5, Name = "soup" };
            var category6 = new Category { Id = 6, Name = "drink" };

            context.Categories.AddOrUpdate(new Category[]
            {
                category1,
                category2,
                category3,
                category4,
                category5,
                category6
            });

            category1.Id = 1;
            category2.Id = 2;
            category3.Id = 3;
            category4.Id = 4;
            category5.Id = 5;
            category6.Id = 6;

            // INGREDIENTS
            var ingredient1 = new Ingredient { Id = 1, Name = "pork ribs" };
            var ingredient2 = new Ingredient { Id = 2, Name = "chicken breast" };
            var ingredient3 = new Ingredient { Id = 3, Name = "whiting" };
            var ingredient4 = new Ingredient { Id = 4, Name = "olive oil" };
            var ingredient5 = new Ingredient { Id = 5, Name = "black beans" };
            var ingredient6 = new Ingredient { Id = 6, Name = "short-grain rice" };
            var ingredient7 = new Ingredient { Id = 7, Name = "potatoes" };
            var ingredient8 = new Ingredient { Id = 8, Name = "milk" };
            var ingredient9 = new Ingredient { Id = 9, Name = "egg" };
            var ingredient10 = new Ingredient { Id = 10, Name = "salt" };
            var ingredient11 = new Ingredient { Id = 11, Name = "black pepper" };
            var ingredient12 = new Ingredient { Id = 12, Name = "flour" };
            var ingredient13 = new Ingredient { Id = 13, Name = "baking powder" };
            var ingredient14 = new Ingredient { Id = 14, Name = "cornstarch" };
            var ingredient15 = new Ingredient { Id = 15, Name = "dark beer" };
            var ingredient16 = new Ingredient { Id = 16, Name = "sparkling water" };
            var ingredient17 = new Ingredient { Id = 17, Name = "chicken stock" };
            var ingredient18 = new Ingredient { Id = 18, Name = "shallot" };
            var ingredient19 = new Ingredient { Id = 19, Name = "shiitake" };
            var ingredient20 = new Ingredient { Id = 20, Name = "butter" };
            var ingredient21 = new Ingredient { Id = 21, Name = "garlic" };
            var ingredient22 = new Ingredient { Id = 22, Name = "thyme" };
            var ingredient23 = new Ingredient { Id = 23, Name = "arborio rice" };
            var ingredient24 = new Ingredient { Id = 24, Name = "white wine" };
            var ingredient25 = new Ingredient { Id = 25, Name = "parmesan cheese" };
            var ingredient26 = new Ingredient { Id = 26, Name = "parsley" };
            var ingredient27 = new Ingredient { Id = 27, Name = "shortcut pastry" };
            var ingredient28 = new Ingredient { Id = 28, Name = "brown sugar" };
            var ingredient29 = new Ingredient { Id = 29, Name = "golden syrup" };
            var ingredient30 = new Ingredient { Id = 30, Name = "cinnamon" };
            var ingredient31 = new Ingredient { Id = 31, Name = "nutmeg" };
            var ingredient32 = new Ingredient { Id = 32, Name = "granny smith apple" };
            var ingredient33 = new Ingredient { Id = 33, Name = "caster sugar" };
            var ingredient34 = new Ingredient { Id = 34, Name = "pumpkin" };
            var ingredient35 = new Ingredient { Id = 35, Name = "buttermilk" };
            var ingredient36 = new Ingredient { Id = 36, Name = "feta" };
            var ingredient37 = new Ingredient { Id = 37, Name = "chardonnay vinegar" };
            var ingredient38 = new Ingredient { Id = 38, Name = "Dijon mustard" };
            var ingredient39 = new Ingredient { Id = 39, Name = "watercress" };
            var ingredient40 = new Ingredient { Id = 40, Name = "rocket leaf" };
            var ingredient41 = new Ingredient { Id = 41, Name = "baby heirloom tomato" };
            var ingredient42 = new Ingredient { Id = 42, Name = "baby (Dutch) carrot" };
            var ingredient43 = new Ingredient { Id = 43, Name = "radish" };
            var ingredient44 = new Ingredient { Id = 44, Name = "canola oil" };
            var ingredient45 = new Ingredient { Id = 45, Name = "brown onion" };
            var ingredient46 = new Ingredient { Id = 46, Name = "red curry paste" };
            var ingredient47 = new Ingredient { Id = 47, Name = "gold sweet potato" };
            var ingredient48 = new Ingredient { Id = 48, Name = "lemongrass paste" };
            var ingredient49 = new Ingredient { Id = 49, Name = "soy milk" };
            var ingredient50 = new Ingredient { Id = 50, Name = "coconut milk" };
            var ingredient51 = new Ingredient { Id = 51, Name = "sesame seed" };
            var ingredient52 = new Ingredient { Id = 52, Name = "coriander" };
            var ingredient53 = new Ingredient { Id = 53, Name = "gin" };
            var ingredient54 = new Ingredient { Id = 54, Name = "vodka" };
            var ingredient55 = new Ingredient { Id = 55, Name = "Lillet blanc apéritif" };
            var ingredient56 = new Ingredient { Id = 56, Name = "lemon" };

            context.Ingredients.AddOrUpdate(new Ingredient[]
            {
                ingredient1,
                ingredient2,
                ingredient3,
                ingredient4,
                ingredient5,
                ingredient6,
                ingredient7,
                ingredient8,
                ingredient9,
                ingredient10,
                ingredient11,
                ingredient12,
                ingredient13,
                ingredient14,
                ingredient15,
                ingredient16,
                ingredient17,
                ingredient18,
                ingredient19,
                ingredient20,
                ingredient21,
                ingredient22,
                ingredient23,
                ingredient24,
                ingredient25,
                ingredient26,
                ingredient27,
                ingredient28,
                ingredient29,
                ingredient30,
                ingredient31,
                ingredient32,
                ingredient33,
                ingredient34,
                ingredient35,
                ingredient36,
                ingredient37,
                ingredient38,
                ingredient39,
                ingredient40,
                ingredient41,
                ingredient42,
                ingredient43,
                ingredient44,
                ingredient45,
                ingredient46,
                ingredient47,
                ingredient48,
                ingredient49,
                ingredient50,
                ingredient51,
                ingredient52,
                ingredient53,
                ingredient54,
                ingredient55,
                ingredient56
            });

            ingredient1.Id = 1;
            ingredient2.Id = 2;
            ingredient3.Id = 3;
            ingredient4.Id = 4;
            ingredient5.Id = 5;
            ingredient6.Id = 6;
            ingredient7.Id = 7;
            ingredient8.Id = 8;
            ingredient9.Id = 9;
            ingredient10.Id = 10;
            ingredient11.Id = 11;
            ingredient12.Id = 12;
            ingredient13.Id = 13;
            ingredient14.Id = 14;
            ingredient15.Id = 15;
            ingredient16.Id = 16;
            ingredient17.Id = 17;
            ingredient18.Id = 18;
            ingredient19.Id = 19;
            ingredient20.Id = 20;
            ingredient21.Id = 21;
            ingredient22.Id = 22;
            ingredient23.Id = 23;
            ingredient24.Id = 24;
            ingredient25.Id = 25;
            ingredient26.Id = 26;
            ingredient27.Id = 27;
            ingredient28.Id = 28;
            ingredient29.Id = 29;
            ingredient30.Id = 30;
            ingredient31.Id = 31;
            ingredient32.Id = 32;
            ingredient33.Id = 33;
            ingredient34.Id = 34;
            ingredient35.Id = 35;
            ingredient36.Id = 36;
            ingredient37.Id = 37;
            ingredient38.Id = 38;
            ingredient39.Id = 39;
            ingredient40.Id = 40;
            ingredient41.Id = 41;
            ingredient42.Id = 42;
            ingredient43.Id = 43;
            ingredient44.Id = 44;
            ingredient45.Id = 45;
            ingredient46.Id = 46;
            ingredient47.Id = 47;
            ingredient48.Id = 48;
            ingredient49.Id = 49;
            ingredient50.Id = 50;
            ingredient51.Id = 51;
            ingredient52.Id = 52;
            ingredient53.Id = 53;
            ingredient54.Id = 54;
            ingredient55.Id = 55;
            ingredient56.Id = 56;
                
            // RECIPES
            var recipe1 = new Recipe { Id = 1, CategoryId = 1, Name = "fish and chips", Serves = 4, PreparationTime = 40, KcalPerServe = 479 };
            var recipe2 = new Recipe { Id = 2, CategoryId = 1, Name = "risotto", Serves = 4, PreparationTime = 40, KcalPerServe = 429 };
            var recipe3 = new Recipe { Id = 3, CategoryId = 2, Name = "apple and butterscotch pie", Serves = 8, PreparationTime = 105, KcalPerServe = 311 };
            var recipe4 = new Recipe { Id = 4, CategoryId = 3, Name = "cheesy pumpkin scones", Serves = 6, PreparationTime = 50, KcalPerServe = null };
            var recipe5 = new Recipe { Id = 5, CategoryId = 4, Name = "garden salad with vinaigrette", Serves = 6, PreparationTime = 10, KcalPerServe = null };
            var recipe6 = new Recipe { Id = 6, CategoryId = 5, Name = "thai sweet potato soup", Serves = 4, PreparationTime = 45, KcalPerServe = null };
            var recipe7 = new Recipe { Id = 7, CategoryId = 6, Name = "vesper martini", Serves = 1, PreparationTime = 3, KcalPerServe = 483 };

            context.Recipes.AddOrUpdate(new Recipe[]
            {
                recipe1,
                recipe2,
                recipe3,
                recipe4,
                recipe5,
                recipe6,
                recipe7
            });

            recipe1.Id = 1;
            recipe1.CategoryId = 1;

            recipe2.Id = 2;
            recipe2.CategoryId = 1;

            recipe3.Id = 3;
            recipe3.CategoryId = 2;

            recipe4.Id = 4;
            recipe4.CategoryId = 3;

            recipe5.Id = 5;
            recipe5.CategoryId = 4;

            recipe6.Id = 6;
            recipe6.CategoryId = 5;

            recipe7.Id = 7;
            recipe7.CategoryId = 6;

            // INGREDIENT QUANTITIES
            var ingredientQuantity1 = new IngredientQuantity { Id = 1, RecipeId = 1, IngredientId = 12, Amount = 55 };
            var ingredientQuantity2 = new IngredientQuantity { Id = 2, RecipeId = 1, IngredientId = 14, Amount = 55 };
            var ingredientQuantity3 = new IngredientQuantity { Id = 3, RecipeId = 1, IngredientId = 13, Quantity = "1 teaspoon", Amount = null };
            var ingredientQuantity4 = new IngredientQuantity { Id = 4, RecipeId = 1, IngredientId = 10, Quantity = "to taste", Amount = null };
            var ingredientQuantity5 = new IngredientQuantity { Id = 5, RecipeId = 1, IngredientId = 11, Quantity = "to taste", Amount = null };
            var ingredientQuantity6 = new IngredientQuantity { Id = 6, RecipeId = 1, IngredientId = 15, Quantity = "1/3 cup", Amount = null };
            var ingredientQuantity7 = new IngredientQuantity { Id = 7, RecipeId = 1, IngredientId = 16, Quantity = "1/3 cup", Amount = null };
            var ingredientQuantity8 = new IngredientQuantity { Id = 8, RecipeId = 1, IngredientId = 3, Quantity = "4 fillets", Amount = null };
            var ingredientQuantity9 = new IngredientQuantity { Id = 9, RecipeId = 1, IngredientId = 7, Amount = 900 };
            var ingredientQuantity10 = new IngredientQuantity { Id = 10, RecipeId = 1, IngredientId = 4, Quantity = "1 litre", Amount = null };
            var ingredientQuantity11 = new IngredientQuantity { Id = 11, RecipeId = 2, IngredientId = 17, Quantity = "6 cups", Amount = null };
            var ingredientQuantity12 = new IngredientQuantity { Id = 12, RecipeId = 2, IngredientId = 4, Quantity = "2 tablespoons", Amount = null };
            var ingredientQuantity13 = new IngredientQuantity { Id = 13, RecipeId = 2, IngredientId = 18, Quantity = "1, finely chopped", Amount = null };            
            var ingredientQuantity14 = new IngredientQuantity { Id = 14, RecipeId = 2, IngredientId = 19, Amount = 455 };
            var ingredientQuantity15 = new IngredientQuantity { Id = 15, RecipeId = 2, IngredientId = 20, Quantity = "2 tablespoons", Amount = null };
            var ingredientQuantity16 = new IngredientQuantity { Id = 16, RecipeId = 2, IngredientId = 21, Quantity = "2 cloves", Amount = null };
            var ingredientQuantity17 = new IngredientQuantity { Id = 17, RecipeId = 2, IngredientId = 22, Quantity = "1 teaspoon", Amount = null };
            var ingredientQuantity18 = new IngredientQuantity { Id = 18, RecipeId = 2, IngredientId = 10, Quantity = "to taste", Amount = null };
            var ingredientQuantity19 = new IngredientQuantity { Id = 19, RecipeId = 2, IngredientId = 11, Quantity = "to taste", Amount = null };
            var ingredientQuantity20 = new IngredientQuantity { Id = 20, RecipeId = 2, IngredientId = 23, Amount = 200 };
            var ingredientQuantity21 = new IngredientQuantity { Id = 21, RecipeId = 2, IngredientId = 24, Quantity = "1/2 cup", Amount = null };
            var ingredientQuantity22 = new IngredientQuantity { Id = 22, RecipeId = 2, IngredientId = 25, Amount = 110 };
            var ingredientQuantity23 = new IngredientQuantity { Id = 23, RecipeId = 2, IngredientId = 26, Amount = 10 };
            var ingredientQuantity24 = new IngredientQuantity { Id = 24, RecipeId = 3, IngredientId = 27, Quantity = "3 sheets", Amount = null };
            var ingredientQuantity25 = new IngredientQuantity { Id = 25, RecipeId = 3, IngredientId = 28, Quantity = "1/2 cup", Amount = null };
            var ingredientQuantity26 = new IngredientQuantity { Id = 26, RecipeId = 3, IngredientId = 29, Quantity = "1/3 cup", Amount = null };
            var ingredientQuantity27 = new IngredientQuantity { Id = 27, RecipeId = 3, IngredientId = 20, Amount = 20 };
            var ingredientQuantity28 = new IngredientQuantity { Id = 28, RecipeId = 3, IngredientId = 12, Quantity = "1/3 cup", Amount = null };
            var ingredientQuantity29 = new IngredientQuantity { Id = 29, RecipeId = 3, IngredientId = 30, Quantity = "1 teaspoon", Amount = null };
            var ingredientQuantity30 = new IngredientQuantity { Id = 30, RecipeId = 3, IngredientId = 31, Quantity = "1/2 teaspoon", Amount = null };
            var ingredientQuantity31 = new IngredientQuantity { Id = 31, RecipeId = 3, IngredientId = 32, Quantity = "10 medium", Amount = null };
            var ingredientQuantity32 = new IngredientQuantity { Id = 32, RecipeId = 3, IngredientId = 33, Quantity = "2 teaspoons", Amount = null };
            var ingredientQuantity33 = new IngredientQuantity { Id = 33, RecipeId = 3, IngredientId = 9, Quantity = "1, lightly beaten", Amount = null };               
            var ingredientQuantity34 = new IngredientQuantity { Id = 34, RecipeId = 4, IngredientId = 34, Amount = 150 };
            var ingredientQuantity35 = new IngredientQuantity { Id = 35, RecipeId = 4, IngredientId = 20, Amount = 50 };
            var ingredientQuantity36 = new IngredientQuantity { Id = 36, RecipeId = 4, IngredientId = 35, Quantity = "1 tablespoon", Amount = null };
            var ingredientQuantity37 = new IngredientQuantity { Id = 37, RecipeId = 4, IngredientId = 36, Amount = 50 };
            var ingredientQuantity38 = new IngredientQuantity { Id = 38, RecipeId = 4, IngredientId = 25, Amount = 25 };
            var ingredientQuantity39 = new IngredientQuantity { Id = 39, RecipeId = 4, IngredientId = 12, Quantity = "2 cups", Amount = null };
            var ingredientQuantity40 = new IngredientQuantity { Id = 40, RecipeId = 4, IngredientId = 10, Quantity = "1 teaspoon", Amount = null };
            var ingredientQuantity41 = new IngredientQuantity { Id = 41, RecipeId = 4, IngredientId = 13, Quantity = "1/2 teaspoon", Amount = null };
            var ingredientQuantity42 = new IngredientQuantity { Id = 42, RecipeId = 5, IngredientId = 37, Quantity = "1/4 cup", Amount = null };
            var ingredientQuantity43 = new IngredientQuantity { Id = 43, RecipeId = 5, IngredientId = 21, Quantity = "2 cloves, finely chopped", Amount = null };     
            var ingredientQuantity44 = new IngredientQuantity { Id = 44, RecipeId = 5, IngredientId = 38, Quantity = "2 teaspoons", Amount = null };
            var ingredientQuantity45 = new IngredientQuantity { Id = 45, RecipeId = 5, IngredientId = 4, Quantity = "150 mL", Amount = null };
            var ingredientQuantity46 = new IngredientQuantity { Id = 46, RecipeId = 5, IngredientId = 39, Quantity = "1 bunch", Amount = null };
            var ingredientQuantity47 = new IngredientQuantity { Id = 47, RecipeId = 5, IngredientId = 40, Amount = 50 };
            var ingredientQuantity48 = new IngredientQuantity { Id = 48, RecipeId = 5, IngredientId = 41, Amount = 250 };
            var ingredientQuantity49 = new IngredientQuantity { Id = 49, RecipeId = 5, IngredientId = 42, Quantity = "1 bunch, peeled", Amount = null };               
            var ingredientQuantity50 = new IngredientQuantity { Id = 50, RecipeId = 5, IngredientId = 43, Quantity = "1 bunch", Amount = null };
            var ingredientQuantity51 = new IngredientQuantity { Id = 51, RecipeId = 6, IngredientId = 44, Quantity = "2 teaspoons", Amount = null };
            var ingredientQuantity52 = new IngredientQuantity { Id = 52, RecipeId = 6, IngredientId = 45, Quantity = "1 small, chopped", Amount = null };               
            var ingredientQuantity53 = new IngredientQuantity { Id = 53, RecipeId = 6, IngredientId = 46, Quantity = "3 teaspoons", Amount = null };
            var ingredientQuantity54 = new IngredientQuantity { Id = 54, RecipeId = 6, IngredientId = 47, Amount = 750 };
            var ingredientQuantity55 = new IngredientQuantity { Id = 55, RecipeId = 6, IngredientId = 48, Quantity = "2 teaspoons", Amount = null };
            var ingredientQuantity56 = new IngredientQuantity { Id = 56, RecipeId = 6, IngredientId = 10, Quantity = "1 teaspoon", Amount = null };
            var ingredientQuantity57 = new IngredientQuantity { Id = 57, RecipeId = 6, IngredientId = 28, Quantity = "1 teaspoon", Amount = null };
            var ingredientQuantity58 = new IngredientQuantity { Id = 58, RecipeId = 6, IngredientId = 49, Quantity = "2 cups", Amount = null };
            var ingredientQuantity59 = new IngredientQuantity { Id = 59, RecipeId = 6, IngredientId = 50, Quantity = "1/2 cup", Amount = null };
            var ingredientQuantity60 = new IngredientQuantity { Id = 60, RecipeId = 6, IngredientId = 51, Quantity = "1 tablespoon, toasted", Amount = null };     
            var ingredientQuantity61 = new IngredientQuantity { Id = 61, RecipeId = 6, IngredientId = 52, Quantity = "to taste", Amount = null };
            var ingredientQuantity62 = new IngredientQuantity { Id = 62, RecipeId = 7, IngredientId = 53, Quantity = "3 oz", Amount = null };
            var ingredientQuantity63 = new IngredientQuantity { Id = 63, RecipeId = 7, IngredientId = 54, Quantity = "1 oz", Amount = null };
            var ingredientQuantity64 = new IngredientQuantity { Id = 64, RecipeId = 7, IngredientId = 55, Quantity = "1/2 oz", Amount = null };
            var ingredientQuantity65 = new IngredientQuantity { Id = 65, RecipeId = 7, IngredientId = 56, Quantity = "1 peel", Amount = null };

            context.IngredientQuantities.AddOrUpdate(new IngredientQuantity[]
            {
                ingredientQuantity1,
                ingredientQuantity2,
                ingredientQuantity3,
                ingredientQuantity4,
                ingredientQuantity5,
                ingredientQuantity6,
                ingredientQuantity7,
                ingredientQuantity8,
                ingredientQuantity9,
                ingredientQuantity10,
                ingredientQuantity11,
                ingredientQuantity12,
                ingredientQuantity13,
                ingredientQuantity14,
                ingredientQuantity15,
                ingredientQuantity16,
                ingredientQuantity17,
                ingredientQuantity18,
                ingredientQuantity19,
                ingredientQuantity20,
                ingredientQuantity21,
                ingredientQuantity22,
                ingredientQuantity23,
                ingredientQuantity24,
                ingredientQuantity25,
                ingredientQuantity26,
                ingredientQuantity27,
                ingredientQuantity28,
                ingredientQuantity29,
                ingredientQuantity30,
                ingredientQuantity31,
                ingredientQuantity32,
                ingredientQuantity33,
                ingredientQuantity34,
                ingredientQuantity35,
                ingredientQuantity36,
                ingredientQuantity37,
                ingredientQuantity38,
                ingredientQuantity39,
                ingredientQuantity40,
                ingredientQuantity41,
                ingredientQuantity42,
                ingredientQuantity43,
                ingredientQuantity44,
                ingredientQuantity45,
                ingredientQuantity46,
                ingredientQuantity47,
                ingredientQuantity48,
                ingredientQuantity49,
                ingredientQuantity50,
                ingredientQuantity51,
                ingredientQuantity52,
                ingredientQuantity53,
                ingredientQuantity54,
                ingredientQuantity55,
                ingredientQuantity56,
                ingredientQuantity57,
                ingredientQuantity58,
                ingredientQuantity59,
                ingredientQuantity60,
                ingredientQuantity61,
                ingredientQuantity62,
                ingredientQuantity63,
                ingredientQuantity64,
                ingredientQuantity65
            });

            // INGREDIENT QUANTITY 1
            ingredientQuantity1.Id = 1;
            ingredientQuantity1.RecipeId = 1;
            ingredientQuantity1.IngredientId = 12;

            ingredientQuantity2.Id = 2;
            ingredientQuantity2.RecipeId = 1;
            ingredientQuantity2.IngredientId = 14;

            ingredientQuantity3.Id = 3;
            ingredientQuantity3.RecipeId = 1;
            ingredientQuantity3.IngredientId = 13;

            ingredientQuantity4.Id = 4;
            ingredientQuantity4.RecipeId = 1;
            ingredientQuantity4.IngredientId = 10;

            ingredientQuantity5.Id = 5;
            ingredientQuantity5.RecipeId = 1;
            ingredientQuantity5.IngredientId = 11;

            ingredientQuantity6.Id = 6;
            ingredientQuantity6.RecipeId = 1;
            ingredientQuantity6.IngredientId = 15;

            ingredientQuantity7.Id = 7;
            ingredientQuantity7.RecipeId = 1;
            ingredientQuantity7.IngredientId = 16;

            ingredientQuantity8.Id = 8;
            ingredientQuantity8.RecipeId = 1;
            ingredientQuantity8.IngredientId = 3;

            ingredientQuantity9.Id = 9;
            ingredientQuantity9.RecipeId = 1;
            ingredientQuantity9.IngredientId = 7;

            ingredientQuantity10.Id = 10;
            ingredientQuantity10.RecipeId = 1;
            ingredientQuantity10.IngredientId = 4;

            // INGREDIENT QUANTITY 2
            ingredientQuantity11.Id = 11;
            ingredientQuantity11.RecipeId = 2;
            ingredientQuantity11.IngredientId = 17;

            ingredientQuantity12.Id = 12;
            ingredientQuantity12.RecipeId = 2;
            ingredientQuantity12.IngredientId = 4;

            ingredientQuantity13.Id = 13;
            ingredientQuantity13.RecipeId = 2;
            ingredientQuantity13.IngredientId = 18;

            ingredientQuantity14.Id = 14;
            ingredientQuantity14.RecipeId = 2;
            ingredientQuantity14.IngredientId = 19;

            ingredientQuantity15.Id = 15;
            ingredientQuantity15.RecipeId = 2;
            ingredientQuantity15.IngredientId = 20;

            ingredientQuantity16.Id = 16;
            ingredientQuantity16.RecipeId = 2;
            ingredientQuantity16.IngredientId = 21;

            ingredientQuantity18.Id = 18;
            ingredientQuantity18.RecipeId = 2;
            ingredientQuantity18.IngredientId = 10;

            ingredientQuantity19.Id = 19;
            ingredientQuantity19.RecipeId = 2;
            ingredientQuantity19.IngredientId = 11;

            ingredientQuantity20.Id = 20;
            ingredientQuantity20.RecipeId = 2;
            ingredientQuantity20.IngredientId = 23;

            ingredientQuantity21.Id = 21;
            ingredientQuantity21.RecipeId = 2;
            ingredientQuantity21.IngredientId = 24;

            ingredientQuantity22.Id = 22;
            ingredientQuantity22.RecipeId = 2;
            ingredientQuantity22.IngredientId = 25;

            ingredientQuantity23.Id = 23;
            ingredientQuantity23.RecipeId = 2;
            ingredientQuantity23.IngredientId = 26;

            // INGREDIENT QUANTITY 3
            ingredientQuantity24.Id = 24;
            ingredientQuantity24.RecipeId = 3;
            ingredientQuantity24.IngredientId = 27;

            ingredientQuantity25.Id = 25;
            ingredientQuantity25.RecipeId = 3;
            ingredientQuantity25.IngredientId = 28;

            ingredientQuantity26.Id = 26;
            ingredientQuantity26.RecipeId = 3;
            ingredientQuantity26.IngredientId = 29;

            ingredientQuantity27.Id = 27;
            ingredientQuantity27.RecipeId = 3;
            ingredientQuantity27.IngredientId = 20;

            ingredientQuantity28.Id = 28;
            ingredientQuantity28.RecipeId = 3;
            ingredientQuantity28.IngredientId = 12;

            ingredientQuantity29.Id = 29;
            ingredientQuantity29.RecipeId = 3;
            ingredientQuantity29.IngredientId = 30;

            ingredientQuantity30.Id = 30;
            ingredientQuantity30.RecipeId = 3;
            ingredientQuantity30.IngredientId = 31;

            ingredientQuantity31.Id = 31;
            ingredientQuantity31.RecipeId = 3;
            ingredientQuantity31.IngredientId = 32;

            ingredientQuantity32.Id = 32;
            ingredientQuantity32.RecipeId = 3;
            ingredientQuantity32.IngredientId = 33;

            ingredientQuantity33.Id = 33;
            ingredientQuantity33.RecipeId = 3;
            ingredientQuantity33.IngredientId = 9;

            // INGREDIENT QUANTITY 4
            ingredientQuantity34.Id = 34;
            ingredientQuantity34.RecipeId = 4;
            ingredientQuantity34.IngredientId = 34;

            ingredientQuantity35.Id = 35;
            ingredientQuantity35.RecipeId = 4;
            ingredientQuantity35.IngredientId = 20;

            ingredientQuantity36.Id = 36;
            ingredientQuantity36.RecipeId = 4;
            ingredientQuantity36.IngredientId = 35;

            ingredientQuantity37.Id = 37;
            ingredientQuantity37.RecipeId = 4;
            ingredientQuantity37.IngredientId = 36;

            ingredientQuantity38.Id = 38;
            ingredientQuantity38.RecipeId = 4;
            ingredientQuantity38.IngredientId = 25;

            ingredientQuantity39.Id = 39;
            ingredientQuantity39.RecipeId = 4;
            ingredientQuantity39.IngredientId = 12;

            ingredientQuantity40.Id = 40;
            ingredientQuantity40.RecipeId = 4;
            ingredientQuantity40.IngredientId = 10;

            ingredientQuantity41.Id = 41;
            ingredientQuantity41.RecipeId = 4;
            ingredientQuantity41.IngredientId = 13;

            // INGREDIENT QUANTITY 5
            ingredientQuantity42.Id = 42;
            ingredientQuantity42.RecipeId = 5;
            ingredientQuantity42.IngredientId = 37;

            ingredientQuantity43.Id = 43;
            ingredientQuantity43.RecipeId = 5;
            ingredientQuantity43.IngredientId = 21;

            ingredientQuantity44.Id = 44;
            ingredientQuantity44.RecipeId = 5;
            ingredientQuantity44.IngredientId = 45;

            ingredientQuantity45.Id = 45;
            ingredientQuantity45.RecipeId = 5;
            ingredientQuantity45.IngredientId = 4;

            ingredientQuantity46.Id = 46;
            ingredientQuantity46.RecipeId = 5;
            ingredientQuantity46.IngredientId = 39;

            ingredientQuantity47.Id = 47;
            ingredientQuantity47.RecipeId = 5;
            ingredientQuantity47.IngredientId = 40;

            ingredientQuantity48.Id = 48;
            ingredientQuantity48.RecipeId = 5;
            ingredientQuantity48.IngredientId = 41;

            ingredientQuantity49.Id = 49;
            ingredientQuantity49.RecipeId = 5;
            ingredientQuantity49.IngredientId = 42;

            ingredientQuantity50.Id = 50;
            ingredientQuantity50.RecipeId = 5;
            ingredientQuantity50.IngredientId = 43;

            // INGREDIENT QUANTITY 6
            ingredientQuantity51.Id = 51;
            ingredientQuantity51.RecipeId = 6;
            ingredientQuantity51.IngredientId = 44;

            ingredientQuantity52.Id = 52;
            ingredientQuantity52.RecipeId = 6;
            ingredientQuantity52.IngredientId = 45;

            ingredientQuantity53.Id = 53;
            ingredientQuantity53.RecipeId = 6;
            ingredientQuantity53.IngredientId = 46;

            ingredientQuantity54.Id = 54;
            ingredientQuantity54.RecipeId = 6;
            ingredientQuantity54.IngredientId = 47;

            ingredientQuantity55.Id = 55;
            ingredientQuantity55.RecipeId = 6;
            ingredientQuantity55.IngredientId = 48;

            ingredientQuantity56.Id = 56;
            ingredientQuantity56.RecipeId = 6;
            ingredientQuantity56.IngredientId = 10;

            ingredientQuantity57.Id = 57;
            ingredientQuantity57.RecipeId = 6;
            ingredientQuantity57.IngredientId = 28;

            ingredientQuantity58.Id = 58;
            ingredientQuantity58.RecipeId = 6;
            ingredientQuantity58.IngredientId = 49;

            ingredientQuantity59.Id = 59;
            ingredientQuantity59.RecipeId = 6;
            ingredientQuantity59.IngredientId = 50;

            ingredientQuantity60.Id = 60;
            ingredientQuantity60.RecipeId = 6;
            ingredientQuantity60.IngredientId = 51;

            ingredientQuantity61.Id = 61;
            ingredientQuantity61.RecipeId = 6;
            ingredientQuantity61.IngredientId = 52;

            // INGREDIENT QUANTITY 7
            ingredientQuantity62.Id = 62;
            ingredientQuantity62.RecipeId = 7;
            ingredientQuantity62.IngredientId = 53;

            ingredientQuantity63.Id = 63;
            ingredientQuantity63.RecipeId = 7;
            ingredientQuantity63.IngredientId = 54;

            ingredientQuantity64.Id = 64;
            ingredientQuantity64.RecipeId = 7;
            ingredientQuantity64.IngredientId = 55;

            ingredientQuantity65.Id = 65;
            ingredientQuantity65.RecipeId = 7;
            ingredientQuantity65.IngredientId = 56;

            // METHODS
            recipe1.Method =
                @"1 - In a large, roomy bowl, mix all but 2 tablespoons of the flour (set aside) with the cornstarch and baking powder. Season lightly with a tiny pinch of salt and pepper.
2 - Using a fork to whisk continuously, add the beer and the sparkling water to the flour mixture and continue mixing until you have a thick, smooth batter. Place the batter in the fridge to rest for between 30 minutes and an hour.
3 - Meanwhile, cut the potatoes into 1-centimeter slices (a little less than a half an inch), then slice these into 1-centimeter-wide chips. Place the chips into a colander and rinse under cold running water.
4 - Place the washed chips into a pan of cold water. Bring to a gentle boil and simmer for 3 to 4 minutes.
5 - Drain carefully through a colander then dry with kitchen paper. Keep in the fridge covered with kitchen paper until needed.
6 - Meanwhile, lay the fish fillets on a sheet of kitchen paper and pat dry. Season lightly with a little sea salt.
7 - Heat the oil to 350 F in a deep-fat fryer or large, deep saucepan. Cook the chips a few handfuls at a time in the fat for about 2 minutes. Do not brown them. Once the chips are slightly cooked, remove them from the fat and drain. Keep to one side.
8 - Place the 2 tablespoons of flour reserved from the batter mix into a shallow bowl. Toss each fish fillet in the flour and shake off any excess.
9 - Dip into the batter, coating the entire fillet.
10 - Check that the oil temperature is still 350 F. Carefully lower each fillet into the hot oil. Fry for approximately 8 minutes, or until the batter is crisp and golden, turning the fillets from time to time with a large slotted spoon.
11 - Once cooked, remove the fillets from the hot oil and drain on kitchen paper. Sprinkle with salt. Cover with greaseproof paper and keep hot.
12 - Heat the oil to 400 F then cook the chips until golden and crisp, or about 5 minutes. Remove from the oil and drain. Season with salt.
13 - Serve immediately with the hot fish accompanied by your favorite condiment.
                ";

            recipe2.Method =
                @"1 - Add the stock to a medium pot and bring to a boil over high heat. Once the stock is boiling, reduce the heat to low or remove the pan from the heat and keep nearby.
2 - Heat the olive oil in a wide, tall pot over medium heat. Once the oil begins to shimmer, add the shallot and cook, stirring frequently, until translucent.
3 - Add the shiitake mushrooms and butter. Cook, stirring occasionally, until the mushrooms have cooked down.
4 - Add the garlic, thyme, salt, and pepper, stir, and cook for 1 minute, until the butter has melted and the garlic is aromatic.
5 - Add the rice and stir until fully coated in the mushroom mixture. Let the rice toast for 1-2 minutes, until fragrant.
6 - Add the white wine and cook until the wine has evaporated, stirring occasionally.
7 - Add 1 cup (240 ml) of the hot stock and stir to combine. Cook, stirring frequently, until the stock is fully absorbed.
8 - Continue to add the stock, ½ cup (120 ml) at a time, stirring continuously, until the broth is fully absorbed, for 15-20 minutes. Depending on how fast the rice cooks, there may be leftover stock.
9 - Once the rice is al dente, remove from the heat. Add the Parmesan and stir to combine.
10 - Top with parsley, Parmesan, salt, and pepper.
11 - Enjoy!
                ";

            recipe3.Method =
                 @"1 - Grease a 20cm springform pan. Cut 1 sheet of pastry into 4 strips, lengthways. Place a strip along each edge of second pastry sheet, pressing lightly to join to make one large square. Ease prepared pastry into pan, pressing into base. Trim edges. Prick pastry with fork and chill for 30 mins.
2 - Meanwhile, place brown sugar, syrup and butter in a large saucepan. Stir on low until melted and smooth. Simmer for 2 mins. Place flour and spices in a large bowl. Add apple, toss to coat. Add to syrup. Stir to coat. Simmer for 20 mins stirring occasionally until apples are just tender.
3 - Preheat oven to 180°C or 160°C fan. Line shell with non-stick baking paper. Fill with rice. Blind bake for 15 mins. Remove rice and paper, bake for 5 mins.
4 - Spoon apples into pastry shell. Using a 4cm round cutter, cut about 30 rounds from remaining pastry. Starting from the outside edge of the pie, arrange rounds, overlapping slightly over apple filling. Brush pastry lightly with beaten egg and sprinkle over caster sugar. Bake for 30-40 mins until golden and crisp. Serve apple pie in wedges with ice cream.
                ";

            recipe4.Method =
                @"1 - Simmer the pumpkin in lightly salted water until just tender. Drain and cool. Pre-heat an oven to 180C.
2 - Combine the butter, pumpkin and salt in a mixer until creamy. Fold in the buttermilk.
3 - Fold in the remaining ingredients until just combined. The mixture should be moist. Over mixing will spoil the scones.
4 - Turn the dough onto a lightly floured bench and press the dough out to an even 3-4cm height. Dust a round cutter in flour and cut out the scones.
5 - Arrange on a lined baking tray with a space between each.
6 - Bake for 20 minutes. A skewer should come out dry when testing.
7 - Serve hot with butter or cool them and serve cold in lunch boxes or for after-school treats.
                ";

            recipe5.Method =
                 @"1 - Whisk together vinegar, garlic, mustard and oil, then season. Combine watercress, rocket, tomato, carrot and radish in a bowl.
2 - Add dressing and toss to combine. Top with edible flowers, if using, then serve.
                ";

            recipe6.Method =
                @"1 - Heat the oil in a large saucepan over medium heat. Add the onion and cook, stirring, for 5 mins or until onion softens. Add the curry paste. Cook, stirring, for 1 min or until aromatic.
2 - Add the sweet potato, lemongrass and 1 1/2 cups (375ml) water and bring to the boil. Reduce heat to low and simmer, covered, for 15 mins or until the sweet potato is tender.
3 - Add the salt, sugar, soy milk and coconut milk. Set aside to cool slightly. Blend or process soup, in batches, until smooth.
4 - Return soup to saucepan and stir over low heat until heated through (do not boil). Ladle among serving bowls and sprinkle with the sesame seeds and coriander. Season.
                ";

            recipe7.Method =
                @"1 - Add all the ingredients into a mixing glass with ice and stir (or, if preparing the Bond way, shake).
2 - Strain into a chilled cocktail glass.
3 - Twist a slice of lemon peel over the drink, rub along the rim of the glass, and drop it in.
                ";

            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var validationEx in e.EntityValidationErrors)
                {
                    Console.WriteLine(
                        $"Validation exception in {validationEx.Entry.Entity.GetType().Name} with state {validationEx.Entry.State}:\n"
                        );

                    foreach (var ve in validationEx.ValidationErrors)
                    {
                        Console.WriteLine($"Property: {ve.PropertyName}, Message: {ve.ErrorMessage}");
                    }
                }
            }
        }
    }
}
