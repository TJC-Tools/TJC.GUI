namespace TJC.GUI.Menu.Extensions;

internal static class MenuItemExtensions
{
    public static IEnumerable<MenuItem> GetMenuItems(this IEnumerable<IMenuItem> menuItems)
    {
        return menuItems.Select(x => x.CreateMenuItem()).OfType<MenuItem>();
    }
}