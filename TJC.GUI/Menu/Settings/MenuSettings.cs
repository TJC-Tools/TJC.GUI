using System.Reflection;
using TJC.Inclusion.Extensions;
using TJC.Inclusion.Interfaces;
using TJC.Singleton;

namespace TJC.GUI.Menu.Settings;

public class MenuSettings : SingletonBase<MenuSettings>, IIncludable
{
    private MenuSettings()
    {
    }

    internal Assembly? Assembly { get; set; }

    public Inclusion.Inclusion About { get; } = new(true);

    public void IncludeAllMenus() => this.IncludeAll();

    public void ExcludeAllMenus() => this.ExcludeAll();
}