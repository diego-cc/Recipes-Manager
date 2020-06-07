using System.Threading.Tasks;
using System.Windows.Input;

namespace RecipesManager.Commands
{
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync();
        bool CanExecute();
    }
}
