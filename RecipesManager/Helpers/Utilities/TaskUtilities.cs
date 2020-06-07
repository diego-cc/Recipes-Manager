using System;
using System.Threading.Tasks;

namespace RecipesManager.Helpers.Utilities
{
    /// <summary>
    /// Contains async extension methods
    /// </summary>
    public static class TaskUtilities
    {
#pragma warning disable RECS0165 // Asynchronous methods should return a Task instead of void
        /// <summary>
        /// Handles errors in tasks 
        /// <para>
        ///     See <see href="https://johnthiriet.com/mvvm-going-async-with-async-command/"></see> for context
        /// </para>
        /// </summary>
        /// <param name="task"></param>
        /// <param name="handler"></param>
        public static async void FireAndForgetSafeAsync(this Task task, IErrorHandler handler = null)
#pragma warning restore RECS0165 // Asynchronous methods should return a Task instead of void
        {
            try
            {
                await task;
            }
            catch (Exception ex)
            {
                handler?.HandleError(ex);
            }
        }
    }
}
