using System.Windows.Input;
using Prism.Commands;
using Prism.Regions;
using Shared;
using Shared.Mvvm;

namespace Configure.ViewModels
{
    internal class ConfigureHostViewModel : TabItemViewModelBase
    {
        public ConfigureHostViewModel(IRegionManager regionManager) 
            : base(regionManager)
        {
            Header = "Configure";
            NavigateCommand = new DelegateCommand<string>(NavigateExecute);
        }

        public ICommand NavigateCommand { get; }

        private void NavigateExecute(string viewName)
        {
            RegionManager.RequestNavigate(Regions.ConfigureRegion, viewName);
        }

    }
}
