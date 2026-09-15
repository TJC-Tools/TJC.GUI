using Avalonia.Controls;
using TJC.GUI.Menu;
using TJC.GUI.Menu.Extensions;
using TJC.GUI.Menu.Settings;

namespace TJC.GUI.Tests.Menu.Extensions;

public class MenuItemExtensionsTests
{
    [Fact]
    public void FindMenuItem_File_ReturnsNotNull()
    {
        // Arrange
        MenuSettings.Instance.ExcludeAllMenus();
        MenuSettings.Instance.ExitSettings.Include();
        var menuItems = MenuFactory.CreateMenuItems().ToList();

        // Act
        var fileMenu = menuItems.FindMenuItem("FILE");

        // Assert
        Assert.NotNull(fileMenu);
        Assert.Equal("_File", fileMenu.Header);
    }

    [Fact]
    public void AddSubMenuItem_ToStart_IsFirstItem()
    {
        // Arrange
        MenuSettings.Instance.ExcludeAllMenus();
        MenuSettings.Instance.ExitSettings.Include();
        var menuItems = MenuFactory.CreateMenuItems().ToList();

        var fileMenu = menuItems.FindMenuItem("FILE");
        var subMenuItemCountBefore = fileMenu?.ItemsSource?.Cast<object>().Count();
        var newSubMenuItem = new MenuItem { Header = "New" };

        // Act
        fileMenu?.AddSubMenuItem(newSubMenuItem, index: 0);
        var subMenuItemCountAfter = fileMenu?.ItemsSource?.Cast<object>().Count();
        var firstSubMenuItem = fileMenu?.ItemsSource?.Cast<object>().First() as MenuItem;

        // Assert
        Assert.NotNull(fileMenu);
        Assert.Equal(subMenuItemCountBefore + 1, subMenuItemCountAfter);
        Assert.Equal(newSubMenuItem.Header, firstSubMenuItem?.Header);
    }

    [Fact]
    public void AddSubMenuItem_ToEnd_IsLastItem()
    {
        // Arrange
        MenuSettings.Instance.ExcludeAllMenus();
        MenuSettings.Instance.ExitSettings.Include();
        var menuItems = MenuFactory.CreateMenuItems().ToList();

        var fileMenu = menuItems.FindMenuItem("FILE");
        var subMenuItemCountBefore = fileMenu?.ItemsSource?.Cast<object>().Count();
        var newSubMenuItem = new MenuItem { Header = "New" };

        // Act
        fileMenu?.AddSubMenuItem(newSubMenuItem);
        var subMenuItemCountAfter = fileMenu?.ItemsSource?.Cast<object>().Count();
        var lastSubMenuItem = fileMenu?.ItemsSource?.Cast<object>().Last() as MenuItem;

        // Assert
        Assert.NotNull(fileMenu);
        Assert.Equal(subMenuItemCountBefore + 1, subMenuItemCountAfter);
        Assert.Equal(newSubMenuItem.Header, lastSubMenuItem?.Header);
    }

    [Fact]
    public void FindMenuItem_RecursiveSearch_FindsNestedItemAndReturnsNullWhenMissing()
    {
        var nested = new MenuItem { Header = "_Nested" };
        var root = new MenuItem
        {
            Header = "_Root",
            ItemsSource = new List<MenuItem> { nested },
        };

        Assert.Same(nested, new[] { root }.FindMenuItem("nested", recursive: true));
        Assert.Null(new[] { root }.FindMenuItem("nested"));
        Assert.Null(new[] { root }.FindMenuItem("missing", recursive: true));
    }

    [Fact]
    public void AddSubMenuItem_WithoutExistingItems_CreatesItemList()
    {
        var parent = new MenuItem();
        var child = new MenuItem { Header = "Child" };

        parent.AddSubMenuItem(child);

        Assert.Equal(new List<object> { child }, parent.ItemsSource!.Cast<object>().ToList());
    }
}
