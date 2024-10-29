using System.Reactive;
using System.Reactive.Linq;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Threading;

namespace TJC.GUI.Menu.Base;

public abstract class MenuItemBase(MenuItemSettings settings) : IMenuItem
{
    public abstract string Header { get; }

    public virtual KeyGesture? DefaultGesture => null;

    private KeyGesture? _keyGesture => settings.Gesture ?? DefaultGesture;

    #region Create

    public MenuItem? CreateMenuItem()
    {
        if (!settings)
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
            Dispatcher
                .UIThread.InvokeAsync(() =>
                {
                    menuItem = DoGetMenuItem();
                })
                .GetAwaiter()
                .GetResult();
        }

        return menuItem;
    }

    private MenuItem DoGetMenuItem()
    {
        // Create the header and remove the accelerator key if needed
        var header = settings.Header ?? Header;
        if (MenuSettings.Instance.HideSubMenuAcceleratorKeys && this is ISubMenuItem)
            header = header.Replace("_", string.Empty);

        // Get the sub menu items
        var subMenuItems = GetSubMenuItems().CreateMenuItems();

        // Create the menu item
        var menuItem = new MenuItem
        {
            Header = header,
            Command = CreateCommand(),
            ItemsSource = subMenuItems,
            InputGesture = _keyGesture,
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
        if (
            Avalonia.Application.Current?.ApplicationLifetime
            is IClassicDesktopStyleApplicationLifetime desktop
        )
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
        var execute = settings.Execute ?? Execute;
        var canExecute = settings.CanExecute ?? CanExecute;

        // Convert the canExecute predicate to an observable
        var canExecuteObservable = Observable.Defer(() => Observable.Return(canExecute()));

        // Create and return the ReactiveCommand
        return ReactiveCommand.Create(execute, canExecuteObservable);
    }

    protected virtual void Execute() { }

    protected virtual bool CanExecute()
    {
        return true;
    }

    #endregion

    #region Gesture

    private void SetupGesture(Window window)
    {
        if (_keyGesture == null)
            return;
        var keybinding = new KeyBinding { Command = CreateCommand(), Gesture = _keyGesture };
        window?.KeyBindings.Add(keybinding);
    }

    #endregion
}
