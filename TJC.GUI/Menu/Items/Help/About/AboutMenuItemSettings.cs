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

    /// <summary>
    /// Settings for the changelog.
    /// </summary>
    public AboutChangelogSettings ChangelogSettings { get; set; } = new(true);

    /// <summary>
    /// Settings for the license(s).
    /// </summary>
    public AboutLicenseSettings LicenseSettings { get; set; } = new(true);
}