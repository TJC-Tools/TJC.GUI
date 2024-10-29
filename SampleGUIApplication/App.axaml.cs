using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;
using Material.Colors;
using Material.Styles.Themes;
using Material.Styles.Themes.Base;
using SampleGUIApplication.ViewModels;
using SampleGUIApplication.Views;

namespace SampleGUIApplication;

public partial class App : Application
{
    public static ThemeVariant ThemeVariant { get; set; } = ThemeVariant.Default;

    public override void Initialize()
    {
        // Initialize
        base.Initialize();

        // Load the XAML
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow { DataContext = new MainViewModel() };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView { DataContext = new MainViewModel() };
        }

        base.OnFrameworkInitializationCompleted();

        // Set the theme
        SetTheme(ThemeVariant);
    }

    public void SetTheme(ThemeVariant themeVariant)
    {
        ThemeVariant = themeVariant;
        var baseTheme = SelectBaseTheme(themeVariant);
        var primary = SwatchHelper.Lookup[(MaterialColor)PrimaryColor.Grey];
        var accent = SwatchHelper.Lookup[(MaterialColor)SecondaryColor.Amber];
        var themes = Theme.Create(baseTheme, primary, accent);
        var materialTheme = this.LocateMaterialTheme<MaterialThemeBase>();
        if (materialTheme != null)
            materialTheme.CurrentTheme = themes;
    }

    private IBaseTheme SelectBaseTheme(ThemeVariant themeVariant)
    {
        if (themeVariant == ThemeVariant.Dark)
            return Theme.Dark;
        if (themeVariant == ThemeVariant.Light)
            return Theme.Light;
        return SelectBaseTheme(ActualThemeVariant);
    }
}
