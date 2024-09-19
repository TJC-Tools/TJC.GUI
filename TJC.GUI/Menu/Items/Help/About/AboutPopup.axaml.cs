namespace TJC.GUI.Menu.Items.Help.About
{
    public partial class AboutPopup : Window
    {
        public AboutPopup()
        {
            InitializeComponent();
        }

        public AboutPopup(string? title = null,
                          Version? version = null,
                          string? copyright = null,
                          string? license = null)
            : this()
        {
            Title = $"About {title}";

            SetSize();

            VersionTextBlock.Text = $"Version: {version}";
            VersionTextBlock.IsVisible = version != null;

            CopyrightTextBlock.Text = copyright;
            CopyrightTextBlock.IsVisible = copyright != null;

            LicenseTextBlock.Text = license;
            LicenseTextBlock.IsVisible = license != null;
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
}