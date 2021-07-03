using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Text;
using Windows.UI.Xaml.Media;
using ElementType = Windows.UI.Xaml.Controls.FontIcon;

namespace P42.Uno.Markup
{
    public static class FontIconExtensions
    {
        public static TElement Glyph<TElement>(this TElement element, string stretch) where TElement : ElementType
        { element.Glyph = stretch; return element; }

        #region FontWeight
        public static TElement FontWeight<TElement>(this TElement element, FontWeight weight) where TElement : ElementType
        { element.FontWeight = weight; return element; }

        public static TElement Thin<TElement>(this TElement element) where TElement : ElementType
        { element.FontWeight = Windows.UI.Text.FontWeights.Thin; return element; }

        public static TElement ExtraLight<TElement>(this TElement element) where TElement : ElementType
        { element.FontWeight = Windows.UI.Text.FontWeights.ExtraLight; return element; }

        public static TElement Light<TElement>(this TElement element) where TElement : ElementType
        { element.FontWeight = Windows.UI.Text.FontWeights.Light; return element; }

        public static TElement SemiLight<TElement>(this TElement element) where TElement : ElementType
        { element.FontWeight = Windows.UI.Text.FontWeights.SemiLight; return element; }

        public static TElement NormalFontWeight<TElement>(this TElement element) where TElement : ElementType
        { element.FontWeight = Windows.UI.Text.FontWeights.Normal; return element; }

        public static TElement Medium<TElement>(this TElement element) where TElement : ElementType
        { element.FontWeight = Windows.UI.Text.FontWeights.Medium; return element; }

        public static TElement SemiBold<TElement>(this TElement element) where TElement : ElementType
        { element.FontWeight = Windows.UI.Text.FontWeights.SemiBold; return element; }

        public static TElement Bold<TElement>(this TElement element) where TElement : ElementType
        { element.FontWeight = Windows.UI.Text.FontWeights.Bold; return element; }

        public static TElement ExtraBold<TElement>(this TElement element) where TElement : ElementType
        { element.FontWeight = Windows.UI.Text.FontWeights.ExtraBold; return element; }

        public static TElement BlackFontWeight<TElement>(this TElement element) where TElement : ElementType
        { element.FontWeight = Windows.UI.Text.FontWeights.Black; return element; }

        public static TElement ExtraBlack<TElement>(this TElement element) where TElement : ElementType
        { element.FontWeight = Windows.UI.Text.FontWeights.ExtraBlack; return element; }
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
        public static TElement FontFamily<TElement>(this TElement element, FontFamily family) where TElement : ElementType
        { element.FontFamily = family; return element; }

        public static TElement FontFamily<TElement>(this TElement element, string family) where TElement : ElementType
        { element.FontFamily = new Windows.UI.Xaml.Media.FontFamily(family); return element; }
        #endregion

        public static TElement IsTextScaleFactorEnabled<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsTextScaleFactorEnabled = value; return element; }

        public static TElement MirroredWhenRightToLeft<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.MirroredWhenRightToLeft = value; return element; }


    }
}
