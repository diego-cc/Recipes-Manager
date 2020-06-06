namespace RecipesData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Timestamps1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Recipes", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.IngredientQuantities", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Ingredients", "CreatedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ingredients", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.IngredientQuantities", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Recipes", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Categories", "CreatedAt", c => c.DateTime(nullable: false));
        }
    }
}
