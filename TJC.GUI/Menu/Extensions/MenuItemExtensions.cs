namespace TJC.GUI.Menu.Extensions;

public static class MenuItemExtensions
{
    /// <summary>
    /// Locate a menu item by its header.
    /// </summary>
    /// <param name="menuItems"></param>
    /// <param name="header"></param>
    /// <returns></returns>
    public static MenuItem? FindMenuItem(this IEnumerable<MenuItem> menuItems, string header)
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

    /// <summary>
    /// Add a sub-menu item to a menu item at the specified index.
    /// If the index is -1 (default), the sub-menu item is added to the end.
    /// </summary>
    /// <param name="menuItem"></param>
    /// <param name="subMenuItem"></param>
    /// <param name="index"></param>
    public static void AddSubMenuItem(MenuItem menuItem, MenuItem subMenuItem, int index = -1)
    {
        // If the menu item does not have any items, create a new list
        menuItem.ItemsSource ??= new List<MenuItem>();
        if (menuItem.ItemsSource is not IEnumerable<object> items)
            return; // This should never happen

        // Convert the items to a list, so we can add the sub-menu item
        var menuItems = items.ToList();

        // If the index is -1, add the sub-menu item to the end, otherwise insert at the index
        if (index == -1)
            menuItems.Add(subMenuItem);
        else
            menuItems.Insert(index, subMenuItem);

        // Update the items source
        menuItem.ItemsSource = menuItems;
    }
}