namespace RecipesData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Timestamps : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.Categories", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.Categories", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Recipes", "Favourite", c => c.Boolean());
            AddColumn("dbo.Recipes", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.Recipes", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.Recipes", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.IngredientQuantities", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.IngredientQuantities", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.IngredientQuantities", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Ingredients", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.Ingredients", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.Ingredients", "DeletedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ingredients", "DeletedAt");
            DropColumn("dbo.Ingredients", "UpdatedAt");
            DropColumn("dbo.Ingredients", "CreatedAt");
            DropColumn("dbo.IngredientQuantities", "DeletedAt");
            DropColumn("dbo.IngredientQuantities", "UpdatedAt");
            DropColumn("dbo.IngredientQuantities", "CreatedAt");
            DropColumn("dbo.Recipes", "DeletedAt");
            DropColumn("dbo.Recipes", "UpdatedAt");
            DropColumn("dbo.Recipes", "CreatedAt");
            DropColumn("dbo.Recipes", "Favourite");
            DropColumn("dbo.Categories", "DeletedAt");
            DropColumn("dbo.Categories", "UpdatedAt");
            DropColumn("dbo.Categories", "CreatedAt");
        }
    }
}
