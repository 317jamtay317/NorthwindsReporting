using System.Windows.Input;

namespace Shared;

public interface ITabItem
{
    /// <summary>
    /// The Caption that is displayed in the tab header
    /// </summary>
    public string? Header { get; }

    /// <summary>
    /// A command to remove the tab from the region
    /// </summary>
    public ICommand RemoveCommand { get; }
}