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
          + "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex metus, porttitor in nulla blandit, "
          + "commodo convallis libero. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. "
          + "Vivamus eleifend sollicitudin leo a maximus. Donec a blandit quam, ut aliquet turpis. Quisque tristique, "
          + "mauris efficitur tempor venenatis, nisi augue lobortis elit, quis laoreet risus nisl vitae massa. "
          + "Donec a placerat risus. Sed a auctor neque. Curabitur tempor id lacus vel ultrices. Proin blandit non orci non finibus. "
          + "Nullam posuere nisl enim, vel placerat magna laoreet iaculis.";

        MenuItems = MenuFactory.CreateMenuItems().ToList();
    }

    public List<MenuItem> MenuItems { get; }
}