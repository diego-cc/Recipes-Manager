using RecipesManager.ViewModels.Services;

namespace RecipesManager.Views
{
    /// <summary>
    /// Interaction logic for AddIngredientView.xaml
    /// </summary>
    public partial class AddIngredientView : IViewAddIngredientViewModel
    {
        public AddIngredientView(IViewAddIngredientViewModel addIngredientViewModel)
        {
            InitializeComponent();
            DataContext = addIngredientViewModel;
        }

        public AddIngredientView()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
