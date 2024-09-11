using System.Reflection;
using TJC.Singleton;

namespace TJC.GUI.Menu.Settings;

internal class MenuSettings : SingletonBase<MenuSettings>
{
    private MenuSettings()
    {
    }

    internal required Assembly Assembly { get; set; }
}