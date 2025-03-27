using System;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using ElementType = Microsoft.UI.Xaml.Controls.AppBarButton;


namespace P42.Uno.Markup
{

public static class AppBarButtonExtensions
{
    public static TElement Label<TElement>(this TElement element, string value = null) where TElement : ElementType
    { element.Label = value; return element; }

    #region Icon
    public static TElement Icon<TElement>(this TElement element, IconElement value = null) where TElement : ElementType
    { element.Icon = value; return element; }

    public static TElement Icon<TElement>(this TElement element, Symbol value) where TElement : ElementType
    { element.Icon = new SymbolIcon { Symbol = value }; return element; }

    public static TElement Icon<TElement>(this TElement element, string glyph, Microsoft.UI.Xaml.Media.FontFamily fontFamily) where TElement : ElementType
    { element.Icon = new FontIcon { FontFamily = fontFamily, Glyph = glyph }; return element; }

    public static TElement Icon<TElement>(this TElement element, string glyph, Microsoft.UI.Xaml.Media.FontFamily fontFamily, double fontSize) where TElement : ElementType
    { element.Icon = new FontIcon { FontFamily = fontFamily, FontSize = fontSize, Glyph = glyph }; return element; }

    public static TElement Icon<TElement>(this TElement element, Geometry path) where TElement : ElementType
    { element.Icon = new PathIcon { Data = path }; return element; }

    public static TElement Icon<TElement>(this TElement element, Uri bitMapUriSource, bool showAsMonoChrome = true) where TElement : ElementType
    { element.Icon = new BitmapIcon { UriSource = bitMapUriSource, ShowAsMonochrome = showAsMonoChrome }; return element; }
    #endregion

    public static TElement LabelCollapsed<TElement>(this TElement element, bool isCollapsed = true) where TElement : ElementType
    { element.LabelPosition = isCollapsed ? CommandBarLabelPosition.Collapsed : CommandBarLabelPosition.Default; return element; }

    public static TElement KeyboardAcceleratorTextOverride<TElement>(this TElement element, string textOverride) where TElement : ElementType
    { element.KeyboardAcceleratorTextOverride = textOverride; return element; }

    public static TElement Compact<TElement>(this TElement element, bool isCompact = true) where TElement : ElementType
    { element.IsCompact = isCompact; return element; }

    public static TElement DynamicOverflowOrder<TElement>(this TElement element, int index) where TElement : ElementType
    { element.DynamicOverflowOrder = index; return element; }

}
