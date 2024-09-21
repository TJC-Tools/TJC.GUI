using System.Reactive;

namespace TJC.GUI.Popups.Dialogs.ViewModels;

public class OkDialogViewModel : ReactiveObject
{
    public ReactiveCommand<Unit, Unit> OkCommand { get; }

    public event Action? DialogClosed;

    public OkDialogViewModel(string dialogTitle, string dialogMessage)
    {
        DialogTitle = dialogTitle;
        DialogMessage = dialogMessage;
        OkCommand = ReactiveCommand.Create(CloseDialog);
    }

    public string DialogTitle { get; set; }

    public string DialogMessage { get; set; }

    private void CloseDialog()
    {
        DialogClosed?.Invoke(); // Notify that the dialog is closed
    }
}