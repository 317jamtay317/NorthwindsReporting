using System;
using System.Windows.Input;
using Configure.Views;
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
        var region = _regionManager.Regions[Regions.TabRegion];
        _regionManager.RequestNavigate(Regions.TabRegion, new Uri(nameof(ConfigureHost), UriKind.Relative));
    }

    /// <summary>
    /// Command to Add a view to the tabs
    /// </summary>
    public ICommand NavigationCommand { get; }

    private readonly IRegionManager _regionManager;
}