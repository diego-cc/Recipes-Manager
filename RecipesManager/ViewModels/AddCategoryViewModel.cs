using RecipesData.Setup;
using RecipesManager.Commands;
using RecipesManager.ViewModels.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using RecipesManager.Views;

namespace RecipesManager.ViewModels
{
    /// <summary>
    /// ViewModel for <see cref="AddCategoryView"/>
    /// </summary>
    class AddCategoryViewModel : IViewAddCategoryViewModel, INotifyPropertyChanged
    {
        private ObservableCollection<Models.Category> categories;

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

        private readonly IDbManager dbManager;

        public AddCategoryViewModel(IDbManager dbManager, ObservableCollection<Models.Category> categories)
        {
            this.dbManager = dbManager;
            this.categories = categories;

            AddCategoryCommand = new RelayCommand(AddCategory);
        }

        public ICommand AddCategoryCommand { get; set; }

        /// <summary>
        /// Determines whether the Submit button can be clicked
        /// Note: It's currently not working :(
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool CanExecuteAddCategory(object obj)
        {
            return !string.IsNullOrEmpty(Name) && !string.IsNullOrWhiteSpace(Name);
        }

        /// <summary>
        /// Adds a new category to the database and updates the local collection
        /// </summary>
        /// <param name="obj"></param>
        public void AddCategory(object obj)
        {
            // basic validation
            if (string.IsNullOrEmpty(Name) || string.IsNullOrWhiteSpace(Name))
            {
                if (MessageBox.Show("Please enter a category name", "Invalid category name", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK) == MessageBoxResult.OK)
                {
                    Name = "";
                }

                return;
            }
            else if (categories.Any(c => c.Name.Trim().ToLower().Equals(Name.Trim().ToLower())))
            {
                if (MessageBox.Show("Category already exists. Please choose a different name.", "Invalid category name", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK) == MessageBoxResult.OK)
                {
                    Name = "";
                }

                return;
            }
            else
            {
                // all good, add category
                if (this.dbManager.AddItem(new RecipesData.Models.Category { Name = Name }))
                {
                    if (MessageBox.Show("Category successfully added!", "Category added", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK) == MessageBoxResult.OK)
                    {
                        // get category added to database
                        var cat = this.dbManager.ReadItem(new RecipesData.Models.Category { Name = Name });

                        // update collection in the view model
                        var categoryAdded = new RecipesManager.Models.Category
                        {
                            Id = ((RecipesData.Models.Category)cat).Id,
                            Name = ((RecipesData.Models.Category)cat).Name,
                        };

                        this.categories.Add(categoryAdded);

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
