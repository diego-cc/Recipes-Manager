namespace RecipesData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        Method = c.String(unicode: false, storeType: "text"),
                        Serves = c.Int(nullable: false),
                        PreparationTime = c.Int(),
                        KcalPerServe = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.IngredientQuantities",
                c => new
                    {
                        IngredientId = c.Int(nullable: false),
                        RecipeId = c.Int(nullable: false),
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.String(),
                        Amount = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ingredients", t => t.IngredientId, cascadeDelete: true)
                .ForeignKey("dbo.Recipes", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.IngredientId, unique: true)
                .Index(t => t.RecipeId, unique: true);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IngredientQuantities", "RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.IngredientQuantities", "IngredientId", "dbo.Ingredients");
            DropForeignKey("dbo.Recipes", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Ingredients", new[] { "Name" });
            DropIndex("dbo.IngredientQuantities", new[] { "RecipeId" });
            DropIndex("dbo.IngredientQuantities", new[] { "IngredientId" });
            DropIndex("dbo.Recipes", new[] { "Name" });
            DropIndex("dbo.Recipes", new[] { "CategoryId" });
            DropIndex("dbo.Categories", new[] { "Name" });
            DropTable("dbo.Ingredients");
            DropTable("dbo.IngredientQuantities");
            DropTable("dbo.Recipes");
            DropTable("dbo.Categories");
        }
    }
}
