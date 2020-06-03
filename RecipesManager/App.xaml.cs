using RecipesData.Setup;
using RecipesManager.ViewModels;
using RecipesManager.ViewModels.Services;
using RecipesManager.Views;
using System.Windows;
using Unity;

namespace RecipesManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            UnityContainer container = new UnityContainer();
            container.AddExtension(new Diagnostic());

            container.RegisterType<IDbManager, DbManager>();

            container.RegisterType<IViewMainViewModel, MainView>();
            container.RegisterType<IViewMainViewModel, MainViewModel>();

            container.RegisterType<IViewMenuViewModel, MenuView>();
            container.RegisterType<IViewMenuViewModel, MenuViewModel>();

            container.RegisterType<IViewCategoriesViewModel, CategoriesView>();
            container.RegisterType<IViewCategoriesViewModel, CategoryViewModel>();

            var mainWindow = container.Resolve<MainView>();

            mainWindow.Show();
        }
    }
}
