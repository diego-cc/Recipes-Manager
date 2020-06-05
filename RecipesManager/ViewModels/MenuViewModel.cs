using RecipesData.Setup;
using RecipesManager.Commands;
using RecipesManager.ViewModels.Services;
using System.Collections;
using System.Windows.Input;

namespace RecipesManager.ViewModels
{
    class MenuViewModel : IViewMenuViewModel
    {
        private readonly IDbManager _dbManager;
        private readonly MainViewModel _mainViewModel;

        public ICollection Items { get; set; }

        public IDbManager DbManager { get; private set; }

        public MenuViewModel(IDbManager dbManager, IViewMainViewModel mainViewModel)
        {
            this._dbManager = dbManager;
            this._mainViewModel = (MainViewModel)mainViewModel;

            CategoriesCommand = new RelayCommand(this._mainViewModel.OpenCategories);
            IngredientsCommand = new RelayCommand(this._mainViewModel.OpenIngredients);
            RecipesCommand = new RelayCommand(this._mainViewModel.OpenRecipes);
            IngredientQuantitiesCommand = new RelayCommand(this._mainViewModel.OpenIngredientQuantities);
        }

        public ICommand CategoriesCommand { get; private set; }
        public ICommand IngredientsCommand { get; private set; }
        public ICommand RecipesCommand { get; private set; }
        public ICommand IngredientQuantitiesCommand { get; private set; }
    }
}
