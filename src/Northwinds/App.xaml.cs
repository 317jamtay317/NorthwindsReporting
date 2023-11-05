using System.Windows;
using DAL;
using Northwinds.Core.Extensions;
using Prism.Ioc;

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
            containerRegistry.RegisterViews();
            containerRegistry.RegisterDAL();
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }
    }
}