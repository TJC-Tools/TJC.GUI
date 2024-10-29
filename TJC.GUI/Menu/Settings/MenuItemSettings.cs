namespace TJC.GUI.Menu.Settings
{
    public class MenuItemSettings(
        bool include,
        string? header = null,
        Action? execute = null,
        Func<bool>? canExecute = null,
        KeyGesture? gesture = null
    ) : Inclusion.Inclusion(include)
    {
        #region Predefined Types

        public static MenuItemSettings MainMenu => new(true);

        #endregion

        #region Properties

        public string? Header { get; set; } = header;

        public Action? Execute { get; set; } = execute;

        public Func<bool>? CanExecute { get; set; } = canExecute;

        public KeyGesture? Gesture { get; set; } = gesture;

        #endregion
    }
}
