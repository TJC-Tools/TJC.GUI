using System.Reflection;
using Avalonia.Styling;
using TJC.ConsoleApplication.Arguments.Options;

namespace SampleGUIApplication;

internal class Arguments
{
    internal static void Parse(string[] args) =>
        ConsoleArguments.ParseAndValidate(
            args,
            Assembly.GetCallingAssembly().GetName().Name,
            exitOnFailureToParse: false
        );

    internal static ThemeVariant Theme { get; private set; } = ThemeVariant.Default;

    internal static readonly ConsoleArguments ConsoleArguments =
        new(flagRequired: true, logParsedOptions: false)
        {
            { "theme=", v => Theme = ParseTheme(v), "Theme" },
        };

    private static ThemeVariant ParseTheme(string theme) =>
        theme.ToLower() switch
        {
            "dark" => ThemeVariant.Dark,
            "light" => ThemeVariant.Light,
            "default" => ThemeVariant.Default,
            _ => throw new NotSupportedException(
                $"[{nameof(Arguments)}] Theme [{theme}] is not supported."
            ),
        };
}
