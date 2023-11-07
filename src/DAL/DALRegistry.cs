using DAL.Connection;
using DAL.Database;
using DAL.Repositories.Base;
using DAL.Repositories.Categories;
using DryIoc;
using Prism.Ioc;

namespace DAL
{
    public static class DALRegistry
    {
        /// <summary>
        /// Registers the services in the data access layer
        /// </summary>
        /// <param name="container"></param>
        public static void RegisterDAL(this IContainerRegistry container)
        {
            container.RegisterSingleton<IConnectionFactory, ConnectionFactory>();
            container.RegisterRepositories();
            container.RegisterSingleton<IDatabaseInitializer, DatabaseInitializer>();
        }

        /// <summary>
        /// initializes any database objects that are needed
        /// </summary>
        /// <param name="containerProvider"></param>
        /// <returns></returns>
        public static async Task InitDALAsync(this IContainerProvider containerProvider)
        {
            var initializer = containerProvider.Resolve<IDatabaseInitializer>();
            await initializer.Init();
        }

        private static void RegisterRepositories(this IContainerRegistry container)
        {
            var allTypes = typeof(IRepository<>)
                .GetAssembly()
                .GetTypes();
            var interfaces = allTypes
                .Where(x => x.IsInterface && x.IsAssignableTo(typeof(IRepository)) && !x.IsGenericType && x != typeof(IRepository))
                .OrderBy(x => x.Name)
                .ToArray();
            var types = allTypes
                .Where(x => x.IsSubclassOf(typeof(RepositoryBase)) && !x.IsAbstract)
                .ToArray();

            foreach (var repoInterface in interfaces)
            {
                var matchingType = types.Single(x => x.IsAssignableTo(repoInterface));
                container.RegisterSingleton(repoInterface, matchingType);
            }
        }
    }
}
