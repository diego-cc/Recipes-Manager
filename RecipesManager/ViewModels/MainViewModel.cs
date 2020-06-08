using RecipesData.Models;
using RecipesData.Setup;
using RecipesManager.Commands;
using RecipesManager.Helpers.Serialisation;
using RecipesManager.ViewModels.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Documents;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Microsoft.Win32;
using System.Windows;
using System.Collections.ObjectModel;
using System;
using System.Threading.Tasks;
using RecipesManager.Views;

namespace RecipesManager.ViewModels
{
    /// <summary>
    /// ViewModel for <see cref="MainView"/>
    /// Updates the content of <see cref="MainView"/> dependending on <see cref="SelectedViewModel"/>
    /// </summary>
    class MainViewModel : IViewMainViewModel, INotifyPropertyChanged
    {
        private IDbManager dbManager;
        private IViewModel selectedViewModel;

        public ICommand MenuCommand { get; set; }
        public ICommand CategoriesCommand { get; set; }
        public ICommand IngredientsCommand { get; set; }
        // public ICommand RecipesCommand { get; set; }
        public IAsyncCommand RecipesCommand { get; set; }
        public ICommand IngredientQuantitiesCommand { get; set; }
        public ICommand ImportCommand { get; set; }
        public ICommand ExportCommand { get; set; }
        public ICommand AboutCommand { get; set; }
        public ICommand TutorialCommand { get; set; }

