using System.Windows.Controls;
using RecipesManager.ViewModels.Services;
using System.Diagnostics;
using System.Windows.Navigation;

namespace RecipesManager.Views
{
    /// <summary>
    /// Interaction logic for AboutView.xaml
    /// </summary>
    public partial class AboutView : UserControl, IViewModel
    {
        public AboutView()
        {
            InitializeComponent();
        }

        private void Link_GitHub_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
