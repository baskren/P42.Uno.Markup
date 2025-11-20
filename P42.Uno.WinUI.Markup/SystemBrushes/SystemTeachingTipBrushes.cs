using P42.Utils.Uno;

namespace P42.Uno.WinUI.Markup;

// XAML theme resources
// The XAML color ramp and theme-dependent brushes
// Light and Dark theme colors
// https://github.com/microsoft/microsoft-ui-xaml/blob/main/dev/CommonStyles/Button_themeresources.xaml
// ReSharper disable once UnusedType.Global
public static class SystemTeachingTipBrushes
{
    public static Brush Background => ColorExtensions.AppBrush("SystemControlPageBackgroundChromeLowBrush");

    public static Brush Foreground => ColorExtensions.AppBrush("SystemControlForegroundBaseHighBrush");

    public static Brush Border => ColorExtensions.AppBrush("SystemControlTransientBorderBrush");

}
