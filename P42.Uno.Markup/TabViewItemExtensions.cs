using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Windows.Foundation;
using ElementType = Microsoft.UI.Xaml.Controls.TabViewItem;

namespace P42.Uno.Markup;
public static class TabViewItemExtensions
{
    public static TElement Header<TElement>(this TElement element, object value) where TElement : ElementType
    { element.Header = value; return element; }

    public static TElement HeaderTemplate<TElement>(this TElement element, DataTemplate value) where TElement : ElementType
    { element.HeaderTemplate = value; return element; }

    #region IconSource
    public static TElement Icon<TElement>(this TElement element, IconSource value = null) where TElement : ElementType
    { element.IconSource = value; return element; }

    public static TElement Icon<TElement>(this TElement element, Symbol value) where TElement : ElementType
    { element.IconSource = new SymbolIconSource { Symbol = value }; return element; }

    public static TElement Icon<TElement>(this TElement element, string glyph, Microsoft.UI.Xaml.Media.FontFamily fontFamily) where TElement : ElementType
    { element.IconSource = new FontIconSource { FontFamily = fontFamily, Glyph = glyph }; return element; }

    public static TElement Icon<TElement>(this TElement element, string glyph, string fontFamily) where TElement : ElementType
    { element.IconSource = new FontIconSource { FontFamily = new FontFamily(fontFamily), Glyph = glyph }; return element; }

    public static TElement Icon<TElement>(this TElement element, string glyph, Microsoft.UI.Xaml.Media.FontFamily fontFamily, double fontSize) where TElement : ElementType
    { element.IconSource = new FontIconSource { FontFamily = fontFamily, FontSize = fontSize, Glyph = glyph }; return element; }

    public static TElement Icon<TElement>(this TElement element, string glyph, string fontFamily, double fontSize) where TElement : ElementType
    { element.IconSource = new FontIconSource { FontFamily = new FontFamily(fontFamily), FontSize = fontSize, Glyph = glyph }; return element; }

    public static TElement Icon<TElement>(this TElement element, Geometry path) where TElement : ElementType
    { element.IconSource = new PathIconSource { Data = path }; return element; }

    public static TElement Icon<TElement>(this TElement element, Uri bitMapUriSource, bool showAsMonoChrome = true) where TElement : ElementType
    { element.IconSource = new BitmapIconSource { UriSource = bitMapUriSource, ShowAsMonochrome = showAsMonoChrome }; return element; }
    #endregion

    public static TElement IsClosable<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsClosable = value; return element; }


    #region Events
    public static TElement AddCloseRequestedHandler<TElement>(this TElement element, TypedEventHandler<TabViewItem, TabViewTabCloseRequestedEventArgs> value) where TElement : ElementType
    { element.CloseRequested += value; return element; }
    #endregion
}
