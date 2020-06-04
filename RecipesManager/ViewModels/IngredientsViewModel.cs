using RecipesData.Setup;
using RecipesManager.Commands;
using RecipesManager.Models;
using RecipesManager.ViewModels.Services;
using RecipesManager.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace RecipesManager.ViewModels
{
    class IngredientsViewModel : IViewIngredientsViewModel, INotifyPropertyChanged
    {
        private readonly IDbManager dbManager;
        public ObservableCollection<Ingredient> Items { get; set; }

        private Ingredient selectedIngredient;

        public Ingredient SelectedIngredient
        {
            get => selectedIngredient;
            set
            {
                selectedIngredient = value;
                OnPropertyChanged();
            }
        }

        public IngredientsViewModel(IDbManager dbManager)
        {
            this.dbManager = dbManager;

            var allIngredients = this.dbManager.BrowseItems(typeof(RecipesData.Models.Ingredient));

            Items = new ObservableCollection<Ingredient>
            (
                allIngredients.Select(obj =>
                {
                    var ingEntity = (RecipesData.Models.Ingredient)obj;
                    return new Ingredient { Id = ingEntity.Id, Name = ingEntity.Name };
                })
            );

            AddIngredientCommand = new RelayCommand(OpenAddIngredient);
            DeleteIngredientCommand = new RelayCommand(DeleteIngredient);
            UpdateIngredientCommand = new RelayCommand(UpdateIngredient);
        }

        private void OpenAddIngredient(object obj)
        {
            var addIngredientVM = new AddIngredientViewModel(this.dbManager, Items);
            var addIngredientView = new AddIngredientView(addIngredientVM);

            addIngredientView.Show();
        }

        private void DeleteIngredient(object obj)
        {
            if (SelectedIngredient != null)
            {
                if (MessageBox.Show($"Are you sure you want to delete the ingredient \"{SelectedIngredient.Name}\" (ID: {SelectedIngredient.Id})?", "Confirm delete Ingredient", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                {
                    if (this.dbManager.DeleteItem(new RecipesData.Models.Ingredient { Id = SelectedIngredient.Id }))
                    {
                        Items.Remove(SelectedIngredient);
                    }
                }
            }
        }

        private void UpdateIngredient(object obj)
        {
            if (SelectedIngredient != null && !string.IsNullOrEmpty(SelectedIngredient.Name) && !string.IsNullOrWhiteSpace(SelectedIngredient.Name))
            {
                if (this.dbManager.EditItem(new RecipesData.Models.Ingredient { Id = SelectedIngredient.Id, Name = SelectedIngredient.Name }))
                {
                    MessageBox.Show("Ingredient successfully updated", "Ingredient updated", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                }
            }
        }

        public ICommand AddIngredientCommand { get; set; }
        public ICommand DeleteIngredientCommand { get; set; }
        public ICommand UpdateIngredientCommand { get; set; }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        #endregion
    }
}
