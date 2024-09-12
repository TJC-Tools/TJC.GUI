using System.Reflection;
using TJC.Singleton;

namespace TJC.GUI.Menu.Settings;

public class MenuSettings : SingletonBase<MenuSettings>
{
    private MenuSettings()
    {
    }

    internal Assembly? Assembly { get; set; }

    public MenuItemSettings About { get; } = new(true);

    private IEnumerable<MenuItemSettings> GetSettings() =>
        GetType().GetProperties().Where(x => x.PropertyType == typeof(MenuItemSettings)).Select(x => x.GetValue(this)).Cast<MenuItemSettings>();

    public void IncludeAllMenus()
    {
        foreach (var setting in GetSettings())
            setting.Include.Include();
    }

    public void ExcludeAllMenus()
    {
        foreach (var setting in GetSettings())
            setting.Include.Exclude();
    }
}