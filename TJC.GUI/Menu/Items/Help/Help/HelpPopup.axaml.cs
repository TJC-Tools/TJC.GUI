namespace TJC.GUI.Menu.Items.Help.Help
{
    public partial class HelpPopup : Window
    {
        public HelpPopup()
        {
            InitializeComponent();
        }

        public HelpPopup(string? title = null,
                         string? content = null)
            : this()
        {
            Title = $"Help {title}";

            SetSize();

            HelpBlock.Markdown = content;
            HelpBlock.MarkdownStyle ??= MenuSettings.Instance.HelpSettings.Style;
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