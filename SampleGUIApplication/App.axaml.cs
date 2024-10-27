using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;
using SampleGUIApplication.ViewModels;
using SampleGUIApplication.Views;

namespace SampleGUIApplication;

public partial class App : Application
{
    public static ThemeVariant ThemeVariant { get; set; } = ThemeVariant.Default;

    public override void Initialize()
    {
        base.Initialize();
        AvaloniaXamlLoader.Load(this);
        RequestedThemeVariant = ThemeVariant;
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainViewModel()
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = new MainViewModel()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}