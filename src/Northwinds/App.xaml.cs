using System.Windows;
using System.Windows.Controls;
using DAL;
using Northwinds.Core.Extensions;
using Northwinds.Core.Prism;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Reports;

namespace Northwinds
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App 
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterServices();
            containerRegistry.RegisterDAL();
        }

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
            regionAdapterMappings.RegisterMapping(typeof(TabControl), Container.Resolve<TabControlAdapter>());
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
            moduleCatalog.AddModule(typeof(ReportsModule), InitializationMode.WhenAvailable);
        }

        protected override async void OnInitialized()
        {
            base.OnInitialized();

            await Container.InitDALAsync();
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }
    }
}