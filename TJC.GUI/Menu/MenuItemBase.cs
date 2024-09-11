using TJC.GUI.Menu.Commands;

namespace TJC.GUI.Menu;

internal abstract class MenuItemBase : IMenuItem
{
    public abstract string Header { get; }

    public MenuItem GetMenuItem()
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