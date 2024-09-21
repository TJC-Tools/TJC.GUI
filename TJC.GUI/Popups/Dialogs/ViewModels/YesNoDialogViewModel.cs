using System.Reactive;

namespace TJC.GUI.Popups.Dialogs.ViewModels;

internal class YesNoDialogViewModel : ReactiveObject
{
    public YesNoDialogViewModel(string dialogTitle, string dialogMessage)
    {
        DialogTitle = dialogTitle;
        DialogMessage = dialogMessage;
        YesCommand = ReactiveCommand.Create(() => CloseDialog(true));
        NoCommand = ReactiveCommand.Create(() => CloseDialog(false));
    }

    public string DialogTitle { get; set; }

    public string DialogMessage { get; set; }

    public ReactiveCommand<Unit, Unit> YesCommand { get; }

    public ReactiveCommand<Unit, Unit> NoCommand { get; }

    public event Action<bool>? DialogResult;

    private void CloseDialog(bool result)
    {
        // Trigger the result event (true for Yes, false for No)
        DialogResult?.Invoke(result);
    }
}