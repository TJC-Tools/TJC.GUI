namespace TJC.GUI.Menu.Extensions;

public static class MenuItemExtensions
{
    public static MenuItem? GetMenuItem(this IEnumerable<MenuItem> menuItems, string header)
    {
        // Clean the header and menu item headers to make the search case-insensitive and ignore underscores
        var searchHeaderClean = header.ToLower().Replace("_", string.Empty);
        foreach (var menuItem in menuItems)
        {
            if (menuItem.Header is not string menuItemHeader)
                continue;
            var menuItemHeaderClean = menuItemHeader.ToLower().Replace("_", string.Empty);
            if (menuItemHeaderClean == searchHeaderClean)
                return menuItem;
        }

        return null;
    }
}