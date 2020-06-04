using RecipesData.Setup;
using RecipesManager.Commands;
using RecipesManager.Models;
using RecipesManager.ViewModels.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace RecipesManager.ViewModels
{
    class RecipesViewModel : IViewRecipesViewModel, INotifyPropertyChanged
    {
        private readonly IDbManager dbManager;
        public ObservableCollection<Recipe> Items { get; set; }

        private Recipe selectedRecipe;

        public Recipe SelectedRecipe
        {
            get => selectedRecipe;
            set
            {
                selectedRecipe = value;
                OnPropertyChanged();
            }
        }

        public RecipesViewModel(IDbManager dbManager)
        {
            this.dbManager = dbManager;

            var allRecipes = this.dbManager.BrowseItems(typeof(RecipesData.Models.Recipe));

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

            AddRecipeCommand = new RelayCommand(AddRecipe);
            DeleteRecipeCommand = new RelayCommand(DeleteRecipe);
            UpdateRecipeCommand = new RelayCommand(UpdateRecipe);
        }

        private void AddRecipe(object obj)
        {
            
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
            if (SelectedRecipe != null && !string.IsNullOrEmpty(SelectedRecipe.Name) && !string.IsNullOrWhiteSpace(SelectedRecipe.Name))
            {
                if (this.dbManager.EditItem(new RecipesData.Models.Recipe { Id = SelectedRecipe.Id, Name = SelectedRecipe.Name }))
                {
                    MessageBox.Show("Recipe successfully updated", "Recipe updated", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                }
            }
        }

        public ICommand AddRecipeCommand { get; set; }
        public ICommand DeleteRecipeCommand { get; set; }
        public ICommand UpdateRecipeCommand { get; set; }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        #endregion
    }
}
