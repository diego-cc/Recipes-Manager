using RecipesManager.ViewModels.Services;
using System.Windows.Controls;

namespace RecipesManager.Views
{
    /// <summary>
    /// Interaction logic for TutorialView.xaml
    /// </summary>
    public partial class TutorialView : UserControl, IViewTutorialViewModel
    {
        public TutorialView(IViewTutorialViewModel tutorialViewModel)
        {
            InitializeComponent();
            DataContext = tutorialViewModel;
        }

        public TutorialView()
        {
            InitializeComponent();
        }
    }
}
