using RecipesData.Setup;
using RecipesManager.Models;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using RecipesManager.ViewModels.Services;

namespace RecipesManager.ViewModels
{
    class CategoryViewModel : IViewCategoriesViewModel, INotifyPropertyChanged
    {
        private readonly IDbManager dbManager;
        public ICollection Items { get; set; }

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

        public CategoryViewModel(IDbManager dbManager)
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
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

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
