using Avalonia.Styling;
using TJC.GUI.Helpers;

namespace TJC.GUI.Menu.Items.Help.About;

public class AboutLicenseSettings(bool included)
    : Inclusion.Inclusion(included)
{
    public IStyle Style { get; set; } = StyleHelpers.DefaultMarkdownStyle;
}