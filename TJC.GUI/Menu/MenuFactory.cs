using System.Reflection;

namespace TJC.GUI.Menu;

public static class MenuFactory
{
    public static IEnumerable<MenuItem> GetMenuItems(Assembly? assembly = null)
    {
        var mainMenuItems = GetMainMenuItems(assembly);
        return [];
    }

    internal static IEnumerable<IMainMenuItem> GetMainMenuItems(Assembly? assembly)
    {
        MenuSettings.Instance.Assembly = assembly ?? Assembly.GetCallingAssembly();

        var menuItems = new List<MenuItem>
        {
            new MenuItem
            {
                Header = "File",
                Items =
                {
                    new MenuItem { Header = "Exit" }
                }
            },
            new MenuItem
            {
                Header = "Help",
                Items =
                {
                    new MenuItem { Header = "About" }
                }
            }
        };

        return [];
    }
}