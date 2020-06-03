INSERT INTO [dbo].[Categories](Id, Name) VALUES 
(1, N'main'),
(2, N'dessert'),
(3, N'snack'),
(4, N'salad'), 
(5, N'soup'),
(6, N'drink');

INSERT INTO [dbo].[Ingredients](Id, Name) VALUES
(1, N'pork ribs'),
(2, N'chicken breast'),
(3, N'whiting'),
(4, N'olive oil'), 
(5, N'black beans'),
(6, N'short-grain rice'),
(7, N'potatoes'), 
(8, N'milk'),
(9, N'egg'),
(10, N'salt'),
(11, N'black pepper'),
(12, N'flour'),
(13, N'baking powder'),
(14, N'cornstarch'), 
(15, N'dark beer'), 
(16, N'sparkling water'),
(17, N'chicken stock'), 
(18, N'shallot'), 
(19, N'shiitake'), 
(20, N'butter'),
(21, N'garlic'), 
(22, N'thyme'),
(23, N'arborio rice'),
(24, N'white wine'),
(25, N'parmesan cheese'), 
(26, N'parsley'), 
(27, N'shortcut pastry'), 
(28, N'brown sugar'),
(29, N'golden syrup'), 
(30, N'cinnamon'), 
(31, N'nutmeg'), 
(32, N'granny smith apple'),
(33, N'caster sugar'),
(34, N'pumpkin'),
(35, N'buttermilk'),
(36, N'feta'),
(37, N'chardonnay vinegar'),
(38, N'Dijon mustard'),
(39, N'watercress'),
(40, N'rocket leaf'),
(41, N'baby heirloom tomato'),
(42, N'baby (Dutch) carrot'),
(43, N'radish'),
(44, N'canola oil'),
(45, N'brown onion'),
(46, N'red curry paste'),
(47, N'gold sweet potato'),
(48, N'lemongrass paste'),
(49, N'soy milk'),
(50, N'coconut milk'),
(51, N'sesame seed'),
(52, N'coriander'),
(53, N'gin'),
(54, N'vodka'),
(55, N'Lillet blanc apéritif'),
(56, N'lemon');

INSERT INTO [dbo].[Recipes](Id, CategoryId, Name, Serves, PreparationTime, KcalPerServe) VALUES
(1, 1, N'fish and chips', 4, 40, 479),
(2, 1, N'risotto', 4, 40, 429),
(3, 2, N'apple and butterscotch pie', 8, 105, 311),
(4, 3, N'cheesy pumpkin scones', 6, 50, NULL),
(5, 4, N'garden salad with vinaigrette', 6, 10, NULL),
(6, 5, N'thai sweet potato soup', 4, 45, NULL),
(7, 6, N'vesper martini', 1, 3, 483);

INSERT INTO [dbo].[IngredientQuantities](Id, RecipeId, IngredientId, Quantity, Amount) VALUES
(1, 1, 12, NULL, 55),
(2, 1, 14, NULL, 55),
(3, 1, 13, N'1 teaspoon', NULL),
(4, 1, 10, N'to taste', NULL),
(5, 1, 11, N'to taste', NULL),
(6, 1, 15, N'1/3 cup', NULL),
(7, 1, 16, N'1/3 cup', NULL),
(8, 1, 3, N'4 fillets', NULL),
(9, 1, 7, NULL, 900),
(10, 1, 4, N'1 litre', NULL),

(11, 2, 17, N'6 cups', NULL),
(12, 2, 4, N'2 tablespoons', NULL),
(13, 2, 18, N'1, finely chopped', NULL),
(14, 2, 19, NULL, 455),
(15, 2, 20, N'2 tablespoons', NULL),
(16, 2, 21, N'2 cloves', NULL),
(17, 2, 22, N'1 teaspoon', NULL),
(18, 2, 10, N'to taste', NULL),
(19, 2, 11, N'to taste', NULL),
(20, 2, 23, NULL, 200),
(21, 2, 24, N'1/2 cup', NULL),
(22, 2, 25, NULL, 110),
(23, 2, 26, NULL, 10),

(24, 3, 27, N'3 sheets', NULL),
(25, 3, 28, N'1/2 cup', NULL),
(26, 3, 29, N'1/3 cup', NULL),
(27, 3, 20, NULL, 20),
(28, 3, 12, N'1/3 cup', NULL),
(29, 3, 30, N'1 teaspoon', NULL),
(30, 3, 31, N'1/2 teaspoon', NULL),
(31, 3, 32, N'10 medium', NULL),
(32, 3, 33, N'2 teaspoons', NULL),
(33, 3, 9, N'1, lightly beaten', NULL),

(34, 4, 34, NULL, 150),
(35, 4, 20, NULL, 50),
(36, 4, 35, N'1 tablespoon', NULL),
(37, 4, 36, NULL, 50),
(38, 4, 25, NULL, 25),
(39, 4, 12, N'2 cups', NULL),
(40, 4, 10, N'1 teaspoon', NULL),
(41, 4, 13, N'1/2 teaspoon', NULL),

(42, 5, 37, N'1/4 cup', NULL),
(43, 5, 21, N'2 cloves, finely chopped', NULL),
(44, 5, 38, N'2 teaspoons', NULL),
(45, 5, 4, N'150 mL', NULL),
(46, 5, 39, N'1 bunch', NULL),
(47, 5, 40, NULL, 50),
(48, 5, 41, NULL, 250),
(49, 5, 42, N'1 bunch, peeled', NULL),
(50, 5, 43, N'1 bunch', NULL),

