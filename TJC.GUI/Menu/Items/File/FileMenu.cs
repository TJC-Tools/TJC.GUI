namespace TJC.GUI.Menu.Items.File;

internal class FileMenu() : MenuItemBase(MenuItemSettings.MainMenu), IMainMenuItem
{
    public override string Header => "_File";

    protected override IEnumerable<ISubMenuItem> GetSubMenuItems()
    {
        yield return new ExitCommand();
    }
}