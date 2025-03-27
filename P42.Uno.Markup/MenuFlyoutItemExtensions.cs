using System;
using System.Windows.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using ElementType = Microsoft.UI.Xaml.Controls.MenuFlyoutItem;

namespace P42.Uno.Markup;

public static class MenuFlyoutItemExtensions
{

    public static TElement Command<TElement>(this TElement element, ICommand value) where TElement : ElementType
    { element.Command = value; return element; }


    public static TElement CommandParameter<TElement>(this TElement element, object value) where TElement : ElementType
    { element.CommandParameter = value; return element; }

    #region Icon
    public static TElement Icon<TElement>(this TElement element, IconElement value = null) where TElement : ElementType
    { element.Icon = value; return element; }

    public static TElement Icon<TElement>(this TElement element, Symbol value) where TElement : ElementType
    { element.Icon = new SymbolIcon { Symbol = value }; return element; }

    public static TElement Icon<TElement>(this TElement element, string glyph, Microsoft.UI.Xaml.Media.FontFamily fontFamily) where TElement : ElementType
    { element.Icon = new FontIcon { FontFamily = fontFamily, Glyph = glyph }; return element; }

    public static TElement Icon<TElement>(this TElement element, string glyph, string fontFamily) where TElement : ElementType
    { element.Icon = new FontIcon { FontFamily = new FontFamily(fontFamily), Glyph = glyph }; return element; }

    public static TElement Icon<TElement>(this TElement element, string glyph, Microsoft.UI.Xaml.Media.FontFamily fontFamily, double fontSize) where TElement : ElementType
    { element.Icon = new FontIcon { FontFamily = fontFamily, FontSize = fontSize, Glyph = glyph }; return element; }

    public static TElement Icon<TElement>(this TElement element, string glyph, string fontFamily, double fontSize) where TElement : ElementType
    { element.Icon = new FontIcon { FontFamily = new FontFamily(fontFamily), FontSize = fontSize, Glyph = glyph }; return element; }

    public static TElement Icon<TElement>(this TElement element, Geometry path) where TElement : ElementType
    { element.Icon = new PathIcon { Data = path }; return element; }

    public static TElement Icon<TElement>(this TElement element, Uri bitMapUriSource, bool showAsMonoChrome = true) where TElement : ElementType
    { element.Icon = new BitmapIcon { UriSource = bitMapUriSource, ShowAsMonochrome = showAsMonoChrome }; return element; }
    #endregion


    public static TElement KeyboardAcceleratorTextOverride<TElement>(this TElement element, string value) where TElement : ElementType
    { element.KeyboardAcceleratorTextOverride = value; return element; }

    public static TElement Text<TElement>(this TElement element, string value) where TElement : ElementType
    { element.Text = value; return element; }


    #region Events
    public static TElement OnClickHandler<TElement>(this TElement element, RoutedEventHandler click) where TElement : ElementType
    {
        element.Click += click;
        return element;
    }
    #endregion
}
