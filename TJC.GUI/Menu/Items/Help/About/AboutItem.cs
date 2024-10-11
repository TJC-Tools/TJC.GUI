using Avalonia.Controls.ApplicationLifetimes;

namespace TJC.GUI.Menu.Items.Help.About;

/// <summary>
/// On click, displays a popup with information about the application.
/// <para>Popup Title: About {Title of Application}</para>
/// <para>Content:</para>
/// <para>Title, Version, Copyright, Licenses</para>
/// ========================================
/// <para>Future Considerations:</para>
/// <para>Add Logo, Edition, License Terms, Licensed to (username/company), Installed Products (tools, plugins, etc.)</para>
/// <para>Links to website, etc.</para>
/// </summary>
internal class AboutItem : MenuItemBase, ISubMenuItem
{
    private readonly string? _title;
    private readonly Version? _version;
    private readonly string _copyright;
    private readonly string _license;
    private readonly string _thirdPartyLicenses;
    private readonly string _changelog;

    public AboutItem() : base(MenuSettings.Instance.About)
    {
        if (MenuSettings.Instance.Assembly == null)
            throw new NullReferenceException("Assembly is null.");
        _title = MenuSettings.Instance.Assembly.GetTitle();
        _version = MenuSettings.Instance.Assembly.GetName().Version;
        _copyright = MenuSettings.Instance.Assembly.GetCopyright();
        _license = MenuSettings.Instance.Assembly.GetLicense();
        _thirdPartyLicenses = MenuSettings.Instance.Assembly.GetThirdPartyLicenses();
        _changelog = MenuSettings.Instance.Assembly.GetChangelog(includeHeader: false, includeUnreleasedSection: false, includePaths: false);
    }

    public override string Header => "_About";

    protected override void Execute()
    {
        var popup = new AboutPopup(title: _title,
                                   version: _version,
                                   copyright: _copyright,
                                   changelog: _changelog,
                                   license: _license,
                                   thirdPartyLicenses: _thirdPartyLicenses);

        // If Window can be found, show dialog to prevent main window from being clicked.
        if (Avalonia.Application.Current?.ApplicationLifetime
            is IClassicDesktopStyleApplicationLifetime { MainWindow: not null } desktop)
            popup.ShowDialog(desktop.MainWindow);
        else
            popup.Show();
    }
}