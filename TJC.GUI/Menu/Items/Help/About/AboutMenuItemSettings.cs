namespace TJC.GUI.Menu.Items.Help.About;

public class AboutMenuItemSettings
{
    /// <summary>
    /// The number of digits to display for the version.
    /// Formats:
    /// 3: v{major}.{minor}.{patch}.
    /// 4: v{major}.{minor}.{build}.{revision}
    /// </summary>
    public int VersionDigits { get; set; } = 3;

    public AboutChangelogSettings ChangelogSettings { get; set; } = new();
}