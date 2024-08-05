using System;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using ElementType = Microsoft.UI.Xaml.Controls.TabViewItemTemplateSettings;

namespace P42.Uno.Markup;
public static class TabViewItemTemplateSettingsExtensions
{
    #region Icon
    public static TElement Icon<TElement>(this TElement element, IconElement value = null) where TElement : ElementType
    { element.IconElement = value; return element; }

    public static TElement Icon<TElement>(this TElement element, Symbol value) where TElement : ElementType
    { element.IconElement = new SymbolIcon { Symbol = value }; return element; }

    public static TElement Icon<TElement>(this TElement element, string glyph, Microsoft.UI.Xaml.Media.FontFamily fontFamily) where TElement : ElementType
    { element.IconElement = new FontIcon { FontFamily = fontFamily, Glyph = glyph }; return element; }

    public static TElement Icon<TElement>(this TElement element, string glyph, string fontFamily) where TElement : ElementType
    { element.IconElement = new FontIcon { FontFamily = new FontFamily(fontFamily), Glyph = glyph }; return element; }

    public static TElement Icon<TElement>(this TElement element, string glyph, Microsoft.UI.Xaml.Media.FontFamily fontFamily, double fontSize) where TElement : ElementType
    { element.IconElement = new FontIcon { FontFamily = fontFamily, FontSize=fontSize, Glyph = glyph }; return element; }

    public static TElement Icon<TElement>(this TElement element, string glyph, string fontFamily, double fontSize) where TElement : ElementType
    { element.IconElement = new FontIcon { FontFamily = new FontFamily(fontFamily), FontSize = fontSize, Glyph = glyph }; return element; }

    public static TElement Icon<TElement>(this TElement element, Geometry path) where TElement : ElementType
    { element.IconElement = new PathIcon { Data = path }; return element; }

    public static TElement Icon<TElement>(this TElement element, Uri bitMapUriSource, bool showAsMonoChrome = true) where TElement : ElementType
    { element.IconElement = new BitmapIcon { UriSource = bitMapUriSource, ShowAsMonochrome = showAsMonoChrome }; return element; }
    #endregion

    public static TElement TabGeometry<TElement>(this TElement element, Geometry geometry) where TElement : ElementType
    { element.TabGeometry = geometry; return element; }
}
