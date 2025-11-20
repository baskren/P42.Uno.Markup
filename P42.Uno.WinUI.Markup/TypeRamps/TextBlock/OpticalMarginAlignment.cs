namespace P42.Uno.WinUI.Markup;

// https://learn.microsoft.com/en-us/windows/apps/develop/platform/xaml/xaml-theme-resources#the-xaml-type-ramp
// 

// ReSharper disable once UnusedType.Global
public static class TextBlockOpticalMarginAlignment
{
    public static OpticalMarginAlignment Caption => TextBlockStyle.Caption.GetSetterValue(TextBlock.OpticalMarginAlignmentProperty, OpticalMarginAlignment.None);
    public static OpticalMarginAlignment Body => TextBlockStyle.Body.GetSetterValue(TextBlock.OpticalMarginAlignmentProperty, OpticalMarginAlignment.None);
    public static OpticalMarginAlignment BodyStrong => TextBlockStyle.BodyStrong.GetSetterValue(TextBlock.OpticalMarginAlignmentProperty, OpticalMarginAlignment.TrimSideBearings);
    public static OpticalMarginAlignment BodyLarge => TextBlockStyle.BodyLarge.GetSetterValue(TextBlock.OpticalMarginAlignmentProperty, OpticalMarginAlignment.TrimSideBearings);
    public static OpticalMarginAlignment Subtitle => TextBlockStyle.Subtitle.GetSetterValue(TextBlock.OpticalMarginAlignmentProperty, OpticalMarginAlignment.TrimSideBearings);
    public static OpticalMarginAlignment Title => TextBlockStyle.Title.GetSetterValue(TextBlock.OpticalMarginAlignmentProperty, OpticalMarginAlignment.TrimSideBearings);
    public static OpticalMarginAlignment TitleLarge => TextBlockStyle.TitleLarge.GetSetterValue(TextBlock.OpticalMarginAlignmentProperty, OpticalMarginAlignment.TrimSideBearings);
    public static OpticalMarginAlignment Display => TextBlockStyle.Display.GetSetterValue(TextBlock.OpticalMarginAlignmentProperty, OpticalMarginAlignment.TrimSideBearings);
}

