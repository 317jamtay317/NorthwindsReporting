
using System.Windows.Input;
using Prism.Commands;

namespace Shared.Mvvm;

public abstract class LoadedViewModelBase : ViewModelBase
{
    protected LoadedViewModelBase()
    {
        LoadedCommand = new DelegateCommand(LoadedExecute, LoadedCanExecute);
        UnloadedCommand = new DelegateCommand(UnloadedExecute, CanUnloaded);
    }

    /// <summary>
    /// Command that will be fired when the view is loaded
    /// </summary>
    public ICommand LoadedCommand { get; }
    
    /// <summary>
    /// Command that will be fired when the view is unloaded
    /// </summary>
    
    public ICommand UnloadedCommand { get; }

    /// <summary>
    /// fired when the LoadedCommand Executes
    /// </summary>
    protected virtual void LoadedExecute()
    {
        
    }

    /// <summary>
    /// fired when the checking if loaded command can execute
    /// </summary>
    protected virtual bool LoadedCanExecute()
    {
        return true;
    }
    
    /// <summary>
    /// fired when the unloaded command executes
    /// </summary>
    protected virtual void UnloadedExecute()
    {
    }

    /// <summary>
    /// fired when the checking if unloaded command can execute
    /// </summary>
    protected virtual bool CanUnloaded()
    {
        return true;
    }
}