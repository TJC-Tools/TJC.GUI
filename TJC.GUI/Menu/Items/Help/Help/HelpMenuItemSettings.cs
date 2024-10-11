using TJC.Singleton;

namespace TJC.GUI.Menu.Items.Help.About;

public class HelpMenuItemSettings : SingletonBase<AboutMenuItemSettings>
{
    /// <summary>
    /// Contents of the help dialog.
    /// </summary>
    public string HelpContent { get; set; } = string.Empty;
}