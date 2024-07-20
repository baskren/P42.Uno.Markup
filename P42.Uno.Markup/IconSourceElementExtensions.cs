using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Text;
using Microsoft.UI;
using Microsoft.UI.Text;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using ElementType = Microsoft.UI.Xaml.Controls.IconSourceElement;

namespace P42.Uno.Markup
{
    public static class IconSourceElementExtensions
    {
        #region IconSource
        public static TElement IconSource<TElement>(this TElement element, IconSource iconSource) where TElement : ElementType
        { element.IconSource = iconSource; return element; }

        public static TElement IconSource<TElement>(this TElement element, Symbol value) where TElement : ElementType
        { element.IconSource = new SymbolIconSource { Symbol = value }; return element; }

        public static TElement IconSource<TElement>(this TElement element, string glyph, Microsoft.UI.Xaml.Media.FontFamily fontFamily) where TElement : ElementType
        { element.IconSource = new FontIconSource { FontFamily = fontFamily, Glyph = glyph }; return element; }

        public static TElement IconSource<TElement>(this TElement element, string glyph, string fontFamily) where TElement : ElementType
        { element.IconSource = new FontIconSource { FontFamily = new FontFamily(fontFamily), Glyph = glyph }; return element; }

        public static TElement IconSource<TElement>(this TElement element, string glyph, Microsoft.UI.Xaml.Media.FontFamily fontFamily, double fontSize) where TElement : ElementType
        { element.IconSource = new FontIconSource { FontFamily = fontFamily, FontSize = fontSize, Glyph = glyph }; return element; }

        public static TElement IconSource<TElement>(this TElement element, string glyph, string fontFamily, double fontSize) where TElement : ElementType
        { element.IconSource = new FontIconSource { FontFamily = new FontFamily(fontFamily), FontSize = fontSize, Glyph = glyph }; return element; }

        public static TElement IconSource<TElement>(this TElement element, Geometry path) where TElement : ElementType
        { element.IconSource = new PathIconSource { Data = path }; return element; }

        public static TElement IconSource<TElement>(this TElement element, Uri bitMapUriSource, bool showAsMonoChrome = true) where TElement : ElementType
        { element.IconSource = new BitmapIconSource { UriSource = bitMapUriSource, ShowAsMonochrome = showAsMonoChrome }; return element; }
        #endregion

    }
}
