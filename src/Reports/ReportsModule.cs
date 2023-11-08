using Prism.Ioc;
using Prism.Modularity;
using Reports.Views;

namespace Reports;

public class ReportsModule : IModule
{
    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<GridView>();
        containerRegistry.RegisterForNavigation<FormView>();
    }

    public void OnInitialized(IContainerProvider containerProvider)
    {
    }
}