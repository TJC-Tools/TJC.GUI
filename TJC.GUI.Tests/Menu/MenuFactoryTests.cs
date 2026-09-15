using TJC.GUI.Menu;
using TJC.GUI.Menu.Settings;

namespace TJC.GUI.Tests.Menu;


public class MenuFactoryTests
{
    [Fact]
    public void DefaultSettings_MenuFactory_CreateMenuItems_ExpectSomeMenus()
    {
        // Act
        var menuItems = MenuFactory.CreateMenuItems().ToList();

        // Assert
        Assert.NotNull(menuItems);
        Assert.NotEqual(0, menuItems.Count);
    }

    [Fact]
    public void ExcludeAllMenus_MenuFactory_CreateMenuItems_ExpectNoMenus()
    {
        // Arrange
        MenuSettings.Instance.ExcludeAllMenus();

        // Act
        var menuItems = MenuFactory.CreateMenuItems().ToList();

        // Assert
        Assert.NotNull(menuItems);
        Assert.Equal(0, menuItems.Count);
    }

    [Fact]
    public void IncludeAllMenus_MenuFactory_CreateMenuItems_ExpectMultipleMenus()
    {
        // Arrange
        MenuSettings.Instance.IncludeAllMenus();

        // Act
        var menuItems = MenuFactory.CreateMenuItems().ToList();

        // Assert
        Assert.NotNull(menuItems);
        Assert.NotEqual(0, menuItems.Count);
    }

    [Fact]
    public void ExcludeAllMenus_IncludeAbout_MenuFactory_CreateMenuItems_Expect1Menu()
    {
        // Arrange
        MenuSettings.Instance.ExcludeAllMenus();
        MenuSettings.Instance.AboutSettings.Include();

        // Act
        var menuItems = MenuFactory.CreateMenuItems().ToList();

        // Assert
        Assert.NotNull(menuItems);
        Assert.Equal(1, menuItems.Count);
    }
}
