using P42.Uno.WinUI.Markup;

namespace P42.Uno.Markup.TypeRamps.TextBlock;

// https://learn.microsoft.com/en-us/windows/apps/develop/platform/xaml/xaml-theme-resources#the-xaml-type-ramp
// 

public static class TextBlockFontSize
{
    public static double Caption => TextBlockStyle.Caption.GetSetterValue(Microsoft.UI.Xaml.Controls.TextBlock.FontSizeProperty, 12.0);
    public static double Body => TextBlockStyle.Body.GetSetterValue(Microsoft.UI.Xaml.Controls.TextBlock.FontSizeProperty, 14.0);
    public static double BodyStrong => TextBlockStyle.BodyStrong.GetSetterValue(Microsoft.UI.Xaml.Controls.TextBlock.FontSizeProperty, 14.0);
    public static double BodyLarge => TextBlockStyle.BodyLarge.GetSetterValue(Microsoft.UI.Xaml.Controls.TextBlock.FontSizeProperty, 18.0);
    public static double Subtitle => TextBlockStyle.Subtitle.GetSetterValue(Microsoft.UI.Xaml.Controls.TextBlock.FontSizeProperty, 20.0);
    public static double Title => TextBlockStyle.Title.GetSetterValue(Microsoft.UI.Xaml.Controls.TextBlock.FontSizeProperty, 28.0);
    public static double TitleLarge => TextBlockStyle.TitleLarge.GetSetterValue(Microsoft.UI.Xaml.Controls.TextBlock.FontSizeProperty, 40.0);
    public static double Display => TextBlockStyle.Display.GetSetterValue(Microsoft.UI.Xaml.Controls.TextBlock.FontSizeProperty, 68.0);
}

