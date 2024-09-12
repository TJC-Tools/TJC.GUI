namespace TJC.GUI.Menu.Settings
{
    public class MenuItemSettings(bool include,
                                  string? header = null,
                                  Action? execute = null,
                                  Func<bool>? canExecute = null)
    {
        #region Predefined Types

        public static MenuItemSettings MainMenu => new(true);

        #endregion

        #region Properties

        public Inclusion.Inclusion Include { get; } = new(include);

        public string? Header { get; } = header;

        public Action? Execute { get; } = execute;

        public Func<bool>? CanExecute { get; } = canExecute;

        #endregion
    }
}