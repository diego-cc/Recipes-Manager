﻿using RecipesData.Models;
using RecipesData.Setup;
using RecipesManager.Commands;
using RecipesManager.ViewModels.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace RecipesManager.ViewModels
{
    class IngredientQuantitiesViewModel : IViewIngredientQuantitiesViewModel, INotifyPropertyChanged
    {
        private readonly IDbManager dbManager;
        public ObservableCollection<RecipesManager.Models.IngredientQuantity> Items { get; set; }
        public ObservableCollection<RecipesManager.Models.Recipe> Recipes { get; set; }
        public ObservableCollection<RecipesManager.Models.Ingredient> Ingredients { get; set; }

        private RecipesManager.Models.IngredientQuantity selectedIQ;

        public RecipesManager.Models.IngredientQuantity SelectedIngredientQuantity
        {
            get => selectedIQ;
            set
            {
                selectedIQ = value;
                OnPropertyChanged();
            }
        }

        private RecipesManager.Models.IngredientQuantity newIQ = new RecipesManager.Models.IngredientQuantity
        {
            Ingredient = new RecipesManager.Models.Ingredient(),
            Recipe = new RecipesManager.Models.Recipe()
        };


        public RecipesManager.Models.IngredientQuantity NewIngredientQuantity
        {
            get => newIQ;
            set
            {
                newIQ = value;
                OnPropertyChanged();
            }
        }

        public IngredientQuantitiesViewModel(IDbManager dbManager)
        {
            this.dbManager = dbManager;

            var allIngredients = this.dbManager.BrowseItems(typeof(RecipesData.Models.Ingredient));

            Ingredients = new ObservableCollection<RecipesManager.Models.Ingredient>
            (
                allIngredients.Select(i =>
                {
                    var ingEntity = (RecipesData.Models.Ingredient)i;

                    return new RecipesManager.Models.Ingredient
                    {
                        Id = ingEntity.Id,
                        Name = ingEntity.Name
                    };
                })
            );

            var allRecipes = this.dbManager.BrowseItems(typeof(RecipesData.Models.Recipe));

            Recipes = new ObservableCollection<RecipesManager.Models.Recipe>
            (
                allRecipes.Select(r =>
                {
                    var recipeEntity = (RecipesData.Models.Recipe)r;

                    return new RecipesManager.Models.Recipe
                    {
                        Id = recipeEntity.Id,
                        Name = recipeEntity.Name,
                        Method = recipeEntity.Method,
                        PreparationTime = recipeEntity.PreparationTime,
                        KcalPerServe = recipeEntity.KcalPerServe,
                        Serves = recipeEntity.Serves,
                        CategoryId = recipeEntity.CategoryId,
                        Category = new RecipesManager.Models.Category
                        {
                            Id = recipeEntity.CategoryId,
                            Name = recipeEntity.Category.Name
                        }
                    };
                })
            );

            var allIngredientQuantities = this.dbManager.BrowseItems(typeof(RecipesData.Models.IngredientQuantity));

            Items = new ObservableCollection<RecipesManager.Models.IngredientQuantity>
            (
                allIngredientQuantities.Select(obj =>
                {
                    var iqEntity = (RecipesData.Models.IngredientQuantity)obj;

                    var recipe = (RecipesData.Models.Recipe)(iqEntity.Recipe);
                    var ingredient = (RecipesData.Models.Ingredient)(iqEntity.Ingredient);

                    return new RecipesManager.Models.IngredientQuantity
                    {
                        Id = iqEntity.Id,
                        Quantity = iqEntity.Quantity,
                        Amount = iqEntity.Amount,
                        RecipeId = recipe.Id,
                        IngredientId = ingredient.Id,
                        Recipe = Recipes.FirstOrDefault(r => r.Id == iqEntity.RecipeId),
                        Ingredient = Ingredients.FirstOrDefault(i => i.Id == iqEntity.IngredientId)
                    };
                })
            );            

            AddIngredientQuantityCommand = new RelayCommand(AddIngredientQuantity);
            DeleteIngredientQuantityCommand = new RelayCommand(DeleteIngredientQuantity);
            UpdateIngredientQuantityCommand = new RelayCommand(UpdateIngredientQuantity);
            RestoreIngredientQuantityCommand = new RelayCommand(RestoreIngredientQuantity);
            ClearIngredientQuantityCommand = new RelayCommand(ClearIngredientQuantity);
        }

        private void AddIngredientQuantity(object obj)
        {
            // basic checks

            if (Items.Any(iq => iq.Recipe.Id == NewIngredientQuantity.Recipe.Id && iq.Ingredient.Id == NewIngredientQuantity.Ingredient.Id))
            {
                // the combination of recipe + ingredient already exists, warn user
                MessageBox.Show("The ingredient selected already has an amount or quantity associated with the recipe selected. Please choose a different combination of recipe and ingredient or remove / update the duplicate.", "Duplicate ingredient quantity", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);

                return;
            }

            // not quite working
            if (!string.IsNullOrWhiteSpace(NewIngredientQuantity.Amount.ToString()) && !decimal.TryParse(NewIngredientQuantity.Amount.ToString(), out _))
            {
                // invalid amount
                MessageBox.Show("Please enter a valid amount (number with optional decimal places)", "Invalid amount", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);

                return;
            }
            
            // add new ingredient quantity
            if (this.dbManager.AddItem(new RecipesData.Models.IngredientQuantity
            {
                Quantity = NewIngredientQuantity.Quantity,
                Amount = NewIngredientQuantity.Amount,
                RecipeId = NewIngredientQuantity.Recipe.Id,
                IngredientId = NewIngredientQuantity.Ingredient.Id
            }))
            {
                if (MessageBox.Show("Ingredient quantity successfully added!", "Ingredient quantity added", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK) == MessageBoxResult.OK)
                {
                    // get id of new recipe added to database
                    var newIQFromDB = this.dbManager.ReadItem(new RecipesData.Models.IngredientQuantity
                    {
                        IngredientId = NewIngredientQuantity.Ingredient.Id,
                        RecipeId = NewIngredientQuantity.Recipe.Id
                    });

                    if (newIQFromDB != null)
                    {
                        var newIQData = (RecipesData.Models.IngredientQuantity)newIQFromDB;

                        // add to local collection
                        Items.Add(new RecipesManager.Models.IngredientQuantity
                        {
                            Id = newIQData.Id,
                            Quantity = newIQData.Quantity,
                            Amount = newIQData.Amount,
                            RecipeId = newIQData.RecipeId,
                            IngredientId = newIQData.IngredientId,
                            Recipe = new RecipesManager.Models.Recipe
                            {
                                Id = newIQData.Recipe.Id,
                                Name = newIQData.Recipe.Name
                            },
                            Ingredient = new RecipesManager.Models.Ingredient
                            {
                                Id = newIQData.Ingredient.Id,
                                Name = newIQData.Ingredient.Name
                            }
                        });
                    }

                    // clear fields
                    NewIngredientQuantity = new RecipesManager.Models.IngredientQuantity
                    {
                        Ingredient = new RecipesManager.Models.Ingredient(),                Recipe = new RecipesManager.Models.Recipe()
                    };
                }
            }
            else
            {
                if (MessageBox.Show("Could not add ingredient quantity. Ensure that all details entered are correct.", "Failed to add ingredient quantity", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK) == MessageBoxResult.OK)
                {
                }
            }
            
        }

        private void DeleteIngredientQuantity(object obj)
        {
            if (SelectedIngredientQuantity != null)
            {
                if (MessageBox.Show($"Are you sure you want to delete the ingredient quantity \"{SelectedIngredientQuantity}\"?", "Confirm delete ingredient quantity", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                {
                    if (this.dbManager.DeleteItem(new RecipesData.Models.IngredientQuantity { Id = SelectedIngredientQuantity.Id }))
                    {
                        Items.Remove(SelectedIngredientQuantity);
                    }
                }
            }
        }

        private void UpdateIngredientQuantity(object obj)
        {
            // update ingredient quantity
            if (this.dbManager.EditItem(new RecipesData.Models.IngredientQuantity
            {
                Id = SelectedIngredientQuantity.Id,
                Quantity = SelectedIngredientQuantity.Quantity,
                Amount = SelectedIngredientQuantity.Amount,
                RecipeId = SelectedIngredientQuantity.Recipe.Id,
                IngredientId = SelectedIngredientQuantity.Ingredient.Id
            }))
            {
                if (MessageBox.Show("Ingredient quantity successfully updated", "Ingredient quanttiy updated", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK) == MessageBoxResult.OK)
                {
                    // all good, local collection should automatically be updated as well
                }
            }            
        }

        private void RestoreIngredientQuantity(object obj)
        {
            var originalSelectedIQ = this.dbManager.ReadItem(new RecipesData.Models.IngredientQuantity { Id = SelectedIngredientQuantity.Id });

            if (originalSelectedIQ != null)
            {
                var originalIQ = (RecipesData.Models.IngredientQuantity)originalSelectedIQ;

                SelectedIngredientQuantity.Id = originalIQ.Id;
                SelectedIngredientQuantity.Quantity = originalIQ.Quantity;
                SelectedIngredientQuantity.Amount = originalIQ.Amount;
                SelectedIngredientQuantity.IngredientId = originalIQ.IngredientId;
                SelectedIngredientQuantity.RecipeId = originalIQ.RecipeId;
                SelectedIngredientQuantity.Ingredient = new RecipesManager.Models.Ingredient
                {
                    Id = originalIQ.Ingredient.Id,
                    Name = originalIQ.Ingredient.Name
                };
                SelectedIngredientQuantity.Recipe = new RecipesManager.Models.Recipe
                {
                    Id = originalIQ.Recipe.Id,
                    Name = originalIQ.Recipe.Name
                };
            }
        }

        private void ClearIngredientQuantity(object obj)
        {
            // clear fields
            NewIngredientQuantity = new RecipesManager.Models.IngredientQuantity
            {
                Ingredient = new RecipesManager.Models.Ingredient(),
                Recipe = new RecipesManager.Models.Recipe()
            };
        }

        public ICommand AddIngredientQuantityCommand { get; set; }
        public ICommand DeleteIngredientQuantityCommand { get; set; }
        public ICommand UpdateIngredientQuantityCommand { get; set; }
        public ICommand RestoreIngredientQuantityCommand { get; set; }
        public ICommand ClearIngredientQuantityCommand { get; set; }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        #endregion
    }
}