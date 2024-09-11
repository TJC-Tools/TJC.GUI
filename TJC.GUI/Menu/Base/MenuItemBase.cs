using System.Windows;

namespace TJC.GUI.Menu.Base;

internal abstract class MenuItemBase : IMenuItem
{
    public abstract string Header { get; }

    public MenuItem GetMenuItem()
    {
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

#pragma warning disable CS8603 // Possible null reference return.
        return menuItem;
#pragma warning restore CS8603 // Ignored because menuItem is always set in one thread or another from DoGetMenuItem
    }

    private MenuItem DoGetMenuItem()
    {
        var command = new RelayCommand(Execute, CanExecute);
        var subMenuItems = GetSubMenuItems().Select(x => x.GetMenuItem()).ToList();
        var menuItem = new MenuItem
        {
            Header = Header,
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

    protected virtual bool CanExecute(object? obj) => true;
}