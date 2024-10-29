namespace TJC.GUI.Menu.Items.File;

internal class ExitCommand : MenuItemBase, ISubMenuItem
{
    public ExitCommand()
        : base(MenuSettings.Instance.ExitSettings)
    {
        if (MenuSettings.Instance.Assembly == null)
            throw new NullReferenceException("Assembly is null.");
    }

    public override string Header => "E_xit";

    public override KeyGesture DefaultGesture => new(Key.F4, KeyModifiers.Alt);

    protected override void Execute()
    {
        Environment.Exit(0);
    }
}
