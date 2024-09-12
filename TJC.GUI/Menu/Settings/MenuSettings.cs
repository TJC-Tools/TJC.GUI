using System.Reflection;
using TJC.Singleton;

namespace TJC.GUI.Menu.Settings;

public class MenuSettings : SingletonBase<MenuSettings>, IIncludable
{
    private MenuSettings()
    {
    }

    internal Assembly? Assembly { get; set; }

    public MenuItemSettings About { get; } = new(true);

    public void IncludeAllMenus() => this.IncludeAll();

    public void ExcludeAllMenus() => this.ExcludeAll();
}