using System.Reactive.Linq;
using TJC.GUI.Popups.Dialogs.ViewModels;

namespace TJC.GUI.Tests.Dialogs;


public class DialogViewModelTests
{
    [Fact]
    public void OkCommand_RaisesDialogClosedEvent()
    {
        var viewModel = new OkDialogViewModel("Title", "Message");
        var closed = false;
        viewModel.DialogClosed += () => closed = true;

        viewModel.OkCommand.Execute().Subscribe();

        Assert.Equal("Title", viewModel.DialogTitle);
        Assert.Equal("Message", viewModel.DialogMessage);
        Assert.True(closed);
    }

    [Fact]
    public void YesAndNoCommands_RaiseExpectedResults()
    {
        var viewModel = new YesNoDialogViewModel("Title", "Message");
        bool? result = null;
        viewModel.DialogResult += value => result = value;

        viewModel.YesCommand.Execute().Subscribe();
        Assert.True(result);

        viewModel.NoCommand.Execute().Subscribe();
        Assert.False(result);
    }
}