namespace P42.Uno.WinUI.Markup;

// https://learn.microsoft.com/en-us/windows/apps/develop/platform/xaml/xaml-theme-resources#the-xaml-type-ramp
// 

// ReSharper disable once UnusedType.Global
public static class TextBlockOpticalMarginAlignment
{
    
    private static OpticalMarginAlignment? MCaption;
    public static OpticalMarginAlignment Caption => MCaption ??= TextBlockStyle.Caption.GetSetterValue(TextBlock.OpticalMarginAlignmentProperty, OpticalMarginAlignment.None);

    private static OpticalMarginAlignment? MBody;
    public static OpticalMarginAlignment Body => MBody ??= TextBlockStyle.Body.GetSetterValue(TextBlock.OpticalMarginAlignmentProperty, OpticalMarginAlignment.None);
    
    private static OpticalMarginAlignment? MBodyStrong;
    public static OpticalMarginAlignment BodyStrong => MBodyStrong ??= TextBlockStyle.BodyStrong.GetSetterValue(TextBlock.OpticalMarginAlignmentProperty, OpticalMarginAlignment.TrimSideBearings);

    private static OpticalMarginAlignment? MBodyLarge;
    public static OpticalMarginAlignment BodyLarge => MBodyLarge ??= TextBlockStyle.BodyLarge.GetSetterValue(TextBlock.OpticalMarginAlignmentProperty, OpticalMarginAlignment.TrimSideBearings);
    
    private static OpticalMarginAlignment? MSubtitle;
    public static OpticalMarginAlignment Subtitle => MSubtitle ??= TextBlockStyle.Subtitle.GetSetterValue(TextBlock.OpticalMarginAlignmentProperty, OpticalMarginAlignment.TrimSideBearings);

    private static OpticalMarginAlignment? MTitle;
    public static OpticalMarginAlignment Title => MTitle ??= TextBlockStyle.Title.GetSetterValue(TextBlock.OpticalMarginAlignmentProperty, OpticalMarginAlignment.TrimSideBearings);

    private static OpticalMarginAlignment? MTitleLarge;
    public static OpticalMarginAlignment TitleLarge => MTitleLarge ??= TextBlockStyle.TitleLarge.GetSetterValue(TextBlock.OpticalMarginAlignmentProperty, OpticalMarginAlignment.TrimSideBearings);

    private static OpticalMarginAlignment? MDisplay;
    public static OpticalMarginAlignment Display => MDisplay ??= TextBlockStyle.Display.GetSetterValue(TextBlock.OpticalMarginAlignmentProperty, OpticalMarginAlignment.TrimSideBearings);
}

