using Avalonia.Styling;
using Markdown.Avalonia;

namespace TJC.GUI.Menu.Items.Help.About;

public class AboutLicenseSettings(bool included)
    : Inclusion.Inclusion(included)
{
    public IStyle Style { get; set; } = MarkdownStyle.FluentAvalonia;
}