using TJC.GUI.Menu;
using TJC.GUI.Menu.Settings;

namespace TJC.GUI.Tests.Menu
{
    [TestClass]
    public class MenuFactoryTests
    {
        [TestMethod]
        public void DefaultSettings_MenuFactory_GetMenuItems()
        {
            // Act
            var menuItems = MenuFactory.GetMenuItems().ToList();

            // Assert
            Assert.IsNotNull(menuItems);
            Assert.AreNotEqual(0, menuItems.Count);
        }

        [TestMethod]
        public void ExcludeAllMenus_MenuFactory_GetMenuItems()
        {
            // Arrange
            MenuSettings.Instance.ExcludeAllMenus();

            // Act
            var menuItems = MenuFactory.GetMenuItems().ToList();

            // Assert
            Assert.IsNotNull(menuItems);
            Assert.AreEqual(0, menuItems.Count);
        }

        [TestMethod]
        public void IncludeAllMenus_MenuFactory_GetMenuItems()
        {
            // Arrange
            MenuSettings.Instance.IncludeAllMenus();

            // Act
            var menuItems = MenuFactory.GetMenuItems().ToList();

            // Assert
            Assert.IsNotNull(menuItems);
            Assert.AreNotEqual(0, menuItems.Count);
        }

        [TestMethod]
        public void ExcludeAllMenus_IncludeAbout_MenuFactory_GetMenuItems()
        {
            // Arrange
            MenuSettings.Instance.ExcludeAllMenus();
            MenuSettings.Instance.About.Include();

            // Act
            var menuItems = MenuFactory.GetMenuItems().ToList();

            // Assert
            Assert.IsNotNull(menuItems);
            Assert.AreEqual(1, menuItems.Count);
        }
    }
}