namespace P42.Uno.WinUI.Markup;

// https://learn.microsoft.com/en-us/windows/apps/develop/platform/xaml/xaml-theme-resources#the-xaml-type-ramp
// 

// ReSharper disable once UnusedType.Global
public static class TextBlockFontSize
{
    public static double Caption => TextBlockStyle.Caption.GetSetterValue(TextBlock.FontSizeProperty, 12.0);
    public static double Body => TextBlockStyle.Body.GetSetterValue(TextBlock.FontSizeProperty, 14.0);
    public static double BodyStrong => TextBlockStyle.BodyStrong.GetSetterValue(TextBlock.FontSizeProperty, 14.0);
    public static double BodyLarge => TextBlockStyle.BodyLarge.GetSetterValue(TextBlock.FontSizeProperty, 18.0);
    public static double Subtitle => TextBlockStyle.Subtitle.GetSetterValue(TextBlock.FontSizeProperty, 20.0);
    public static double Title => TextBlockStyle.Title.GetSetterValue(TextBlock.FontSizeProperty, 28.0);
    public static double TitleLarge => TextBlockStyle.TitleLarge.GetSetterValue(TextBlock.FontSizeProperty, 40.0);
    public static double Display => TextBlockStyle.Display.GetSetterValue(TextBlock.FontSizeProperty, 68.0);
}

