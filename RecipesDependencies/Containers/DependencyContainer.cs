using Autofac;
using RecipesData.Setup;
using RecipesManager.ViewModels.Setup;

namespace RecipesData.Containers
{
    /// <summary>
    /// Manages IoC containers and dependencies used in the application
    /// </summary>
    public class DependencyContainer
    {
        private IContainer _container;

        public DependencyContainer() { }

        /// <summary>
        /// Registers all dependencies to be injected in constructors where needed
        /// </summary>
        /// <returns>The newly created IoC container</returns>
        public IContainer RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DbManager>().As<IDbManager>();
            builder.RegisterType<IRootViewModel>();

            _container = builder.Build();

            return _container;
        }
    }
}
