namespace TJC.GUI.Menu.Extensions;

public static class IMenuItemExtensions
{
    public static IEnumerable<MenuItem> CreateMenuItems(this IEnumerable<IMenuItem> menuItems)
    {
        return menuItems.Select(x => x.CreateMenuItem()).OfType<MenuItem>();
    }
}