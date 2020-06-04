using RecipesData.Setup;
using RecipesManager.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using RecipesManager.ViewModels.Services;
using RecipesManager.Views;
using RecipesManager.Commands;

namespace RecipesManager.ViewModels
{
    class CategoriesViewModel : IViewCategoriesViewModel, INotifyPropertyChanged
    {
        private readonly IDbManager dbManager;
        public ObservableCollection<Category> Items { get; set; }

        private Category selectedCategory;

        public Category SelectedCategory
        {
            get => selectedCategory;
            set
            {
                selectedCategory = value;
                OnPropertyChanged();
            }
        }

        public CategoriesViewModel(IDbManager dbManager)
        {
            this.dbManager = dbManager;

            var allCategories = this.dbManager.BrowseItems(typeof(RecipesData.Models.Category));

            Items = new ObservableCollection<Category>
            (
                allCategories.Select(obj =>
                {
                    var catEntity = (RecipesData.Models.Category)obj;
                    return new Category { Id = catEntity.Id, Name = catEntity.Name };
                })
            );

            AddCategoryCommand = new NavigateCommand(OpenAddCategory);
            DeleteCategoryCommand = new NavigateCommand(DeleteCategory);
            UpdateCategoryCommand = new NavigateCommand(UpdateCategory);
        }

        private void OpenAddCategory(object obj)
        {
            var addCategoryVM = new AddCategoryViewModel(this.dbManager, Items);
            var addCategoryView = new AddCategoryView(addCategoryVM);

            addCategoryView.Show();
        }

        private void DeleteCategory(object obj)
        {
            if (SelectedCategory != null)
            {
                if (MessageBox.Show($"Are you sure you want to delete the category \"{SelectedCategory.Name}\" (ID: {SelectedCategory.Id})?", "Confirm delete category", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                {
                    if (this.dbManager.DeleteItem(new RecipesData.Models.Category { Id = SelectedCategory.Id }))
                    {
                        Items.Remove(SelectedCategory);
                    }
                }
            }
        }

        private void UpdateCategory(object obj)
        {
            if (SelectedCategory != null)
            {
                if (this.dbManager.EditItem(new RecipesData.Models.Category { Id = SelectedCategory.Id, Name = SelectedCategory.Name }))
                {
                    MessageBox.Show("Category successfully updated", "Category updated", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                }
            }
        }

        public ICommand AddCategoryCommand { get; set; }
        public ICommand DeleteCategoryCommand { get; set; }
        public ICommand UpdateCategoryCommand { get; set; }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        #endregion

        #region ICommand
        private ICommand _mUpdater;


        public ICommand UpdateCommand
        {
            get
            {
                if (_mUpdater == null)
                {
                    _mUpdater = new Updater();
                }

                return _mUpdater;
            }

            set
            {
                _mUpdater = value;
            }
        }

        private class Updater : ICommand
        {
            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                MessageBox.Show($"Executing parameter: {parameter}");
            }
        }
        #endregion

    }
}
