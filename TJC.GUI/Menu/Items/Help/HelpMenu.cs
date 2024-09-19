using TJC.GUI.Menu.Items.Help.About;
using TJC.GUI.Menu.Items.Help.Help;

namespace TJC.GUI.Menu.Items.Help;

internal class HelpMenu() : MenuItemBase(MenuItemSettings.MainMenu), IMainMenuItem
{
    public override string Header => "_Help";

    protected override IEnumerable<ISubMenuItem> GetSubMenuItems()
    {
        yield return new HelpItem();
        yield return new AboutItem();
    }
}