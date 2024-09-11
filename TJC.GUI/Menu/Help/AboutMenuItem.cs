﻿using System.Windows;

namespace TJC.GUI.Menu.Help;

internal class AboutMenuItem : MenuItemBase, ISubMenuItem
{
    private readonly string? _title;
    private readonly Version? _version;
    private readonly string _license;
    private readonly string _copyright;

    public AboutMenuItem()
    {
        _title = MenuSettings.Instance.Assembly.GetTitle();
        _version = MenuSettings.Instance.Assembly.GetName().Version;
        _license = MenuSettings.Instance.Assembly.GetLicense();
        _copyright = MenuSettings.Instance.Assembly.GetCopyright();
    }

    public override string Header => "_About";

    protected override void Execute(object? obj = null)
    {
        var popup = string.Empty;

        if (!string.IsNullOrEmpty(_title))
            popup += $"{_title}\n\n";

        if (_version != null)
            popup += $"Version: {_version}\n\n";

        if (!string.IsNullOrEmpty(_copyright))
            popup += $"{_copyright}\n\n";

        if (!string.IsNullOrEmpty(_license))
            popup += $"License:\n{_license}";

        MessageBox.Show(popup, $"About {_title}");
    }
}