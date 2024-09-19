namespace TJC.GUI.Menu.Settings
{
    public class MenuItemSettings(bool include,
                                  string? header = null,
                                  Action? execute = null,
                                  Func<bool>? canExecute = null,
                                  Avalonia.Input.KeyGesture? gesture = null)
    {
        #region Predefined Types

        public static MenuItemSettings MainMenu => new(true);

        #endregion

        #region Properties

        public Inclusion.Inclusion Include { get; set; } = new(include);

        public string? Header { get; set; } = header;

        public Action? Execute { get; set; } = execute;

        public Func<bool>? CanExecute { get; set; } = canExecute;

        public Avalonia.Input.KeyGesture? Gesture { get; set; } = gesture;

        #endregion
    }
}