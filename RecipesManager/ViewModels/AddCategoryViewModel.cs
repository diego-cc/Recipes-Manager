using RecipesData.Models;
using RecipesData.Setup;
using RecipesManager.Commands;
using RecipesManager.ViewModels.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace RecipesManager.ViewModels
{
    class AddCategoryViewModel : IViewAddCategoryViewModel, INotifyPropertyChanged
    {
        private ObservableCollection<RecipesManager.Models.Category> categories;

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

        private readonly IDbManager _dbManager;

        public AddCategoryViewModel(IDbManager dbManager, ObservableCollection<RecipesManager.Models.Category> categories)
        {
            _dbManager = dbManager;
            this.categories = categories;

            AddCategoryCommand = new NavigateCommand(AddCategory);
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

        private void AddCategory(object obj)
        {
            // basic validation
            if (string.IsNullOrEmpty(Name) || string.IsNullOrWhiteSpace(Name))
            {
                if (MessageBox.Show("Please enter a category name", "Invalid category name", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK) == MessageBoxResult.OK)
                {
                    Name = "";
                }
            }
            else
            {
                // all good, add category
                if (this._dbManager.AddItem(new RecipesData.Models.Category { Name = Name }))
                {
                    if (MessageBox.Show("Category successfully added!", "Category added", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK) == MessageBoxResult.OK)
                    {
                        // get category added to database
                        var cat = this._dbManager.ReadItem(new RecipesData.Models.Category { Name = Name });

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
