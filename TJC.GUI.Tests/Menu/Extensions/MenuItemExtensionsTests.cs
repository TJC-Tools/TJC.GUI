using Avalonia.Controls;
using TJC.GUI.Menu;
using TJC.GUI.Menu.Extensions;

namespace TJC.GUI.Tests.Menu.Extensions;

[TestClass]
public class MenuItemExtensionsTests
{
    [TestMethod]
    public void FindMenuItem_File_ReturnsNotNull()
    {
        // Arrange
        var menuItems = MenuFactory.CreateMenuItems().ToList();

        // Act
        var fileMenu = menuItems.FindMenuItem("FILE");

        // Assert
        Assert.IsNotNull(fileMenu);
        Assert.AreEqual("_File", fileMenu.Header);
    }
}