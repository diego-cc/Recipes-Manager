namespace RecipesManager.ViewModels.Services
{
    /// <summary>
    /// Marks an implementer as navigatable from <typeparamref name="F"/> to <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="F">Origin (view or view model)</typeparam>
    /// <typeparam name="T">Destination (view or view model)</typeparam>
    public interface INavigatable<F, T>
    {
    }
}
