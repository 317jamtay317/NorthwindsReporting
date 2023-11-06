using System.Runtime.CompilerServices;
using Prism.Mvvm;

namespace Shared.Mvvm;

public abstract class ViewModelBase : BindableBase 
{
    protected T? GetValue<T>([CallerMemberName] string propertyName = null)
    {
        if (_values.TryGetValue(propertyName, out var value))
        {
            return (T)value;
        }

        return default(T);
    }

    protected void SetValue<T>(T? value, [CallerMemberName] string propertyName = null)
    {
        _values[propertyName] = value;
        RaisePropertyChanged(propertyName);
    }

    private readonly Dictionary<string, object?> _values = new ();
}