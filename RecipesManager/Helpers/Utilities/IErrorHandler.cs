using System;

namespace RecipesManager.Helpers.Utilities
{
    /// <summary>
    /// Can be used to handle errors from extension methods
    /// </summary>
    public interface IErrorHandler
    {
        void HandleError(Exception ex);
    }
}
