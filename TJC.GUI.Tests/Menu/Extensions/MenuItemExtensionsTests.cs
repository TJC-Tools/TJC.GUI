using Avalonia.Controls;
using TJC.GUI.Menu;
using TJC.GUI.Menu.Extensions;
using TJC.GUI.Menu.Settings;

namespace TJC.GUI.Tests.Menu.Extensions;

[TestClass]
public class MenuItemExtensionsTests
{
    [TestMethod]
    public void FindMenuItem_File_ReturnsNotNull()
    {
        // Arrange
        MenuSettings.Instance.ExcludeAllMenus();
        MenuSettings.Instance.ExitSettings.Include();
        var menuItems = MenuFactory.CreateMenuItems().ToList();

        // Act
        var fileMenu = menuItems.FindMenuItem("FILE");

        // Assert
        Assert.IsNotNull(fileMenu);
        Assert.AreEqual("_File", fileMenu.Header);
    }

    [TestMethod]
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
        Assert.IsNotNull(fileMenu);
        Assert.AreEqual(subMenuItemCountBefore + 1, subMenuItemCountAfter);
        Assert.AreEqual(newSubMenuItem.Header, firstSubMenuItem?.Header);
    }

    [TestMethod]
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
        Assert.IsNotNull(fileMenu);
        Assert.AreEqual(subMenuItemCountBefore + 1, subMenuItemCountAfter);
        Assert.AreEqual(newSubMenuItem.Header, lastSubMenuItem?.Header);
    }
}
