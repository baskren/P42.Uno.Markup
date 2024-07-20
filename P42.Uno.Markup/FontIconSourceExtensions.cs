using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Text;
using Microsoft.UI.Text;
using Microsoft.UI.Xaml.Media;
using ElementType = Microsoft.UI.Xaml.Controls.FontIconSource;

namespace P42.Uno.Markup
{
    public static class FontIconSourceExtensions
    {
        public static TElement Glyph<TElement>(this TElement element, string stretch) where TElement : ElementType
        { element.Glyph = stretch; return element; }

        #region FontWeight
        public static TElement FontWeight<TElement>(this TElement element, FontWeight weight) where TElement : ElementType
        { element.FontWeight = weight; return element; }

        public static TElement Thin<TElement>(this TElement element) where TElement : ElementType
        { element.FontWeight = FontWeights.Thin; return element; }

        public static TElement ExtraLight<TElement>(this TElement element) where TElement : ElementType
        { element.FontWeight = FontWeights.ExtraLight; return element; }

        public static TElement Light<TElement>(this TElement element) where TElement : ElementType
        { element.FontWeight = FontWeights.Light; return element; }

        public static TElement SemiLight<TElement>(this TElement element) where TElement : ElementType
        { element.FontWeight = FontWeights.SemiLight; return element; }

        public static TElement NormalFontWeight<TElement>(this TElement element) where TElement : ElementType
        { element.FontWeight = FontWeights.Normal; return element; }

        public static TElement Medium<TElement>(this TElement element) where TElement : ElementType
        { element.FontWeight = FontWeights.Medium; return element; }

        public static TElement SemiBold<TElement>(this TElement element) where TElement : ElementType
        { element.FontWeight = FontWeights.SemiBold; return element; }

        public static TElement Bold<TElement>(this TElement element) where TElement : ElementType
        { element.FontWeight = FontWeights.Bold; return element; }

        public static TElement ExtraBold<TElement>(this TElement element) where TElement : ElementType
        { element.FontWeight = FontWeights.ExtraBold; return element; }

        public static TElement BlackFontWeight<TElement>(this TElement element) where TElement : ElementType
        { element.FontWeight = FontWeights.Black; return element; }

        public static TElement ExtraBlack<TElement>(this TElement element) where TElement : ElementType
        { element.FontWeight = FontWeights.ExtraBlack; return element; }
        #endregion


        #region FontStyle
        public static TElement FontStyle<TElement>(this TElement element, FontStyle fontStyle) where TElement : ElementType
        { element.FontStyle = fontStyle; return element; }

        public static TElement NormalFontStyle<TElement>(this TElement element) where TElement : ElementType
        { element.FontStyle = Windows.UI.Text.FontStyle.Normal; return element; }

        public static TElement Oblique<TElement>(this TElement element) where TElement : ElementType
        { element.FontStyle = Windows.UI.Text.FontStyle.Oblique; return element; }

        public static TElement Italic<TElement>(this TElement element) where TElement : ElementType
        { element.FontStyle = Windows.UI.Text.FontStyle.Italic; return element; }
        #endregion


        public static TElement FontSize<TElement>(this TElement element, double size) where TElement : ElementType
        { element.FontSize = size; return element; }


        #region FontFamily
        public static TElement FontFamily<TElement>(this TElement element, Microsoft.UI.Xaml.Media.FontFamily family) where TElement : ElementType
        { element.FontFamily = family; return element; }

        public static TElement FontFamily<TElement>(this TElement element, string family) where TElement : ElementType
        { element.FontFamily = new FontFamily(family); return element; }
        #endregion

        public static TElement TextScaleFactorEnabled<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsTextScaleFactorEnabled = value; return element; }

        public static TElement MirroredWhenRightToLeft<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.MirroredWhenRightToLeft = value; return element; }


    }
}
