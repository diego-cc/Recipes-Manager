﻿using RecipesData.Setup;
using RecipesManager.Commands;
using RecipesManager.Models;
using RecipesManager.ViewModels.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using RecipesManager.Views;

namespace RecipesManager.ViewModels
{
    /// <summary>
    /// ViewModel for <see cref="RecipesView"/>
    /// </summary>
    class RecipesViewModel : IViewRecipesViewModel, INotifyPropertyChanged
    {
        #region Properties
        private readonly IDbManager dbManager;

        private ObservableCollection<Recipe> items;

        public ObservableCollection<Recipe> Items
        {
            get
            {
                if (items == null)
                {
                    items = new ObservableCollection<Recipe>();
                }

                FilteredItems = new ObservableCollection<Recipe>(items);

                return items;
            }
            set
            {
                items = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Recipe> filteredItems;

        public ObservableCollection<Recipe> FilteredItems
        {
            get
            {
                if (filteredItems == null)
                {
                    filteredItems = new ObservableCollection<Recipe>();
                }

                return filteredItems;
            }
            set
            {
                filteredItems = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Category> categories;
        public ObservableCollection<Category> Categories
        {
            get => categories;
            set
            {
                categories = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<IngredientQuantity> ingredientQuantities;
        public ObservableCollection<IngredientQuantity> IngredientQuantities
        {
            get => ingredientQuantities;
            set
            {
                ingredientQuantities = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<IngredientQuantity> selectedIQ;

        public ObservableCollection<IngredientQuantity> SelectedIngredientQuantities
        {
            get
            {
                if (selectedIQ == null)
                {
                    selectedIQ = new ObservableCollection<IngredientQuantity>();
                }
                return selectedIQ;
            }
            set
            {
                selectedIQ = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<string> sortOptions;

        public ObservableCollection<string> SortOptions
        {
            get => sortOptions;
            set
            {
                sortOptions = value;
                OnPropertyChanged();
            }
        }

        private string selectedSortOption;

        /// <summary>
        /// Maps sort options to properties
        /// </summary>
        public string SelectedSortOption
        {
            get
            {
                TextInfo textInfo = new CultureInfo("en-AU", false).TextInfo;

                if (selectedSortOption == "Favourite")
                {
                    FilteredItems = new ObservableCollection<Recipe>(FilteredItems.OrderByDescending(r => r.Favourite));
                }
                else
                {
                    FilteredItems = new ObservableCollection<Recipe>(FilteredItems.OrderBy(r =>
                    {
                        string propToPascalCase = textInfo.ToTitleCase(selectedSortOption.Trim().ToLower()).Replace(" ", "");

                        if (propToPascalCase == "Category")
                        {
                            return r.Category.Name;
                        }

                        return r.GetType().GetProperty(propToPascalCase).GetValue(r, null);
                    }));
                }

                return selectedSortOption;
            }
            set
            {
                selectedSortOption = value;
                OnPropertyChanged();
            }
        }

        private string searchName = "";

        public string SearchName
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(searchName))
                {
                    FilteredItems = new ObservableCollection<Recipe>
                        (
                            Items.Where(r => r.Name.ToLower().StartsWith(searchName.ToLower()))
                        );
                }
                else
                {
                    FilteredItems = new ObservableCollection<Recipe>(Items);
                }

                return searchName;
            }
            set
            {
                searchName = value;
                OnPropertyChanged();
            }
        }

        private Recipe selectedRecipe;

        public Recipe SelectedRecipe
        {
            get
            {
                if (selectedRecipe != null)
                {
                    SelectedIngredientQuantities = new ObservableCollection<IngredientQuantity>(
                        IngredientQuantities.Where(iq => iq.Recipe.Id == selectedRecipe.Id)
                      );
                }
                return selectedRecipe;
            }
            set
            {
                selectedRecipe = value;
                OnPropertyChanged();
            }
        }

        private Recipe newRecipe = new Recipe
        {
            Category = new Category(),
            Favourite = false
        };
            

        public Recipe NewRecipe
        {
            get => newRecipe;
            set
            {
                newRecipe = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public IDbManager DbManager
        {
            get => this.dbManager;
        }

        #region Constructor
        /// <summary>
        /// Returns an instance of <see cref="RecipesViewModel"/> after executing async tasks
        /// </summary>
        /// <param name="dbManager"></param>
        /// <returns></returns>
        public async static Task<RecipesViewModel> GetInstanceAsync(IDbManager dbManager)
        {
            var allRecipes = await dbManager.BrowseItemsAsync(typeof(RecipesData.Models.Recipe));
            var allCategories = await dbManager.BrowseItemsAsync(typeof(RecipesData.Models.Category));
            var allIngredientQuantities = await dbManager.BrowseItemsAsync(typeof(RecipesData.Models.IngredientQuantity));

            var recipes = new ObservableCollection<Recipe>
            (
                allRecipes.Select(obj =>
                {
                    var recipeEntity = (RecipesData.Models.Recipe)obj;
                    return new Recipe
                    {
                        Id = recipeEntity.Id,
                        Name = recipeEntity.Name,
                        CategoryId = recipeEntity.CategoryId,
                        PreparationTime = recipeEntity.PreparationTime,
                        Serves = recipeEntity.Serves,
                        KcalPerServe = recipeEntity.KcalPerServe,
                        Method = recipeEntity.Method,
                        Category = new Category
                        {
                            Id = recipeEntity.CategoryId,
                            Name = recipeEntity.Category.Name
                        },
                        Favourite = recipeEntity.Favourite
                    };
                })
            );

            var categories = new ObservableCollection<Category>
           (
               allCategories.Select(obj =>
               {
                   var categoryEntity = (RecipesData.Models.Category)obj;

                   return new Category
                   {
                       Id = categoryEntity.Id,
                       Name = categoryEntity.Name
                   };
               })
           );

            var ingredientQuantities = new ObservableCollection<IngredientQuantity>
            (
                allIngredientQuantities.Select(obj =>
                {
                    var iqEntity = (RecipesData.Models.IngredientQuantity)obj;

                    return new IngredientQuantity
                    {
                        Id = iqEntity.Id,
                        Ingredient = new Ingredient
                        {
                            Id = iqEntity.Ingredient.Id,
                            Name = iqEntity.Ingredient.Name
                        },
                        Recipe = new Recipe
                        {
                            Id = iqEntity.Recipe.Id,
                            Name = iqEntity.Recipe.Name
                        },
                        Quantity = iqEntity.Quantity,
                        Amount = iqEntity.Amount
                    };
                })
            );

            return new RecipesViewModel(dbManager, recipes, categories, ingredientQuantities);
        }

        private RecipesViewModel(IDbManager dbManager, ObservableCollection<Recipe> recipes, ObservableCollection<Category> categories, ObservableCollection<IngredientQuantity> ingredientQuantities)
        {
            this.dbManager = dbManager;
            this.Items = recipes;
            this.Categories = categories;
            this.IngredientQuantities = ingredientQuantities;

            FilteredItems = new ObservableCollection<Recipe>(Items);

            SortOptions = new ObservableCollection<string> { "ID", "Name", "Category", "Favourite", "Preparation time", "Serves", "Kcal per serve" };
            SelectedSortOption = SortOptions[0];

            AddRecipeCommand = new RelayCommand(AddRecipe);
            DeleteRecipeCommand = new RelayCommand(DeleteRecipe);
            UpdateRecipeCommand = new RelayCommand(UpdateRecipe);
            RestoreRecipeCommand = new RelayCommand(RestoreRecipe);
            ClearRecipeCommand = new RelayCommand(ClearRecipe);
            ClearSearchCommand = new RelayCommand(ClearSearch);
        }
        #endregion

        #region Command Actions
        /// <summary>
        /// Adds a new recipe to the database and updaes local collection
        /// </summary>
        /// <param name="obj"></param>
        private void AddRecipe(object obj)
        {
            // basic validation
            if (
                !string.IsNullOrWhiteSpace(NewRecipe.Name) &&
                !string.IsNullOrWhiteSpace(NewRecipe.Category.Name)
               )
            {
                // check if recipe name already exists
                if (Items.Any(r => r.Name.Trim().ToLower().Equals(NewRecipe.Name.Trim().ToLower())))
                {
                    if (MessageBox.Show("Recipe already exists. Please choose a different name.", "Invalid recipe name", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK) == MessageBoxResult.OK)
                    {
                        NewRecipe.Name = "";
                    }

                    return;
                }
                // add new recipe here
                if (this.dbManager.AddItem(new RecipesData.Models.Recipe
                {
                    Name = NewRecipe.Name,
                    CategoryId = NewRecipe.Category.Id,
                    PreparationTime = NewRecipe.PreparationTime,
                    Serves = NewRecipe.Serves,
                    KcalPerServe = NewRecipe.KcalPerServe,
                    Method = NewRecipe.Method,
                    Favourite = NewRecipe.Favourite
                }))
                {
                    if (MessageBox.Show("Recipe successfully added!", "Recipe added", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK) == MessageBoxResult.OK)
                    {
                        // get id of new recipe added to database
                        var newRecipeFromDB = this.dbManager.ReadItem(new RecipesData.Models.Recipe
                        {
                            Name = NewRecipe.Name
                        });

                        if (newRecipeFromDB != null)
                        {
                            var newRecipeData = (RecipesData.Models.Recipe)newRecipeFromDB;

                            // add to local collection
                            Items.Add(new Recipe
                            {
                                Id = newRecipeData.Id,
                                Name = newRecipeData.Name,
                                CategoryId = newRecipeData.CategoryId,
                                Category = new Category
                                {
                                    Id = newRecipeData.Category.Id,
                                    Name = newRecipeData.Category.Name
                                },
                                PreparationTime = newRecipeData.PreparationTime,
                                Serves = newRecipeData.Serves,
                                KcalPerServe = newRecipeData.KcalPerServe,
                                Method = newRecipeData.Method,
                                Favourite = newRecipeData.Favourite
                            });

                            FilteredItems = new ObservableCollection<Recipe>(Items);
                        }
                        // clear fields
                        NewRecipe = new Recipe
                        {
                            Category = new Category(),
                            Favourite = false
                        };
                    }
                }
                else
                {
                    // this case is supposed to be triggered when there is invalid input or the recipe name already exists
                    // it's not currently working though

                    if (MessageBox.Show("Could not add recipe. Ensure that all details entered are correct and the recipe name is unique.", "Failed to add recipe", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK) == MessageBoxResult.OK)
                    {
                        
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a name for the recipe.", "Invalid recipe name", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }
        }

        /// <summary>
        /// Deletes a recipe from the database and updates local collection
        /// </summary>
        /// <param name="obj"></param>
        private void DeleteRecipe(object obj)
        {
            if (SelectedRecipe != null)
            {
                if (MessageBox.Show($"Are you sure you want to delete the Recipe \"{SelectedRecipe.Name}\" (ID: {SelectedRecipe.Id})?", "Confirm delete Recipe", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                {
                    if (this.dbManager.DeleteItem(new RecipesData.Models.Recipe { Id = SelectedRecipe.Id }))
                    {
                        Items.Remove(SelectedRecipe);
                        FilteredItems.Remove(SelectedRecipe);
                    }
                }
            }
        }

        /// <summary>
        /// Updates a recipe in the database
        /// </summary>
        /// <param name="obj"></param>
        private void UpdateRecipe(object obj)
        {
            // basic validation
            if (
                !string.IsNullOrWhiteSpace(SelectedRecipe.Name) &&
                !string.IsNullOrWhiteSpace(SelectedRecipe.Category.Name)
                )
            {
                // update recipe
                if (this.dbManager.EditItem(new RecipesData.Models.Recipe
                {
                    Id = SelectedRecipe.Id,
                    Name = SelectedRecipe.Name,
                    CategoryId = SelectedRecipe.Category.Id,
                    PreparationTime = SelectedRecipe.PreparationTime,
                    Serves = SelectedRecipe.Serves,
                    KcalPerServe = SelectedRecipe.KcalPerServe,
                    Method = SelectedRecipe.Method,
                    Favourite = SelectedRecipe.Favourite
                }))
                {
                    if (MessageBox.Show("Recipe successfully updated", "Recipe updated", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK) == MessageBoxResult.OK)
                    {
                        // all good, local collection should automatically be updated as well
                    }
                }
            }
        }

        /// <summary>
        /// Restores a recipe to its original state
        /// </summary>
        /// <param name="obj"></param>
        private void RestoreRecipe(object obj)
        {
            var originalSelectedRecipe = this.dbManager.ReadItem(new RecipesData.Models.Recipe { Id = SelectedRecipe.Id });

            if (originalSelectedRecipe != null)
            {
                var originalRecipe = (RecipesData.Models.Recipe) originalSelectedRecipe;
                var originalCategory = originalRecipe.Category;

                SelectedRecipe.Name = originalRecipe.Name;
                SelectedRecipe.Category.Id = originalCategory.Id;
                SelectedRecipe.Category.Name = originalCategory.Name;
                SelectedRecipe.PreparationTime = originalRecipe.PreparationTime;
                SelectedRecipe.Serves = originalRecipe.Serves;
                SelectedRecipe.KcalPerServe = originalRecipe.KcalPerServe;
                SelectedRecipe.Method = originalRecipe.Method;
            }
        }

        /// <summary>
        /// Clears <see cref="NewRecipe"/> fields
        /// </summary>
        /// <param name="obj"></param>
        private void ClearRecipe(object obj)
        {
            // clear fields
            NewRecipe = new Recipe
            {
                Category = new Category(),
                Favourite = false
            };
        }

        /// <summary>
        /// Clears search input
        /// </summary>
        /// <param name="obj"></param>
        private void ClearSearch(object obj)
        {
            SearchName = "";
        }
        #endregion

        #region Commands
        public ICommand AddRecipeCommand { get; set; }
        public ICommand DeleteRecipeCommand { get; set; }
        public ICommand UpdateRecipeCommand { get; set; }
        public ICommand RestoreRecipeCommand { get; set; }
        public ICommand ClearRecipeCommand { get; set; }
        public ICommand ClearSearchCommand { get; set; }
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        #endregion
    }
}
