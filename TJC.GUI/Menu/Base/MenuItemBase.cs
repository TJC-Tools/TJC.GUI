using System.Windows;

namespace TJC.GUI.Menu.Base;

internal abstract class MenuItemBase(MenuItemSettings settings) : IMenuItem
{
    private readonly MenuItemSettings _settings = settings;

    public abstract string Header { get; }

    public MenuItem? GetMenuItem()
    {
        if (!_settings.Include)
            return null;

        MenuItem? menuItem = null;

        // Run the code in an STA thread since we are creating a UI element
        if (Application.Current != null)
        {
            Application.Current.Dispatcher.Invoke(delegate
            {
                menuItem = DoGetMenuItem();
            });
        }
        else
        {
            // This thread is for unit tests (which don't have an Application.Current)
            var thread = new Thread(() =>
            {
                menuItem = DoGetMenuItem();
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join(); // Wait for the thread to complete
        }

        return menuItem;
    }

    private MenuItem DoGetMenuItem()
    {
        var command = new RelayCommand(_settings.Execute ?? Execute, _settings.CanExecute ?? CanExecute);
        var subMenuItems = GetSubMenuItems().GetMenuItems();
        var menuItem = new MenuItem
        {
            Header = _settings.Header ?? Header,
            Command = command,
            ItemsSource = subMenuItems
        };
        return menuItem;
    }

    protected virtual IEnumerable<ISubMenuItem> GetSubMenuItems()
    {
        return [];
    }

    protected virtual void Execute(object? obj)
    {
    }

    protected virtual bool CanExecute(object? obj)
    {
        return true;
    }
}