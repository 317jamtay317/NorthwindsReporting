using Configure.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace Configure
{
    public class ConfigureModule : IModule
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<GridReportBuilder>();
            containerRegistry.RegisterForNavigation<FormReportBuilder>();
            containerRegistry.RegisterForNavigation<QueryBuilder>();
            containerRegistry.RegisterForNavigation<ConfigureHost>();
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
        }
    }
}
