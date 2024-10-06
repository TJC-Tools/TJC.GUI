using Avalonia.Controls.ApplicationLifetimes;

namespace TJC.GUI.Menu.Items.Help.Help;

/// <summary>
/// On click, displays a popup with help information about the application.
/// </summary>
internal class HelpItem : MenuItemBase, ISubMenuItem
{
    private readonly string? _title;
    private readonly string? _content;

    public HelpItem() : base(MenuSettings.Instance.Help)
    {
        if (MenuSettings.Instance.Assembly == null)
            throw new NullReferenceException("Assembly is null.");
        _title = MenuSettings.Instance.Assembly.GetTitle();
        _content = MenuSettings.Instance.HelpContent;
    }

    public override string Header => "H_elp";

    public override KeyGesture DefaultGesture => new(Key.F1);

    protected override void Execute()
    {
        var popup = new HelpPopup(title: _title,
                                  content: _content);

        // If Window can be found, link it so that the popup is closed if the main window is closed.
        if (Avalonia.Application.Current?.ApplicationLifetime
            is IClassicDesktopStyleApplicationLifetime desktop
            && desktop.MainWindow != null)
            popup.Show(desktop.MainWindow);
        else
            popup.Show();
    }
}