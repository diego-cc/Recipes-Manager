using RecipesManager.ViewModels;
using RecipesManager.ViewModels.Services;
using System.Windows;

namespace RecipesManager.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : IViewMainViewModel
    {
        public MainView(IViewMainViewModel mainViewModel)
        {
            InitializeComponent();

            DataContext = mainViewModel;
        }

        public MainView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Quits the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
