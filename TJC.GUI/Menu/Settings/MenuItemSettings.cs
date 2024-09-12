namespace TJC.GUI.Menu.Settings
{
    public class MenuItemSettings(bool include,
                                  string? header = null,
                                  Action<object?>? execute = null,
                                  Predicate<object?>? canExecute = null)
    {
        #region Predefined Types

        public static MenuItemSettings MainMenu => new(true);

        #endregion

        #region Properties

        public Inclusion.Inclusion Include { get; } = new(include);

        public string? Header { get; } = header;

        public Action<object?>? Execute { get; } = execute;

        public Predicate<object?>? CanExecute { get; } = canExecute;

        #endregion
    }
}