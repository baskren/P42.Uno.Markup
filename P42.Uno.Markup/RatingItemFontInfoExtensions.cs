using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI;
using Windows.UI;
using ElementType = Microsoft.UI.Xaml.Controls.RatingItemFontInfo;

namespace P42.Uno.Markup;
public static class RatingItemFontInfoExtensions
{
    public static TElement DisabledGlyph<TElement>(this TElement element, string value) where TElement : ElementType
    { element.DisabledGlyph = value; return element; }

    public static TElement Glyph<TElement>(this TElement element, string value) where TElement : ElementType
    { element.Glyph = value; return element; }

    public static TElement PlaceholderGlyph<TElement>(this TElement element, string value) where TElement : ElementType
    { element.PlaceholderGlyph = value; return element; }

    public static TElement PointerOverGlyph<TElement>(this TElement element, string value) where TElement : ElementType
    { element.PointerOverGlyph = value; return element; }

    public static TElement PointerOverPlaceholderGlyph<TElement>(this TElement element, string value) where TElement : ElementType
    { element.PointerOverPlaceholderGlyph = value; return element; }

    public static TElement UnsetGlyph<TElement>(this TElement element, string value) where TElement : ElementType
    { element.UnsetGlyph = value; return element; }

}
