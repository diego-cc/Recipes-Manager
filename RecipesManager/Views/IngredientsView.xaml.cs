using RecipesManager.ViewModels.Services;
using System.Windows.Controls;

namespace RecipesManager.Views
{
    /// <summary>
    /// Interaction logic for IngredientsView.xaml
    /// </summary>
    public partial class IngredientsView : UserControl, IViewIngredientsViewModel
    {
        public IngredientsView(IViewIngredientsViewModel ingredientsViewModel)
        {
            InitializeComponent();
            DataContext = ingredientsViewModel;
        }

        public IngredientsView()
        {
            InitializeComponent();
        }
    }
}
