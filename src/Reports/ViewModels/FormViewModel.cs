using Prism.Regions;
using Shared;
using Shared.Mvvm;

namespace Reports.ViewModels;

public class FormViewModel : TabItemViewModelBase
{
    public FormViewModel(IRegionManager regionManager)
        : base(regionManager)
    {
        Header = "Form View";
    }
}