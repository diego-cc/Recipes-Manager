using System;

namespace RecipesManager.Helpers.Utilities
{
    public interface IErrorHandler
    {
        void HandleError(Exception ex);
    }
}
