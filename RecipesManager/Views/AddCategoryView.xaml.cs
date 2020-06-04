using RecipesManager.ViewModels.Services;
using System.Windows;

namespace RecipesManager.Views
{
    /// <summary>
    /// Interaction logic for AddCategoryView.xaml
    /// </summary>
    public partial class AddCategoryView : IViewAddCategoryViewModel
    {
        public AddCategoryView()
        {
            InitializeComponent();
        }

        public AddCategoryView(IViewAddCategoryViewModel addCategoryViewModel)
        {
            InitializeComponent();
            DataContext = addCategoryViewModel;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
