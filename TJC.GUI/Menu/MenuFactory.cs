using System.Reflection;
using TJC.GUI.Menu.Items.File;
using TJC.GUI.Menu.Items.Help;

namespace TJC.GUI.Menu;

public static class MenuFactory
{
    public static IEnumerable<MenuItem> CreateMenuItems(Assembly? assembly = null)
    {
        var mainMenuItems = CreateMainMenuItems(assembly ?? Assembly.GetCallingAssembly());
        var menuItems = mainMenuItems.CreateMenuItems();
        menuItems = menuItems.Where(x => x.Items.Count > 0);

        return menuItems;
    }

    internal static IEnumerable<IMainMenuItem> CreateMainMenuItems(Assembly assembly)
    {
        MenuSettings.Instance.Assembly = assembly;

        yield return new FileMenu();
        yield return new HelpMenu();
    }
}
