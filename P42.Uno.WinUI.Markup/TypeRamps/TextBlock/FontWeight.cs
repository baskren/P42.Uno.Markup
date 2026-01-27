using Windows.UI.Text;
using Microsoft.UI.Text;

namespace P42.Uno.WinUI.Markup;

// https://learn.microsoft.com/en-us/windows/apps/develop/platform/xaml/xaml-theme-resources#the-xaml-type-ramp
// 

// ReSharper disable once UnusedType.Global
public static class TextBlockFontWeight
{
    private static FontWeight? DCaption;
    public static FontWeight Caption => DCaption ??= TextBlockStyle.Caption.GetSetterValue(TextBlock.FontWeightProperty, FontWeights.Normal);
    
    private static FontWeight? DBody;
    public static FontWeight Body => DBody ??= TextBlockStyle.Body.GetSetterValue(TextBlock.FontWeightProperty, FontWeights.Normal);

    private static FontWeight? DBodyStrong;
    public static FontWeight BodyStrong => DBodyStrong ??= TextBlockStyle.BodyStrong.GetSetterValue(TextBlock.FontWeightProperty, FontWeights.SemiBold);

    private static FontWeight? DBodyLarge;
    public static FontWeight BodyLarge => DBodyLarge ??= TextBlockStyle.BodyLarge.GetSetterValue(TextBlock.FontWeightProperty, FontWeights.Normal);

    private static FontWeight? DSubTitle;
    public static FontWeight Subtitle => DSubTitle ??= TextBlockStyle.Subtitle.GetSetterValue(TextBlock.FontWeightProperty, FontWeights.SemiBold);
    
    private static FontWeight? DTitle;
    public static FontWeight Title => DTitle ??= TextBlockStyle.Title.GetSetterValue(TextBlock.FontWeightProperty, FontWeights.SemiBold);
    
    private static FontWeight? DTitleLarge;
    public static FontWeight TitleLarge => DTitleLarge ??= TextBlockStyle.TitleLarge.GetSetterValue(TextBlock.FontWeightProperty, FontWeights.SemiBold);
    
    private static FontWeight? DDisplay;
    public static FontWeight Display => DDisplay ??= TextBlockStyle.Display.GetSetterValue(TextBlock.FontWeightProperty, FontWeights.SemiBold);
}

