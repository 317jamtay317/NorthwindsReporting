using System.Windows.Input;
using Northwinds.Core.Prism;
using Prism.Commands;
using Prism.Regions;
using Shared;
using Shared.Mvvm;

namespace Northwinds;

public class MainWindowViewModel : LoadedViewModelBase
{
    public MainWindowViewModel(IRegionManager regionManager)
    {
        _regionManager = regionManager;
        Title = "Northwind Reporting";
    }
    
    /// <summary>
    /// The title that is displayed
    /// </summary>
    public string? Title
    {
        get => GetValue<string>();
        set => SetValue(value);
    }

    protected override void LoadedExecute()
    {
        _regionManager.RequestNavigate(Regions.LeftRegion, ViewNames.LeftMenu);
        _regionManager.RequestNavigate(Regions.TabRegion, ViewNames.FormView);
        _regionManager.RequestNavigate(Regions.TabRegion, ViewNames.GridView);
    }
    
    private readonly IRegionManager _regionManager;
}