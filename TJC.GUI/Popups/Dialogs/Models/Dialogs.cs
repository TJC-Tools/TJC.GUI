using TJC.GUI.Popups.Dialogs.ViewModels;
using TJC.GUI.Popups.Dialogs.Views;

namespace TJC.GUI.Popups.Dialogs.Models;

public static class Dialogs
{
    public static async Task<bool> ShowYesNoDialog(Window? parent = null,
                                                   string dialogTitle = "Confirmation",
                                                   string dialogMessage = "Are you sure?")
    {
        var dialog = new YesNoDialogView
        {
            DataContext = new YesNoDialogViewModel(dialogTitle, dialogMessage)
        };

        var viewModel = (YesNoDialogViewModel)dialog.DataContext;

        var tcs = new TaskCompletionSource<bool>();

        // Subscribe to the DialogResult event
        viewModel.DialogResult += (result) =>
        {
            tcs.SetResult(result); // Set the result of the dialog (Yes or No)
            dialog.Close(); // Close the dialog window
        };

        // Show the dialog
        if (parent != null)
            await dialog.ShowDialog(parent);
        else
            dialog.Show();

        // Return the result (Yes/No)
        return await tcs.Task;
    }
}