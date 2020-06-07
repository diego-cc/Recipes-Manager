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
    /// <summary>
    /// ViewModel for <see cref="CategoriesView"/>
    /// </summary>
    class CategoriesViewModel : IViewCategoriesViewModel, INotifyPropertyChanged
    {
        private readonly IDbManager dbManager;
        private ObservableCollection<Category> items;

        public ObservableCollection<Category> Items
        {
            get => items;
            set
            {
                items = value;
                OnPropertyChanged();
            }
        }

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

            AddCategoryCommand = new RelayCommand(OpenAddCategory);
            DeleteCategoryCommand = new RelayCommand(DeleteCategory);
            UpdateCategoryCommand = new RelayCommand(UpdateCategory);
        }

        /// <summary>
        /// Creates a new instance of <see cref="AddCategoryView"/>
        /// </summary>
        /// <param name="obj"></param>
        private void OpenAddCategory(object obj)
        {
            var addCategoryVM = new AddCategoryViewModel(this.dbManager, Items);
            var addCategoryView = new AddCategoryView(addCategoryVM);

            addCategoryView.Show();
        }

        /// <summary>
        /// Deletes a category from the database and updates the local collection
        /// </summary>
        /// <param name="obj"></param>
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

        /// <summary>
        /// Updates a category in the database
        /// </summary>
        /// <param name="obj"></param>
        private void UpdateCategory(object obj)
        {
            if (SelectedCategory != null && !string.IsNullOrEmpty(SelectedCategory.Name) && !string.IsNullOrWhiteSpace(SelectedCategory.Name))
            {
                if (this.dbManager.EditItem(new RecipesData.Models.Category { Id = SelectedCategory.Id, Name = SelectedCategory.Name }))
                {
                    MessageBox.Show("Category successfully updated", "Category updated", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                }
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        #endregion

        #region Commands
        public ICommand AddCategoryCommand { get; set; }
        public ICommand DeleteCategoryCommand { get; set; }
        public ICommand UpdateCategoryCommand { get; set; }
        #endregion

    }
}
