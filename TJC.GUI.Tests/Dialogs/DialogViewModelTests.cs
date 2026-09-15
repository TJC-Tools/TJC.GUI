using System.Reactive.Linq;
using TJC.GUI.Popups.Dialogs.ViewModels;

namespace TJC.GUI.Tests.Dialogs;

[TestClass]
public class DialogViewModelTests
{
    [TestMethod]
    public void OkCommand_RaisesDialogClosedEvent()
    {
        var viewModel = new OkDialogViewModel("Title", "Message");
        var closed = false;
        viewModel.DialogClosed += () => closed = true;

        viewModel.OkCommand.Execute().Subscribe();

        Assert.AreEqual("Title", viewModel.DialogTitle);
        Assert.AreEqual("Message", viewModel.DialogMessage);
        Assert.IsTrue(closed);
    }

    [TestMethod]
    public void YesAndNoCommands_RaiseExpectedResults()
    {
        var viewModel = new YesNoDialogViewModel("Title", "Message");
        bool? result = null;
        viewModel.DialogResult += value => result = value;

        viewModel.YesCommand.Execute().Subscribe();
        Assert.IsTrue(result);

        viewModel.NoCommand.Execute().Subscribe();
        Assert.IsFalse(result);
    }
}
