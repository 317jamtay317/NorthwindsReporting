using Shared;
using Shared.Mvvm;

namespace Reports.ViewModels;

public class GridViewModel : ViewModelBase, ITabView
{
    public GridViewModel()
    {
        Header = "Grid";
    }
    public string? Header
    {
        get => GetValue<string>();
        set => SetValue(value);
    }
}