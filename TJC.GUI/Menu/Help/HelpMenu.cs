namespace TJC.GUI.Menu.Help;

internal class HelpMenu : MenuItemBase, IMainMenuItem
{
    public override string Header => "_Help";

    protected override IEnumerable<ISubMenuItem> GetSubMenuItems()
    {
        yield return new AboutMenuItem();
    }
}