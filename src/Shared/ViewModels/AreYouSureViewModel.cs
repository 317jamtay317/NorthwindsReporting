using Prism.Services.Dialogs;
using Shared.Mvvm;

namespace Shared.ViewModels;

public class AreYouSureViewModel : ViewModelBase, IDialogAware
{
    public bool CanCloseDialog()
    {
        throw new NotImplementedException();
    }

    public void OnDialogClosed()
    {
        throw new NotImplementedException();
    }

    public void OnDialogOpened(IDialogParameters parameters)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// <inheritdoc cref="IDialogAware.Title"/>
    /// </summary>
    public string Title => "Are You Sure?";

    /// <summary>
    /// <inheritdoc cref="IDialogAware.RequestClose"/>
    /// </summary>
    public event Action<IDialogResult>? RequestClose;
}