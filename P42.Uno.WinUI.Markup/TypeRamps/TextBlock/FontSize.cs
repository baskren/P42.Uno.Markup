namespace P42.Uno.WinUI.Markup;

// https://learn.microsoft.com/en-us/windows/apps/develop/platform/xaml/xaml-theme-resources#the-xaml-type-ramp
// 

// ReSharper disable once UnusedType.Global
public static class TextBlockFontSize
{

    private static double? DCaption;
    public static double Caption => DCaption ??= TextBlockStyle.Caption.GetSetterValue(TextBlock.FontSizeProperty, 12.0);
    
    private static double? DBody;
    public static double Body => DBody ??= TextBlockStyle.Body.GetSetterValue(TextBlock.FontSizeProperty, 14.0);
    
    private static double? DBodyStrong;
    public static double BodyStrong => DBodyStrong ??= TextBlockStyle.BodyStrong.GetSetterValue(TextBlock.FontSizeProperty, 14.0);

    private static double? DBodyLarge;
    public static double BodyLarge => DBodyLarge ??= TextBlockStyle.BodyLarge.GetSetterValue(TextBlock.FontSizeProperty, 18.0);

    private static double? DSubtitle;
    public static double Subtitle => DSubtitle ??= TextBlockStyle.Subtitle.GetSetterValue(TextBlock.FontSizeProperty, 20.0);
    
    private static double? DTitle;
    public static double Title => DTitle ??= TextBlockStyle.Title.GetSetterValue(TextBlock.FontSizeProperty, 28.0);
    
    private static double? DTitleLarge;
    public static double TitleLarge => DTitleLarge ??= TextBlockStyle.TitleLarge.GetSetterValue(TextBlock.FontSizeProperty, 40.0);
    
    private static double? DDisplay;
    public static double Display => DDisplay ??= TextBlockStyle.Display.GetSetterValue(TextBlock.FontSizeProperty, 68.0);
}

