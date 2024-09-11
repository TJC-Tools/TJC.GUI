namespace TJC.GUI.Menu.Help;

internal class HelpMenu : MenuItemBase, IMainMenuItem
{
    public override string Header => "Help";

    protected override IEnumerable<ISubMenuItem> GetSubMenuItems()
    {
        yield return new AboutMenuItem();
    }
}