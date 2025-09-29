using Microsoft.UI.Text;
using P42.Uno.WinUI.Markup;
using Windows.UI.Text;

namespace P42.Uno.Markup.TypeRamps.TextBlock;

// https://learn.microsoft.com/en-us/windows/apps/develop/platform/xaml/xaml-theme-resources#the-xaml-type-ramp
// 

public static class TextBlockFontWeight
{
    public static FontWeight Caption => TextBlockStyle.Caption.GetSetterValue(Microsoft.UI.Xaml.Controls.TextBlock.FontWeightProperty, FontWeights.Normal);
    public static FontWeight Body => TextBlockStyle.Body.GetSetterValue(Microsoft.UI.Xaml.Controls.TextBlock.FontWeightProperty, FontWeights.Normal);
    public static FontWeight BodyStrong => TextBlockStyle.BodyStrong.GetSetterValue(Microsoft.UI.Xaml.Controls.TextBlock.FontWeightProperty, FontWeights.SemiBold);
    public static FontWeight BodyLarge => TextBlockStyle.BodyLarge.GetSetterValue(Microsoft.UI.Xaml.Controls.TextBlock.FontWeightProperty, FontWeights.Normal);
    public static FontWeight Subtitle => TextBlockStyle.Subtitle.GetSetterValue(Microsoft.UI.Xaml.Controls.TextBlock.FontWeightProperty, FontWeights.SemiBold);
    public static FontWeight Title => TextBlockStyle.Title.GetSetterValue(Microsoft.UI.Xaml.Controls.TextBlock.FontWeightProperty, FontWeights.SemiBold);
    public static FontWeight TitleLarge => TextBlockStyle.TitleLarge.GetSetterValue(Microsoft.UI.Xaml.Controls.TextBlock.FontWeightProperty, FontWeights.SemiBold);
    public static FontWeight Display => TextBlockStyle.Display.GetSetterValue(Microsoft.UI.Xaml.Controls.TextBlock.FontWeightProperty, FontWeights.SemiBold);
}

