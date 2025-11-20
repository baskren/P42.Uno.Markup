using Microsoft.UI.Text;
using Windows.UI.Text;

namespace P42.Uno.WinUI.Markup;

// https://learn.microsoft.com/en-us/windows/apps/develop/platform/xaml/xaml-theme-resources#the-xaml-type-ramp
// 

// ReSharper disable once UnusedType.Global
public static class TextBlockFontWeight
{
    public static FontWeight Caption => TextBlockStyle.Caption.GetSetterValue(TextBlock.FontWeightProperty, FontWeights.Normal);
    public static FontWeight Body => TextBlockStyle.Body.GetSetterValue(TextBlock.FontWeightProperty, FontWeights.Normal);
    public static FontWeight BodyStrong => TextBlockStyle.BodyStrong.GetSetterValue(TextBlock.FontWeightProperty, FontWeights.SemiBold);
    public static FontWeight BodyLarge => TextBlockStyle.BodyLarge.GetSetterValue(TextBlock.FontWeightProperty, FontWeights.Normal);
    public static FontWeight Subtitle => TextBlockStyle.Subtitle.GetSetterValue(TextBlock.FontWeightProperty, FontWeights.SemiBold);
    public static FontWeight Title => TextBlockStyle.Title.GetSetterValue(TextBlock.FontWeightProperty, FontWeights.SemiBold);
    public static FontWeight TitleLarge => TextBlockStyle.TitleLarge.GetSetterValue(TextBlock.FontWeightProperty, FontWeights.SemiBold);
    public static FontWeight Display => TextBlockStyle.Display.GetSetterValue(TextBlock.FontWeightProperty, FontWeights.SemiBold);
}

