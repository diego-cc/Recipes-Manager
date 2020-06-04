using RecipesData.Setup;
using RecipesManager.Commands;
using RecipesManager.ViewModels.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace RecipesManager.ViewModels
{
    class MainViewModel : IViewMainViewModel, INotifyPropertyChanged
    {
        private IDbManager _dbManager;
        private IViewModel _selectedViewModel;

        public ICommand MenuCommand { get; set; }
        public ICommand CategoriesCommand { get; set; }
        public ICommand IngredientsCommand { get; set; }

        public IViewModel SelectedViewModel
        {
            get => _selectedViewModel;
            set {
                this._selectedViewModel = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel(IDbManager dbManager)
        {
            this._dbManager = dbManager;

            MenuCommand = new RelayCommand(OpenMenu);
            CategoriesCommand = new RelayCommand(OpenCategories);
            IngredientsCommand = new RelayCommand(OpenIngredients);

            SelectedViewModel = new MenuViewModel(this._dbManager, this);
        }

        public MainViewModel()
        {

        }

        public void OpenMenu(object obj)
        {
            SelectedViewModel = new MenuViewModel(this._dbManager, this);
        }

        public void OpenCategories(object obj)
        {
            SelectedViewModel = new CategoriesViewModel(this._dbManager);
        }

        public void OpenIngredients(object obj)
        {
            SelectedViewModel = new IngredientsViewModel(this._dbManager);
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
