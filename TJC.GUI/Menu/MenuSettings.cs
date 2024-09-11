using System.Reflection;
using TJC.Singleton;

namespace TJC.GUI.Menu;

internal class MenuSettings : SingletonBase<MenuSettings>
{
    internal required Assembly Assembly { get; set; }
}