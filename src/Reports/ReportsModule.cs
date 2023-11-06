using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Reports.Views;
using Shared;

namespace Reports;

public class ReportsModule : IModule
{
    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        
    }

    public void OnInitialized(IContainerProvider containerProvider)
    {
        var regionManager = containerProvider.Resolve<IRegionManager>();
        regionManager.RegisterViewWithRegion(Regions.TabRegion, typeof(FormView));
        regionManager.RegisterViewWithRegion(Regions.TabRegion, typeof(GridView));
    }
}