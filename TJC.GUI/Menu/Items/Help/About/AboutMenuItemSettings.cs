namespace TJC.GUI.Menu.Items.Help.About;

public class AboutMenuItemSettings(bool include,
                                   string? header = null,
                                   Action? execute = null,
                                   Func<bool>? canExecute = null,
                                   KeyGesture? gesture = null)
    : MenuItemSettings(include, header, execute, canExecute, gesture)
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