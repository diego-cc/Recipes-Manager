namespace RecipesData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedUnique : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.IngredientQuantities", new[] { "IngredientId" });
            DropIndex("dbo.IngredientQuantities", new[] { "RecipeId" });
            CreateIndex("dbo.IngredientQuantities", "IngredientId");
            CreateIndex("dbo.IngredientQuantities", "RecipeId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.IngredientQuantities", new[] { "RecipeId" });
            DropIndex("dbo.IngredientQuantities", new[] { "IngredientId" });
            CreateIndex("dbo.IngredientQuantities", "RecipeId", unique: true);
            CreateIndex("dbo.IngredientQuantities", "IngredientId", unique: true);
        }
    }
}
