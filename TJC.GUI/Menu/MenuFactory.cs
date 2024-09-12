using System.Reflection;
using TJC.GUI.Menu.Items.File;
using TJC.GUI.Menu.Items.Help;

namespace TJC.GUI.Menu;

public static class MenuFactory
{
    public static IEnumerable<MenuItem> GetMenuItems(Assembly? assembly = null)
    {
        var mainMenuItems = GetMainMenuItems(assembly ?? Assembly.GetCallingAssembly());
        var menuItems = mainMenuItems.GetMenuItems();
        menuItems = menuItems.Where(x => x.Items.Count > 0);

        return menuItems;
    }

    internal static IEnumerable<IMainMenuItem> GetMainMenuItems(Assembly assembly)
    {
        MenuSettings.Instance.Assembly = assembly;

        yield return new FileMenu();
        yield return new HelpMenu();
    }
}