using Shared;
using Shared.Mvvm;

namespace Reports.ViewModels;

public class FormViewModel : ViewModelBase, ITabView
{
    public FormViewModel()
    {
        Header = "Form View";
    }
    public string? Header
    {
        get => GetValue<string>();
        set => SetValue(value);
    }
}