(51, 6, 44, N'2 teaspoons', NULL),
(52, 6, 45, N'1 small, chopped', NULL),
(53, 6, 46, N'3 teaspoons', NULL),
(54, 6, 47, NULL, 750),
(55, 6, 48, N'2 teaspoons', NULL),
(56, 6, 10, N'1 teaspoon', NULL),
(57, 6, 28, N'1 teaspoon', NULL),
(58, 6, 49, N'2 cups', NULL),
(59, 6, 50, N'1/2 cup', NULL),
(60, 6, 51, N'1 tablespoon, toasted', NULL),
(61, 6, 52, N'to taste', NULL),

(62, 7, 53, N'3 oz', NULL),
(63, 7, 54, N'1 oz', NULL),
(64, 7, 55, N'1/2 oz', NULL),
(65, 7, 56, N'1 peel', NULL);

 UPDATE [dbo].[Recipes]
 SET
 Method = (
	N'	
		1 - In a large, roomy bowl, mix all but 2 tablespoons of the flour (set aside) with the cornstarch and baking powder. Season lightly with a tiny pinch of salt and pepper.
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
	'
 )
 
WHERE Recipes.Name = N'fish and chips';

UPDATE [dbo].[Recipes]
SET
Method = (
	N'	
		1 - Add the stock to a medium pot and bring to a boil over high heat. Once the stock is boiling, reduce the heat to low or remove the pan from the heat and keep nearby.
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
	'
)

WHERE Recipes.Name = N'risotto';

UPDATE [dbo].[Recipes]
SET
Method = (
	N'	
		1 - Grease a 20cm springform pan. Cut 1 sheet of pastry into 4 strips, lengthways. Place a strip along each edge of second pastry sheet, pressing lightly to join to make one large square. Ease prepared pastry into pan, pressing into base. Trim edges. Prick pastry with fork and chill for 30 mins.
		2 - Meanwhile, place brown sugar, syrup and butter in a large saucepan. Stir on low until melted and smooth. Simmer for 2 mins. Place flour and spices in a large bowl. Add apple, toss to coat. Add to syrup. Stir to coat. Simmer for 20 mins stirring occasionally until apples are just tender.
		3 - Preheat oven to 180°C or 160°C fan. Line shell with non-stick baking paper. Fill with rice. Blind bake for 15 mins. Remove rice and paper, bake for 5 mins.
		4 - Spoon apples into pastry shell. Using a 4cm round cutter, cut about 30 rounds from remaining pastry. Starting from the outside edge of the pie, arrange rounds, overlapping slightly over apple filling. Brush pastry lightly with beaten egg and sprinkle over caster sugar. Bake for 30-40 mins until golden and crisp. Serve apple pie in wedges with ice cream.
	'
)

WHERE Recipes.Name = N'apple and butterscotch pie';

UPDATE [dbo].[Recipes]
SET
Method = (
	N'	
		1 - Simmer the pumpkin in lightly salted water until just tender. Drain and cool. Pre-heat an oven to 180C.
		2 - Combine the butter, pumpkin and salt in a mixer until creamy. Fold in the buttermilk.
		3 - Fold in the remaining ingredients until just combined. The mixture should be moist. Over mixing will spoil the scones.
		4 - Turn the dough onto a lightly floured bench and press the dough out to an even 3-4cm height. Dust a round cutter in flour and cut out the scones.
		5 - Arrange on a lined baking tray with a space between each.
		6 - Bake for 20 minutes. A skewer should come out dry when testing.
		7 - Serve hot with butter or cool them and serve cold in lunch boxes or for after-school treats.
	'
)

WHERE Recipes.Name = N'cheesy pumpkin scones';

UPDATE [dbo].[Recipes]
SET
Method = (
	N'	
		1 - Whisk together vinegar, garlic, mustard and oil, then season. Combine watercress, rocket, tomato, carrot and radish in a bowl.
		2 - Add dressing and toss to combine. Top with edible flowers, if using, then serve.
	'
)

WHERE Recipes.Name = N'garden salad with vinaigrette';

UPDATE [dbo].[Recipes]
SET
Method = (
	N'	
		1 - Heat the oil in a large saucepan over medium heat. Add the onion and cook, stirring, for 5 mins or until onion softens. Add the curry paste. Cook, stirring, for 1 min or until aromatic.
		2 - Add the sweet potato, lemongrass and 1 1/2 cups (375ml) water and bring to the boil. Reduce heat to low and simmer, covered, for 15 mins or until the sweet potato is tender.
		3 - Add the salt, sugar, soy milk and coconut milk. Set aside to cool slightly. Blend or process soup, in batches, until smooth.
		4 - Return soup to saucepan and stir over low heat until heated through (do not boil). Ladle among serving bowls and sprinkle with the sesame seeds and coriander. Season.
	'
)

WHERE Recipes.Name = N'thai sweet potato soup';

UPDATE [dbo].[Recipes]
SET
Method = (
	N'	
		1 - Add all the ingredients into a mixing glass with ice and stir (or, if preparing the Bond way, shake).
		2 - Strain into a chilled cocktail glass.
		3 - Twist a slice of lemon peel over the drink, rub along the rim of the glass, and drop it in.
	'
)

WHERE Recipes.Name = N'vesper martini';