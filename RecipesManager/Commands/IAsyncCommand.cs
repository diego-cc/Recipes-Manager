using System.Threading.Tasks;
using System.Windows.Input;

namespace RecipesManager.Commands
{
    /// <summary>
    /// A simple async version of <see cref="ICommand"/>
    /// </summary>
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync();
        bool CanExecute();
    }
}
