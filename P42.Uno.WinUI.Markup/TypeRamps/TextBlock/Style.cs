using Microsoft.UI.Xaml;

namespace P42.Uno.Markup.TypeRamps.TextBlock;

// https://learn.microsoft.com/en-us/windows/apps/develop/platform/xaml/xaml-theme-resources#the-xaml-type-ramp
// 

public static class TextBlockStyle
{
    public static Style? Caption => Application.Current.Resources["CaptionTextBlockStyle"] as Style;
    public static Style? Body => Application.Current.Resources["BodyTextBlockStyle"] as Style;
    public static Style? BodyStrong => Application.Current.Resources["BodyStrongTextBlockStyle"] as Style;
    public static Style? BodyLarge => Application.Current.Resources["BodyLargeTextBlockStyle"] as Style;
    public static Style? Subtitle => Application.Current.Resources["SubtitleTextBlockStyle"] as Style;
    public static Style? Title => Application.Current.Resources["TitleTextBlockStyle"] as Style;
    public static Style? TitleLarge => Application.Current.Resources["TitleLargeTextBlockStyle"] as Style;
    public static Style? Display => Application.Current.Resources["DisplayTextBlockStyle"] as Style;
}