        public IViewModel SelectedViewModel
        {
            get => selectedViewModel;
            set
            {
                this.selectedViewModel = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel(IDbManager dbManager)
        {
            this.dbManager = dbManager;

            MenuCommand = new RelayCommand(OpenMenu);
            CategoriesCommand = new RelayCommand(OpenCategories);
            IngredientsCommand = new RelayCommand(OpenIngredients);
            // RecipesCommand = new RelayCommand(OpenRecipes);
            RecipesCommand = new RelayCommandAsync(OpenRecipes);
            IngredientQuantitiesCommand = new RelayCommand(OpenIngredientQuantities);
            ImportCommand = new RelayCommand(Import);
            ExportCommand = new RelayCommand(Export);
            AboutCommand = new RelayCommand(OpenAbout);
            TutorialCommand = new RelayCommand(OpenTutorial);

            SelectedViewModel = new MenuViewModel(this.dbManager, this);
        }

        public MainViewModel()
        {

        }

        /// <summary>
        /// Shows <see cref="MenuView"/>
        /// </summary>
        /// <param name="obj"></param>
        public void OpenMenu(object obj)
        {
            SelectedViewModel = new MenuViewModel(this.dbManager, this);
        }

        /// <summary>
        /// Shows <see cref="CategoriesView"/>
        /// </summary>
        /// <param name="obj"></param>
        public void OpenCategories(object obj)
        {
            SelectedViewModel = new CategoriesViewModel(this.dbManager);
        }

        /// <summary>
        /// Shows <see cref="IngredientsView"/>
        /// </summary>
        /// <param name="obj"></param>
        public void OpenIngredients(object obj)
        {
            SelectedViewModel = new IngredientsViewModel(this.dbManager);
        }

        /// <summary>
        /// Shows <see cref="RecipesView"/>
        /// </summary>
        /// <returns></returns>
        public async Task OpenRecipes()
        {
            var recipesVM = await RecipesViewModel.GetInstanceAsync(this.dbManager);
            SelectedViewModel = recipesVM;
        }

        /// <summary>
        /// Shows <see cref="IngredientQuantitiesView"/>
        /// </summary>
        /// <param name="obj"></param>
        public void OpenIngredientQuantities(object obj)
        {
            SelectedViewModel = new IngredientQuantitiesViewModel(this.dbManager);
        }

        /// <summary>
        /// Shows <see cref="AboutView"/>
        /// </summary>
        /// <param name="obj"></param>
        public void OpenAbout(object obj)
        {
            SelectedViewModel = new AboutViewModel();
        }

        public void OpenTutorial(object obj)
        {
            SelectedViewModel = new TutorialViewModel(this.dbManager, this);
        }

        /// <summary>
        /// Exports data to a binary file
        /// <para>Triggered by the "Export data as binary" menu button</para>
        /// </summary>
        /// <param name="obj"></param>
        public void Export(object obj)
        {
            var recipesData = this.dbManager.BrowseItems(typeof(RecipesData.Models.Recipe));

            List<Models.Recipe> recipes = new List<Models.Recipe>
                (
                    recipesData.Select(data =>
                    {
                        var recipeData = (RecipesData.Models.Recipe)data;
                        return new Models.Recipe
                        {
                            Id = recipeData.Id,
                            Name = recipeData.Name,
                            Serves = recipeData.Serves,
                            PreparationTime = recipeData.PreparationTime,
                            KcalPerServe = recipeData.KcalPerServe,
                            Method = recipeData.Method,
                            Favourite = recipeData.Favourite,
                            CategoryId = recipeData.CategoryId,
                            Category = new Models.Category
                            {
                                Id = recipeData.CategoryId,
                                Name = recipeData.Category.Name
                            }
                        };
                    })
                );

            var iqsData = this.dbManager.BrowseItems(typeof(RecipesData.Models.IngredientQuantity));

            List<Models.IngredientQuantity> iq = new List<Models.IngredientQuantity>
                (
                    iqsData.Select(data =>
                    {
                        var iqData = (RecipesData.Models.IngredientQuantity)data;

                        return new Models.IngredientQuantity
                        {
                            Id = iqData.Id,
                            Amount = iqData.Amount,
                            Quantity = iqData.Quantity,
                            RecipeId = iqData.RecipeId,
                            IngredientId = iqData.IngredientId,
                            Recipe = new Models.Recipe
                            {
                                Id = iqData.Recipe.Id,
                                Name = iqData.Recipe.Name
                            },
                            Ingredient = new Models.Ingredient
                            {
                                Id = iqData.Ingredient.Id,
                                Name = iqData.Ingredient.Name
                            }
                        };
                    })
                );

            var ingredientsData = this.dbManager.BrowseItems(typeof(RecipesData.Models.Ingredient));

            var ingredients = new List<Models.Ingredient>
                (
                    ingredientsData.Select(data =>
                    {
                        var ingredientData = (RecipesData.Models.Ingredient)data;

                        return new Models.Ingredient
                        {
                            Id = ingredientData.Id,
                            Name = ingredientData.Name
                        };
                    })
                );

            var categoriesData = this.dbManager.BrowseItems(typeof(RecipesData.Models.Category));

            var categories = new List<Models.Category>
                (
                    categoriesData.Select(data =>
                    {
                        var categoryData = (RecipesData.Models.Category)data;

                        return new Models.Category
                        {
                            Id = categoryData.Id,
                            Name = categoryData.Name
                        };
                    })
                );

            var dialog = new SaveFileDialog
            {
                DefaultExt = ".bin",
                Title = "Export collection as binary data",
                FileName = "collection",
                Filter = "Binary files (*.bin)|*.bin"
            };

            if (dialog.ShowDialog() == true)
            {
                Serialiser s = new Serialiser(dialog.FileName, recipes, ingredients, categories, iq);

                if (s.Serialise())
                {
                    MessageBox.Show($"Successfully saved data to {dialog.FileName}", "Saved data", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                }
                else
                {
                    MessageBox.Show($"Could not serialise data to {dialog.FileName}. Ensure that the data is not corrupted and the program has sufficient permissions for this operation.", "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                }
            }
        }

        /// <summary>
        /// Imports collections from a binary file
        /// <para>Triggered by the "Import binary data" menu button</para>
        /// </summary>
        /// <param name="obj"></param>
        public void Import(object obj)
        {
            var dialog = new OpenFileDialog
            {
                DefaultExt = ".bin",
                Title = "Import collection as binary data",
                FileName = "collection",
                Filter = "Binary files (*.bin)|*.bin"
            };

            if (dialog.ShowDialog() == true)
            {
                Deserialiser d = new Deserialiser(dialog.FileName);
                List<Models.Recipe> recipesData;
                List<Models.IngredientQuantity> iqData;
                List<Models.Ingredient> ingredientsData;
                List<Models.Category> categoriesData;

                if (d.Deserialise())
                {
                    recipesData = d.DeserialisedRecipes;
                    iqData = d.DeserialisedIngredientQuantities;
                    ingredientsData = d.DeserialisedIngredients;
                    categoriesData = d.DeserialisedCategories;

                    this.dbManager.ResetDatabaseState();

                    foreach (var ingredient in ingredientsData)
                    {
                        this.dbManager.AddItem
                            (
                                new RecipesData.Models.Ingredient
                                {
                                    Name = ingredient.Name
                                }
                            );
                    }

                    foreach (var category in categoriesData)
                    {
                        this.dbManager.AddItem
                            (
                                new RecipesData.Models.Category
                                {
                                    Name = category.Name
                                }
                            );
                    }

                    foreach (var recipe in recipesData)
                    {
                        var catData = dbManager.ReadItem(new RecipesData.Models.Category { Name = recipe.Category.Name });

                        if (catData != null)
                        {
                            var cat = (RecipesData.Models.Category)catData;

                            this.dbManager.AddItem
                            (
                                new RecipesData.Models.Recipe
                                {
                                    Name = recipe.Name,
                                    CategoryId = cat.Id,
                                    Serves = recipe.Serves,
                                    KcalPerServe = recipe.KcalPerServe,
                                    Method = recipe.Method,
                                    Favourite = recipe.Favourite,
                                    PreparationTime = recipe.PreparationTime
                                }
                            );
                        }
                    }

                    foreach (var iq in iqData)
                    {
                        var ingData = dbManager.ReadItem(new RecipesData.Models.Ingredient { Name = iq.Ingredient.Name });

                        var ing = (RecipesData.Models.Ingredient)ingData;

                        var recipeData = dbManager.ReadItem(new RecipesData.Models.Recipe { Name = iq.Recipe.Name });

                        var recipe = (RecipesData.Models.Recipe)recipeData;

                        if (ing != null && recipe != null)
                        {
                            this.dbManager.AddItem
                            (
                                new RecipesData.Models.IngredientQuantity
                                {
                                    Amount = iq.Amount,
                                    IngredientId = ing.Id,
                                    RecipeId = recipe.Id,
                                    Quantity = iq.Quantity
                                }
                            );
                        }
                    }

                    MessageBox.Show($"Data successfully imported from {dialog.FileName}", "Data imported", MessageBoxButton.OK, MessageBoxImage.Information);

                    switch (SelectedViewModel)
                    {
                        case IngredientsViewModel ingredientsViewModel:
                            ingredientsViewModel.Items =
                                new ObservableCollection<Models.Ingredient>(ingredientsData);
                            break;

                        case CategoriesViewModel categoriesViewModel:
                            categoriesViewModel.Items =
                                new ObservableCollection<Models.Category>(categoriesData);
                            break;

                        case IngredientQuantitiesViewModel iq:
                            iq.Items =
                                new ObservableCollection<Models.IngredientQuantity>(iqData);
                            iq.Ingredients =
                                new ObservableCollection<Models.Ingredient>(ingredientsData);
                            iq.Recipes =
                                new ObservableCollection<Models.Recipe>(recipesData);
                            break;

                        case RecipesViewModel recipesViewModel:
                            recipesViewModel.Items =
                                new ObservableCollection<Models.Recipe>(recipesData);
                            recipesViewModel.FilteredItems =
                                new ObservableCollection<Models.Recipe>(recipesData);
                            recipesViewModel.Categories =
                                new ObservableCollection<Models.Category>(categoriesData);
                            recipesViewModel.IngredientQuantities =
                                new ObservableCollection<Models.IngredientQuantity>(iqData);
                            break;

                        default:
                            Console.WriteLine("Could not update view models");
                            break;
                    }
                }
                else
                {
                    MessageBox.Show($"Could not deserialise data from {dialog.FileName}. Ensure that the data is not corrupted.", "Deserialisation error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        #endregion
    }
}
