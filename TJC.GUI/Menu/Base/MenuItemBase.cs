using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Input;
using Avalonia.Threading;
using System.Reactive;
using System.Reactive.Linq;

namespace TJC.GUI.Menu.Base;

public abstract class MenuItemBase(MenuItemSettings settings) : IMenuItem
{
    private readonly MenuItemSettings _settings = settings;

    public abstract string Header { get; }

    #region Create

    public MenuItem? CreateMenuItem()
    {
        if (!_settings.Include)
            return null;

        InitializeStartupEvent();

        MenuItem? menuItem = null;

        // Check if we are on the UI thread
        if (Dispatcher.UIThread.CheckAccess())
        {
            // We are on the UI thread, so directly execute
            menuItem = DoGetMenuItem();
        }
        else
        {
            // Run on the UI thread using the dispatcher
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                menuItem = DoGetMenuItem();
            }).GetAwaiter().GetResult();
        }

        return menuItem;
    }

    private MenuItem DoGetMenuItem()
    {
        var subMenuItems = GetSubMenuItems().GetMenuItems();
        var header = _settings.Header ?? Header;
        if (_settings.Gesture != null)
            header += $" ({_settings.Gesture})";
        var menuItem = new MenuItem
        {
            Header = header,
            Command = CreateCommand(),
            ItemsSource = subMenuItems
        };
        return menuItem;
    }

    protected virtual IEnumerable<ISubMenuItem> GetSubMenuItems()
    {
        return [];
    }

    #endregion

    #region Events

    private void InitializeStartupEvent()
    {
        if (Avalonia.Application.Current?.ApplicationLifetime
            is IClassicDesktopStyleApplicationLifetime desktop)
            desktop.Startup += (s, e) => OnStartup(desktop);
    }

    private void OnStartup(IClassicDesktopStyleApplicationLifetime desktop)
    {
        if (desktop.MainWindow != null)
            SetupGesture(desktop.MainWindow);
    }

    #endregion

    #region Command

    private ReactiveCommand<Unit, Unit> CreateCommand()
    {
        // Use default Execute and CanExecute if they are not provided
        var execute = _settings.Execute ?? Execute;
        var canExecute = _settings.CanExecute ?? CanExecute;

        // Convert the canExecute predicate to an observable
        var canExecuteObservable = Observable.Defer(() => Observable.Return(canExecute()));

        // Create and return the ReactiveCommand
        return ReactiveCommand.Create(execute, canExecuteObservable);
    }

    protected virtual void Execute()
    {
    }

    protected virtual bool CanExecute()
    {
        return true;
    }

    #endregion

    #region Gesture

    private void SetupGesture(Window window)
    {
        if (_settings.Gesture == null)
            return;
        var keybinding = new KeyBinding
        {
            Command = CreateCommand(),
            Gesture = _settings.Gesture
        };
        window?.KeyBindings.Add(keybinding);
    }

    #endregion
}
