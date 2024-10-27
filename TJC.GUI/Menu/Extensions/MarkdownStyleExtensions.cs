using Avalonia.Styling;
using Markdown.Avalonia;

namespace TJC.GUI.Menu.Extensions;

internal static class MarkdownStyleExtensions
{
    /// <summary>
    /// On <seealso cref="MarkdownScrollViewer"/> set <seealso cref="MarkdownScrollViewer.MarkdownStyleName"/> instead of <seealso cref="MarkdownScrollViewer.MarkdownStyle"/>.
    /// <para></para>
    /// This is because <seealso cref="MarkdownScrollViewer.MarkdownStyle"/> can only be set once.
    /// </summary>
    /// <param name="style"></param>
    /// <returns></returns>
    internal static string GetStyleName(this Styles style)
    {
        return style.GetType().Name.Replace("MarkdownStyle", string.Empty);
    }
}