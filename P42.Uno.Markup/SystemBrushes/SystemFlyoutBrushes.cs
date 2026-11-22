using Microsoft.UI.Xaml.Media;

namespace P42.Uno.Markup;

public static class SystemFlyoutBrushes
{
    public static Brush Background => ColorExtensions.AppBrush("FlyoutBackgroundThemeBrush");
    public static Brush Border => ColorExtensions.AppBrush("FlyoutBorderThemeBrush");
}