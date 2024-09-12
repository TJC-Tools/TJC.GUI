namespace TJC.GUI.Menu.Items.Help;

internal class HelpMenu() : MenuItemBase(MenuItemSettings.MainMenu), IMainMenuItem
{
    public override string Header => "_Help";

    protected override IEnumerable<ISubMenuItem> GetSubMenuItems()
    {
        yield return new AboutPage();
    }
}