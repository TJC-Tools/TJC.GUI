using TJC.GUI.Menu;
using TJC.GUI.Menu.Settings;

namespace SampleGUIApplication.ViewModels;

public class MainViewModel : ViewModelBase
{
    public MainViewModel()
    {
        MenuSettings.Instance.HelpSettings.Include();
        MenuSettings.Instance.HelpSettings.HelpContent =
            "### Example Title\n"
            + "This is sample text for the help menu.\n"
            + "This should be printed on a separate line.\n"
            + "As should this.\n\n"
            + "This should be a new paragraph.\n"
            + "With multiple lines.\n"
            + "And **Bolding**, *Italics*, & `code format` \n\n"
            + "Here is some more example text.";

        MenuItems = MenuFactory.CreateMenuItems().ToList();
    }

    public List<MenuItem> MenuItems { get; }
}
