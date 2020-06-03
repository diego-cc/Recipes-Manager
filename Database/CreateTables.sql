IF EXISTS (
    SELECT * FROM INFORMATION_SCHEMA.TABLES
    WHERE TABLE_NAME = 'IngredientsQuantity'
)

BEGIN
    ALTER TABLE [dbo].[IngredientsQuantity] 
        DROP CONSTRAINT IF EXISTS FK_IngredientsQuantity_Recipes, FK_IngredientsQuantity_Ingredient;
END

IF EXISTS (
    SELECT * FROM INFORMATION_SCHEMA.TABLES
    WHERE TABLE_NAME = 'Recipes'
)

BEGIN

    ALTER TABLE [dbo].[Recipes]
        DROP CONSTRAINT IF EXISTS FK_Recipes_Categories;
END

DROP TABLE IF EXISTS [dbo].[Categories];
DROP TABLE IF EXISTS [dbo].[Ingredients];
DROP TABLE IF EXISTS [dbo].[Recipes];
DROP TABLE IF EXISTS [dbo].[IngredientsQuantity];

CREATE TABLE [dbo].[Categories] (
    [Id]   INT            NOT NULL,
    [Name] NVARCHAR (128) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [CK_Categories_Name] UNIQUE NONCLUSTERED ([Name] ASC)
);

CREATE TABLE [dbo].[Ingredients] (
    [Id]   INT            NOT NULL,
    [Name] NVARCHAR (128) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [CK_Ingredients_Name] UNIQUE NONCLUSTERED ([Name] ASC)
);

CREATE TABLE [dbo].[Recipes] (
    [Id]              INT            NOT NULL,
    [CategoryId]      INT            NOT NULL,
    [Name]            NVARCHAR (128) NOT NULL,
    [Method]          TEXT           DEFAULT (N'Instructions not available for now') NULL,
    [Serves]          TINYINT        DEFAULT ((1)) NULL,
    [PreparationTime] SMALLINT       NULL,
    [KcalPerServe]    SMALLINT       NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Recipes_Categories] 
		FOREIGN KEY ([CategoryId]) 
		REFERENCES [dbo].[Categories] ([Id])
		ON DELETE CASCADE,
    CONSTRAINT [CK_Recipes_PreparationTime] CHECK ([PreparationTime]>(0)),
    CONSTRAINT [CK_Recipes_KcalPerServe] CHECK ([KcalPerServe]>(0)),
    CONSTRAINT [CK_Recipes_Serves] CHECK ([Serves]>(0))
);

CREATE TABLE [dbo].[IngredientsQuantity] (
    [RecipeId]     INT            NOT NULL,
    [IngredientId] INT            NOT NULL,
    [Quantity]     NVARCHAR (64)  NULL,
    [Amount]       DECIMAL (7, 2) NULL,
    CONSTRAINT [PK_IngredientsQuantity] PRIMARY KEY CLUSTERED ([RecipeId] ASC, [IngredientId] ASC),
    CONSTRAINT [FK_IngredientsQuantity_Recipes] 
		FOREIGN KEY ([RecipeId]) 
		REFERENCES [dbo].[Recipes] ([Id])
		ON DELETE CASCADE,
    CONSTRAINT [FK_IngredientsQuantity_Ingredient] 
		FOREIGN KEY ([IngredientId]) 
		REFERENCES [dbo].[Ingredients] ([Id])
		ON DELETE CASCADE,
    CONSTRAINT [CK_IngredientsQuantity_Amount] CHECK ([Amount]>(0)),
    CONSTRAINT [CK_IngredientsQuantity_Quantity_Amount] CHECK ([Quantity] IS NOT NULL OR [Amount] IS NOT NULL)
);