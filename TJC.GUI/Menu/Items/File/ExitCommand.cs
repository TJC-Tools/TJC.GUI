namespace TJC.GUI.Menu.Items.File;

internal class ExitCommand : MenuItemBase, ISubMenuItem
{
    public ExitCommand() : base(MenuSettings.Instance.Exit)
    {
        if (MenuSettings.Instance.Assembly == null)
            throw new NullReferenceException("Assembly is null.");
    }

    public override string Header => "E_xit";

    protected override void Execute(object? obj = null)
    {
        Environment.Exit(0);
    }
}