using DAL.Connection;
using DAL.Repositories.Categories;
using DryIoc;
using Prism.Ioc;

namespace DAL
{
    public static class DALRegistry
    {
        public static void RegisterDAL(this IContainerRegistry container)
        {
            container.RegisterSingleton<IConnectionFactory, ConnectionFactory>();
            container.RegisterSingleton<ICategoryRepository, CategoryRepository>();
        }
    }
}
