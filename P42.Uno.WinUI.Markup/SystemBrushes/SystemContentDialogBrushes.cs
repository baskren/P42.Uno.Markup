using P42.Utils.Uno;

namespace P42.Uno.WinUI.Markup;

// Full list of system brushes found here: https://github.com/MicrosoftDocs/windows-uwp/issues/2072
// ReSharper disable once UnusedType.Global
public static class SystemContentDialogBrushes
{
    public static Brush Background => ColorExtensions.AppBrush("ContentDialogBackground");
    public static Brush Border => ColorExtensions.AppBrush("ContentDialogBorderBrush");
    public static Brush Foreground => ColorExtensions.AppBrush("ContentDialogForeground");
    public static Brush Dimming => ColorExtensions.AppBrush("ContentDialogDimmingThemeBrush");
}
