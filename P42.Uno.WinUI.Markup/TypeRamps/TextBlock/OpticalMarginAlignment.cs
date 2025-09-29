using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Text;
using Microsoft.UI.Xaml;
using P42.Uno.WinUI.Markup;
using Windows.UI.Text;

namespace P42.Uno.Markup.TypeRamps.TextBlock;

// https://learn.microsoft.com/en-us/windows/apps/develop/platform/xaml/xaml-theme-resources#the-xaml-type-ramp
// 

public static class TextBlockOpticalMarginAlignment
{
    public static OpticalMarginAlignment Caption => TextBlockStyle.Caption.GetSetterValue(Microsoft.UI.Xaml.Controls.TextBlock.OpticalMarginAlignmentProperty, OpticalMarginAlignment.None);
    public static OpticalMarginAlignment Body => TextBlockStyle.Body.GetSetterValue(Microsoft.UI.Xaml.Controls.TextBlock.OpticalMarginAlignmentProperty, OpticalMarginAlignment.None);
    public static OpticalMarginAlignment BodyStrong => TextBlockStyle.BodyStrong.GetSetterValue(Microsoft.UI.Xaml.Controls.TextBlock.OpticalMarginAlignmentProperty, OpticalMarginAlignment.TrimSideBearings);
    public static OpticalMarginAlignment BodyLarge => TextBlockStyle.BodyLarge.GetSetterValue(Microsoft.UI.Xaml.Controls.TextBlock.OpticalMarginAlignmentProperty, OpticalMarginAlignment.TrimSideBearings);
    public static OpticalMarginAlignment Subtitle => TextBlockStyle.Subtitle.GetSetterValue(Microsoft.UI.Xaml.Controls.TextBlock.OpticalMarginAlignmentProperty, OpticalMarginAlignment.TrimSideBearings);
    public static OpticalMarginAlignment Title => TextBlockStyle.Title.GetSetterValue(Microsoft.UI.Xaml.Controls.TextBlock.OpticalMarginAlignmentProperty, OpticalMarginAlignment.TrimSideBearings);
    public static OpticalMarginAlignment TitleLarge => TextBlockStyle.TitleLarge.GetSetterValue(Microsoft.UI.Xaml.Controls.TextBlock.OpticalMarginAlignmentProperty, OpticalMarginAlignment.TrimSideBearings);
    public static OpticalMarginAlignment Display => TextBlockStyle.Display.GetSetterValue(Microsoft.UI.Xaml.Controls.TextBlock.OpticalMarginAlignmentProperty, OpticalMarginAlignment.TrimSideBearings);
}

