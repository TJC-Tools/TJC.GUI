using System.Reflection;
using TJC.Inclusion.Interfaces;
using TJC.Singleton;

namespace TJC.GUI.Menu.Settings;

internal class MenuSettings : SingletonBase<MenuSettings>, IIncludable
{
    private MenuSettings()
    {
    }

    internal Assembly? Assembly { get; set; }

    internal Inclusion.Inclusion About { get; } = new(true);
}