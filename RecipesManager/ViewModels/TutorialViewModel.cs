using RecipesData.Setup;
using RecipesManager.Commands;
using RecipesManager.ViewModels.Services;
using System.Windows.Input;
using RecipesManager.Views;

namespace RecipesManager.ViewModels
{
    /// <summary>
    /// ViewModel for <see cref="TutorialView"/>
    /// </summary>
    public class TutorialViewModel : IViewTutorialViewModel
    {
        private IDbManager dbManager;
        public IViewMainViewModel MainViewModel { get; set; }
        public ICommand BackToMenuCommand { get; set; }

        public TutorialViewModel(IDbManager dbManager, IViewMainViewModel mainViewModel) 
        {
            this.dbManager = dbManager;
            MainViewModel = mainViewModel;

            BackToMenuCommand = new RelayCommand(BackToMenu);
        }
        
        /// <summary>
        /// Navigates back to <see cref="MenuView"/>
        /// </summary>
        /// <param name="obj"></param>
        private void BackToMenu(object obj)
        {
            if (MainViewModel != null && MainViewModel is MainViewModel)
            {
                (MainViewModel as MainViewModel).SelectedViewModel = new MenuViewModel(this.dbManager, MainViewModel);
            }
        }
    }
}
