using System.Reflection;
using TJC.GUI.Menu.Help;

namespace TJC.GUI.Menu;

public static class MenuFactory
{
    public static IEnumerable<MenuItem> GetMenuItems(Assembly? assembly = null)
    {
        var mainMenuItems = GetMainMenuItems(assembly ?? Assembly.GetCallingAssembly());
        var menuItems = mainMenuItems.Select(x => x.GetMenuItem());
        return menuItems;
    }

    internal static IEnumerable<IMainMenuItem> GetMainMenuItems(Assembly assembly)
    {
        MenuSettings.Instance.Assembly = assembly;

        yield return new HelpMenu();
    }
}