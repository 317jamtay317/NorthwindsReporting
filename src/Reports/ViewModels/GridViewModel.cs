using Prism.Regions;
using Shared;
using Shared.Mvvm;

namespace Reports.ViewModels;

public class GridViewModel : TabItemViewModelBase
{
    public GridViewModel(IRegionManager regionManager) 
        :base(regionManager)
    {
        Header = "Grid";
    }
    
}