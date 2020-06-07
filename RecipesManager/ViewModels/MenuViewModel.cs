using RecipesData.Setup;
using RecipesManager.Commands;
using RecipesManager.ViewModels.Services;
using System.Collections;
using System.Windows.Input;
using RecipesManager.Views;

namespace RecipesManager.ViewModels
{
    /// <summary>
    /// ViewModel for <see cref="MenuView"/>
    /// </summary>
    class MenuViewModel : IViewMenuViewModel
    {
        private readonly IDbManager dbManager;
        private readonly MainViewModel mainViewModel;

        public ICollection Items { get; set; }

        public IDbManager DbManager { get; private set; }

        public MenuViewModel(IDbManager dbManager, IViewMainViewModel mainViewModel)
        {
            this.dbManager = dbManager;
            this.mainViewModel = (MainViewModel)mainViewModel;

            CategoriesCommand = new RelayCommand(this.mainViewModel.OpenCategories);
            IngredientsCommand = new RelayCommand(this.mainViewModel.OpenIngredients);
            RecipesCommand = new RelayCommandAsync(this.mainViewModel.OpenRecipes);
            IngredientQuantitiesCommand = new RelayCommand(this.mainViewModel.OpenIngredientQuantities);
        }

        public ICommand CategoriesCommand { get; private set; }
        public ICommand IngredientsCommand { get; private set; }
        // public ICommand RecipesCommand { get; private set; }
        public IAsyncCommand RecipesCommand { get; private set; }
        public ICommand IngredientQuantitiesCommand { get; private set; }
    }
}
