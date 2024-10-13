﻿namespace TJC.GUI.Menu.Items.Help.Help;

public class HelpMenuItemSettings(bool include,
                                  string? header = null,
                                  Action? execute = null,
                                  Func<bool>? canExecute = null,
                                  KeyGesture? gesture = null)
    : MenuItemSettings(include, header, execute, canExecute, gesture)
{
    /// <summary>
    /// Contents of the help dialog.
    /// </summary>
    public string HelpContent { get; set; } = string.Empty;
}