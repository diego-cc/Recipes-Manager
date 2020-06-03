using System;
using System.Windows;
using RecipesManager.ViewModels.Services;

namespace RecipesManager
{
    /// <summary>
    /// Interaction logic for Categories.xaml
    /// </summary>
    public partial class Categories : IViewCategoriesViewModel
    {
        public Categories()
        {
            InitializeComponent();
        }

        public Categories(IViewCategoriesViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void Categories_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Categories_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void btnQuit_Click(object sender, EventArgs e)
        {

        }
    }
}
