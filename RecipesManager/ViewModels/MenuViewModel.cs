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

            CategoriesCommand = new NavigateCommand(this._mainViewModel.OpenCategories);
        }

        public ICommand CategoriesCommand { get; private set; }
    }
}
