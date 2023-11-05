using Northwinds.Core.Mvvm;

namespace Northwinds;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        Title = "Northwind Reporting";
    }

    public string? Title
    {
        get => GetValue<string>();
        set => SetValue(value);
    }
}