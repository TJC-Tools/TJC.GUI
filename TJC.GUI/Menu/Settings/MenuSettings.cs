using System.Reflection;
using TJC.Singleton;

namespace TJC.GUI.Menu.Settings;

public class MenuSettings : SingletonBase<MenuSettings>
{
    #region Singleton Constructor

    private MenuSettings()
    {
    }

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

    public MenuItemSettings Exit { get; } = new(true);

    #endregion

    #region Help

    public MenuItemSettings About { get; } = new(true);

    /// <summary>
    /// The number of digits to display for the version.
    /// Formats:
    /// 3: v{major}.{minor}.{patch}.
    /// 4: v{major}.{minor}.{build}.{revision}
    /// </summary>
    public int VersionDigits { get; set; } = 3;

    public MenuItemSettings Help { get; } = new(false);

    /// <summary>
    /// Contents of the help dialog.
    /// </summary>
    public string HelpContent { get; set; } = string.Empty;

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