using TJC.GUI.Menu;

namespace SampleGUIApplication.ViewModels;

public class MainViewModel : ViewModelBase
{
    public MainViewModel()
    {
        MenuItems = MenuFactory.GetMenuItems().ToList();
    }

    public List<MenuItem> MenuItems { get; }
}