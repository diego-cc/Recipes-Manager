using RecipesData.Setup;
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
using System.Windows;
using System.Windows.Input;

namespace RecipesManager.ViewModels
{
    class RecipesViewModel : IViewRecipesViewModel, INotifyPropertyChanged
    {
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

        public ObservableCollection<Category> Categories { get; set; }
        public List<IngredientQuantity> IngredientQuantities { get; set; }

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

        public string SelectedSortOption
        {
            get
            {
                TextInfo textInfo = new CultureInfo("en-AU", false).TextInfo;

                FilteredItems = new ObservableCollection<Recipe>(FilteredItems.OrderBy(r =>
                {
                    string propToPascalCase = textInfo.ToTitleCase(selectedSortOption.Trim().ToLower()).Replace(" ", "");

                    if (propToPascalCase == "Category")
                    {
                        return r.Category.Name;
                    }

                    return r.GetType().GetProperty(propToPascalCase).GetValue(r, null);
                }));                

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
                        IngredientQuantities.FindAll(iq => iq.Recipe.Id == selectedRecipe.Id)
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
            Category = new Category()
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

        public RecipesViewModel(IDbManager dbManager)
        {
            this.dbManager = dbManager;

            var allRecipes = this.dbManager.BrowseItems(typeof(RecipesData.Models.Recipe));
            var allCategories = this.dbManager.BrowseItems(typeof(RecipesData.Models.Category));
            var allIngredientQuantities = this.dbManager.BrowseItems(typeof(RecipesData.Models.IngredientQuantity));

            Items = new ObservableCollection<Recipe>
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
                        }
                    };
                })
            );

            Categories = new ObservableCollection<Category>
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

            IngredientQuantities = new List<IngredientQuantity>
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

            FilteredItems = new ObservableCollection<Recipe>(Items);

            SortOptions = new ObservableCollection<string> { "ID", "Name", "Category", "Preparation time", "Serves", "Kcal per serve" };
            SelectedSortOption = SortOptions[0];

            AddRecipeCommand = new RelayCommand(AddRecipe);
            DeleteRecipeCommand = new RelayCommand(DeleteRecipe);
            UpdateRecipeCommand = new RelayCommand(UpdateRecipe);
            RestoreRecipeCommand = new RelayCommand(RestoreRecipe);
            ClearRecipeCommand = new RelayCommand(ClearRecipe);
            ClearSearchCommand = new RelayCommand(ClearSearch);
        }

        private void AddRecipe(object obj)
        {
            // basic validation
            if (
                !string.IsNullOrWhiteSpace(NewRecipe.Name) &&
                !string.IsNullOrWhiteSpace(NewRecipe.Category.Name)
               )
            {
                // add new recipe here
                if (this.dbManager.AddItem(new RecipesData.Models.Recipe
                {
                    Name = NewRecipe.Name,
                    CategoryId = NewRecipe.Category.Id,
                    PreparationTime = NewRecipe.PreparationTime,
                    Serves = NewRecipe.Serves,
                    KcalPerServe = NewRecipe.KcalPerServe,
                    Method = NewRecipe.Method
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
                                Method = newRecipeData.Method
                            });
                        }
                        // clear fields
                        NewRecipe = new Recipe
                        {
                            Category = new Category()
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
        }

        private void DeleteRecipe(object obj)
        {
            if (SelectedRecipe != null)
            {
                if (MessageBox.Show($"Are you sure you want to delete the Recipe \"{SelectedRecipe.Name}\" (ID: {SelectedRecipe.Id})?", "Confirm delete Recipe", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                {
                    if (this.dbManager.DeleteItem(new RecipesData.Models.Recipe { Id = SelectedRecipe.Id }))
                    {
                        Items.Remove(SelectedRecipe);
                    }
                }
            }
        }

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
                    Method = SelectedRecipe.Method
                }))
                {
                    if (MessageBox.Show("Recipe successfully updated", "Recipe updated", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK) == MessageBoxResult.OK)
                    {
                        // all good, local collection should automatically be updated as well
                    }
                }
            }
        }

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

        private void ClearRecipe(object obj)
        {
            // clear fields
            NewRecipe = new Recipe
            {
                Category = new Category()
            };
        }

        private void ClearSearch(object obj)
        {
            SearchName = "";
        }

        public ICommand AddRecipeCommand { get; set; }
        public ICommand DeleteRecipeCommand { get; set; }
        public ICommand UpdateRecipeCommand { get; set; }
        public ICommand RestoreRecipeCommand { get; set; }
        public ICommand ClearRecipeCommand { get; set; }
        public ICommand ClearSearchCommand { get; set; }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        #endregion
    }
}
