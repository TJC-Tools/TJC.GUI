using System.Windows.Controls;
using TJC.GUI.Menu;

namespace SampleGUIApplication.ViewModels
{
    class MainViewModel
    {
        public MainViewModel()
        {
            MenuItems = MenuFactory.GetMenuItems();
        }

        public IEnumerable<MenuItem> MenuItems { get; }
    }
}