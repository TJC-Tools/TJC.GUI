using System.Reflection;
using TJC.GUI.Menu.Items.Help.About;
using TJC.GUI.Menu.Items.Help.Help;
using TJC.Singleton;

namespace TJC.GUI.Menu.Settings;

public class MenuSettings : SingletonBase<MenuSettings>
{
    #region Singleton Constructor

    private MenuSettings() { }

    #endregion

    #region Properties

    internal Assembly? Assembly { get; set; }

    /// <summary>
    /// This is defaulted to true since Avalonia currently has a bug with sub-menu accelerator keys.
    /// https://github.com/AvaloniaUI/Avalonia/issues/7090
    /// </summary>
    public Inclusion.Inclusion HideSubMenuAcceleratorKeys { get; } = new();

    #region Items

    #region File

    public MenuItemSettings ExitSettings { get; } = new(true);

    #endregion

    #region Help

    public AboutMenuItemSettings AboutSettings { get; set; } = new(true);

    public HelpMenuItemSettings HelpSettings { get; set; } = new(false);

    #endregion

    #endregion

    #endregion

    #region Methods

    private IEnumerable<MenuItemSettings> GetSettings() =>
        GetType().GetProperties()
            .Where(x => x.PropertyType == typeof(MenuItemSettings))
            .Select(x => x.GetValue(this)).Cast<MenuItemSettings>();

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

    #endregion
}