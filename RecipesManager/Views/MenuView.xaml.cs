using RecipesManager.ViewModels.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RecipesManager.Views
{
    /// <summary>
    /// Interaction logic for MenuUserControl.xaml
    /// </summary>
    public partial class MenuView : UserControl, IViewMenuViewModel
    {
        public MenuView(IViewMenuViewModel menuViewModel)
        {
            DataContext = menuViewModel;
            InitializeComponent();
        }

        public MenuView()
        {
            InitializeComponent();
        }

        private void Menu_Loaded(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// Quits the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// Handles unsaved data before closing the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        /// <summary>
        /// Navigates to the Recipes window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRecipes_Click(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// Navigates to the Categories window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCategories_Click(object sender, RoutedEventArgs e)
        {
            /*Categories categories = new Categories
            {
                DataContext = 
            }
            categories.Show();
            this.Close();*/
        }
    }
}
