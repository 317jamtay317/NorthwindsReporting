using Configure.Views;
using Northwinds.Core.Prism;
using Northwinds.Views;
using Prism.Ioc;
using Prism.Regions;
using Shared;

namespace Northwinds.Core.Extensions;

public static class ContainerRegistryExtensions
{
    public static void RegisterServices(this IContainerRegistry containerRegistry)
    {
    }

    public static void RegisterViews(this IContainerProvider container)
    {
        var regionManager = container.Resolve<IRegionManager>();
        regionManager.RegisterViewWithRegion<LeftMenu>(Regions.LeftRegion);
    }
}