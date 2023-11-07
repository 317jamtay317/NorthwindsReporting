using System.Windows.Input;
using Prism.Commands;
using Prism.Regions;
using Shared;
using Shared.Mvvm;

namespace Northwinds.ViewModels;

public class LeftMenuViewModel : ViewModelBase
{
    public LeftMenuViewModel(
        IRegionManager regionManager)
    {
        _regionManager = regionManager;
        NavigationCommand = new DelegateCommand<string>(Navigate);
    }

    private void Navigate(string view)
    {
        _regionManager.RequestNavigate(Regions.TabRegion, view);
    }

    /// <summary>
    /// Command to Add a view to the tabs
    /// </summary>
    public ICommand NavigationCommand { get; }

    private readonly IRegionManager _regionManager;
}