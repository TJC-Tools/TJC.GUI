namespace TJC.GUI.Menu.Items.Help.About;

public partial class AboutPopup : Window
{
    private const string TextSeparator = "\n===========================================================\n\n";

    public AboutPopup()
    {
        InitializeComponent();
    }

    public AboutPopup(string? title = null,
                      Version? version = null,
                      string? copyright = null,
                      string? changelog = null,
                      string? license = null,
                      string? thirdPartyLicenses = null)
        : this()
    {
        Title = $"About {title}";

        SetSize();

        VersionTextBlock.Text = $"Version: {version?.ToString(MenuSettings.Instance.AboutSettings.VersionDigits)}";
        VersionTextBlock.IsVisible = version != null;

        CopyrightTextBlock.Text = copyright;
        CopyrightTextBlock.IsVisible = !string.IsNullOrEmpty(copyright);

        ChangelogBlock.Markdown = changelog;
        ChangelogSection.IsVisible = !string.IsNullOrEmpty(changelog);

        // Licenses
        var combinedLicenses = license;
        if (!string.IsNullOrEmpty(license) && !string.IsNullOrEmpty(thirdPartyLicenses))
            combinedLicenses += TextSeparator;
        combinedLicenses += thirdPartyLicenses;
        LicenseBlock.Markdown = combinedLicenses;
        LicenseSection.IsVisible = !string.IsNullOrEmpty(combinedLicenses);
    }

    private void SetSize()
    {
        Width = 500;
        Height = 500;
        MinWidth = 150;
        MinHeight = 150;
        MaxWidth = 1200;
        MaxHeight = 800;
        SizeToContent = SizeToContent.Height;
    }
}