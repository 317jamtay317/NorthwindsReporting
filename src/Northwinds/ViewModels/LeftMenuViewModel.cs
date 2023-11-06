using Prism.Events;
using Prism.Regions;
using Shared.Mvvm;

namespace Northwinds.ViewModels;

public class LeftMenuViewModel : ViewModelBase
{
    public LeftMenuViewModel(
        IEventAggregator eventAggregator,
        IRegionManager regionManager)
    {
        _eventAggregator = eventAggregator;
        _regionManager = regionManager;
    }
    
    private readonly IEventAggregator _eventAggregator;
    private readonly IRegionManager _regionManager;
}