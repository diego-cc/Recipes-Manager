using RecipesManager.Models;
using RecipesData.Setup;
using RecipesManager.ViewModels.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
using RecipesManager.Commands;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Linq;

namespace RecipesManager.ViewModels
{
    class AddIngredientViewModel : IViewAddIngredientViewModel, INotifyPropertyChanged
    {
        private readonly IDbManager _dbManager;
        private ObservableCollection<Ingredient> _items;

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public AddIngredientViewModel(IDbManager dbManager, ObservableCollection<Ingredient> items)
        {
            _dbManager = dbManager;
            _items = items;

            AddIngredientCommand = new RelayCommand(AddIngredient);
        }

        public ICommand AddIngredientCommand { get; set; }
        
        private void AddIngredient(object obj)
        {
            // basic validation
            if (string.IsNullOrEmpty(Name) || string.IsNullOrWhiteSpace(Name))
            {
                if (MessageBox.Show("Please enter an ingredient name", "Invalid Ingredient name", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK) == MessageBoxResult.OK)
                {
                    Name = "";
                }
            }
            else if (_items.Any(c => c.Name.Trim().ToLower().Equals(Name.Trim().ToLower())))
            {
                if (MessageBox.Show("Ingredient already exists. Please choose a different name.", "Invalid ingredient name", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK) == MessageBoxResult.OK)
                {
                    Name = "";
                }

                return;
            }
            else
            {
                // all good, add Ingredient
                if (this._dbManager.AddItem(new RecipesData.Models.Ingredient { Name = Name }))
                {
                    if (MessageBox.Show("Ingredient successfully added!", "Ingredient added", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK) == MessageBoxResult.OK)
                    {
                        // get ingredient added to database
                        var cat = this._dbManager.ReadItem(new RecipesData.Models.Ingredient { Name = Name });

                        // update collection in the view model
                        var IngredientAdded = new RecipesManager.Models.Ingredient
                        {
                            Id = ((RecipesData.Models.Ingredient)cat).Id,
                            Name = ((RecipesData.Models.Ingredient)cat).Name,
                        };

                        this._items.Add(IngredientAdded);

                        Name = "";
                    }
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
