namespace TJC.GUI.Menu.Items.Help.About;

public class AboutChangelogSettings(bool included)
    : Inclusion.Inclusion(included)
{
    public bool IncludeHeader { get; set; } = false;

    public bool IncludeUnreleasedSection { get; set; } = false;

    public bool IncludePaths { get; set; } = false;
}