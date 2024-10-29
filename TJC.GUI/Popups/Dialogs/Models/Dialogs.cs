using TJC.GUI.Popups.Dialogs.ViewModels;
using TJC.GUI.Popups.Dialogs.Views;

namespace TJC.GUI.Popups.Dialogs.Models;

public static class Dialogs
{
    public static async Task<bool> ShowYesNoDialog(
        string dialogTitle = "Confirmation",
        string dialogMessage = "Are you sure?",
        Window? parent = null
    )
    {
        var dialog = new YesNoDialogView
        {
            DataContext = new YesNoDialogViewModel(dialogTitle, dialogMessage),
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

    public static async Task ShowOkDialog(
        string dialogTitle,
        string dialogMessage,
        Window? parent = null
    )
    {
        var dialog = new OkDialogView
        {
            DataContext = new OkDialogViewModel(dialogTitle, dialogMessage),
        };

        var viewModel = (OkDialogViewModel)dialog.DataContext;

        var tcs = new TaskCompletionSource<bool>();

        // Subscribe to the DialogClosed event
        viewModel.DialogClosed += () =>
        {
            tcs.SetResult(true); // Just to indicate that the dialog has closed
            dialog.Close(); // Close the dialog window
        };

        // Show the dialog
        if (parent != null)
            await dialog.ShowDialog(parent);
        else
            dialog.Show();

        await tcs.Task; // Await for the dialog close
    }
}
