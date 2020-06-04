using RecipesData.Setup;
using RecipesManager.ViewModels.Services;

namespace RecipesManager.ViewModels
{
    class RecipesViewModel : IViewRecipesViewModel
    {
        private readonly IDbManager _dbManager;

        public RecipesViewModel(IDbManager dbManager)
        {
            _dbManager = dbManager;
        }
    }
}
