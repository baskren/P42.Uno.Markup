using P42.Utils.Uno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using ElementType = Windows.UI.Xaml.Controls.ContentPresenter;

namespace P42.Uno.Markup
{
    public static class ContentPresenterExtensions
    {
        #region Foreground
        public static TElement Foreground<TElement>(this TElement element, Brush brush) where TElement : ElementType
        { element.Foreground = brush; return element; }

        public static TElement Foreground<TElement>(this TElement element, Color color) where TElement : ElementType
        { element.Foreground = new SolidColorBrush(color); return element; }

        public static TElement Foreground<TElement>(this TElement element, string hex) where TElement : ElementType
        { element.Foreground = new SolidColorBrush(P42.Utils.Uno.ColorExtensions.ColorFromHex(hex)); return element; }
        #endregion


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

        public static TElement NormalFontWieght<TElement>(this TElement element) where TElement : ElementType
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


        #region FontStretch
        public static TElement FontStretch<TElement>(this TElement element, FontStretch stretch) where TElement : ElementType
        { element.FontStretch = stretch; return element; }

        public static TElement FontStretch<TElement>(this TElement element) where TElement : ElementType
        { element.FontStretch = Windows.UI.Text.FontStretch.Undefined; return element; }

        public static TElement UltraCondensed<TElement>(this TElement element) where TElement : ElementType
        { element.FontStretch = Windows.UI.Text.FontStretch.UltraCondensed; return element; }

        public static TElement ExtraCondensed<TElement>(this TElement element) where TElement : ElementType
        { element.FontStretch = Windows.UI.Text.FontStretch.ExtraCondensed; return element; }

        public static TElement Condensed<TElement>(this TElement element) where TElement : ElementType
        { element.FontStretch = Windows.UI.Text.FontStretch.Condensed; return element; }

        public static TElement SemiCondensed<TElement>(this TElement element) where TElement : ElementType
        { element.FontStretch = Windows.UI.Text.FontStretch.SemiCondensed; return element; }

        public static TElement NormalFontStretch<TElement>(this TElement element) where TElement : ElementType
        { element.FontStretch = Windows.UI.Text.FontStretch.Normal; return element; }

        public static TElement SemiExpanded<TElement>(this TElement element) where TElement : ElementType
        { element.FontStretch = Windows.UI.Text.FontStretch.SemiExpanded; return element; }

        public static TElement Expanded<TElement>(this TElement element) where TElement : ElementType
        { element.FontStretch = Windows.UI.Text.FontStretch.Expanded; return element; }

        public static TElement ExtraExpanded<TElement>(this TElement element) where TElement : ElementType
        { element.FontStretch = Windows.UI.Text.FontStretch.ExtraExpanded; return element; }

        public static TElement UltraExpanded<TElement>(this TElement element) where TElement : ElementType
        { element.FontStretch = Windows.UI.Text.FontStretch.UltraExpanded; return element; }
        #endregion


        public static TElement FontSize<TElement>(this TElement element, double size) where TElement : ElementType
        { element.FontSize = size; return element; }


        #region FontFamily
        public static TElement FontFamily<TElement>(this TElement element, FontFamily family) where TElement : ElementType
        { element.FontFamily = family; return element; }

        public static TElement FontFamily<TElement>(this TElement element, string family) where TElement : ElementType
        { element.FontFamily = new Windows.UI.Xaml.Media.FontFamily(family); return element; }
        #endregion


        public static TElement ContentTransitions<TElement>(this TElement element, TransitionCollection transitions) where TElement : ElementType
        { element.ContentTransitions = transitions; return element; }

        public static TElement ContentTemplateSelector<TElement>(this TElement element, DataTemplateSelector value) where TElement : ElementType
        { element.ContentTemplateSelector = value; return element; }

        public static TElement ContentTemplate<TElement>(this TElement element, DataTemplate value) where TElement : ElementType
        { element.ContentTemplate = value; return element; }

        public static TElement Content<TElement>(this TElement element, UIElement value) where TElement : ElementType
        { element.Content = value; return element; }

        public static TElement CharacterSpacing<TElement>(this TElement element, int ems) where TElement : ElementType
        { element.CharacterSpacing = ems; return element; }

        public static TElement TextLineBounds<TElement>(this TElement element, TextLineBounds value) where TElement : ElementType
        { element.TextLineBounds = value; return element; }

        public static TElement OpticalMarginAlignment<TElement>(this TElement element, OpticalMarginAlignment value) where TElement : ElementType
        { element.OpticalMarginAlignment = value; return element; }

        public static TElement IsTextScaleFactorEnabled<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsTextScaleFactorEnabled = value; return element; }

        public static TElement TextWrapping<TElement>(this TElement element, TextWrapping value) where TElement : ElementType
        { element.TextWrapping = value; return element; }

        #region Padding
        public static TElement Padding<TElement>(this TElement element, double value) where TElement : ElementType
        { element.Padding = new Thickness(value); return element; }

        public static TElement Padding<TElement>(this TElement element, double horizontal, double vertical) where TElement : ElementType
        { element.Padding = new Thickness(horizontal, vertical, horizontal, vertical); return element; }

        public static TElement Padding<TElement>(this TElement element, double left, double top, double right, double bottom) where TElement : ElementType
        { element.Padding = new Thickness(left, top, right, bottom); return element; }

        public static TElement Padding<TElement>(this TElement element, Thickness padding) where TElement : ElementType
        { element.Padding = padding; return element; }
        #endregion

        public static TElement MaxLines<TElement>(this TElement element, int value) where TElement : ElementType
        { element.MaxLines = value; return element; }

        public static TElement LineStackingStrategy<TElement>(this TElement element, LineStackingStrategy strategy) where TElement : ElementType
        { element.LineStackingStrategy = strategy; return element; }

        public static TElement LineHeight<TElement>(this TElement element, double height) where TElement : ElementType
        { element.LineHeight = height; return element; }


        #region Content Alignment

        public static TElement ContentCenter<TElement>(this TElement element) where TElement : ElementType
        {
            element.HorizontalContentAlignment = HorizontalAlignment.Center;
            element.VerticalContentAlignment = VerticalAlignment.Center;
            return element;
        }

        public static TElement ContentStretch<TElement>(this TElement element) where TElement : ElementType
        {
            element.HorizontalContentAlignment = HorizontalAlignment.Stretch;
            element.VerticalContentAlignment = VerticalAlignment.Stretch;
            return element;
        }

        #region Horizontal
        public static TElement HorizontalContentAlignment<TElement>(this TElement element, HorizontalAlignment value) where TElement : ElementType
        { element.HorizontalContentAlignment = value; return element; }

        public static TElement ContentLeft<TElement>(this TElement element) where TElement : ElementType
        { element.HorizontalContentAlignment = HorizontalAlignment.Left; return element; }

        public static TElement ContentRight<TElement>(this TElement element) where TElement : ElementType
        { element.HorizontalContentAlignment = HorizontalAlignment.Right; return element; }

        public static TElement ContentHorizontalCenter<TElement>(this TElement element) where TElement : ElementType
        { element.HorizontalContentAlignment = HorizontalAlignment.Center; return element; }

        public static TElement ContentHorizontalStretch<TElement>(this TElement element) where TElement : ElementType
        { element.HorizontalContentAlignment = HorizontalAlignment.Stretch; return element; }
        #endregion

        #region Vertical
        public static TElement VerticalContentAlignment<TElement>(this TElement element, VerticalAlignment value) where TElement : ElementType
        { element.VerticalContentAlignment = value; return element; }

        public static TElement ContentTop<TElement>(this TElement element) where TElement : ElementType
        { element.VerticalContentAlignment = VerticalAlignment.Top; return element; }

        public static TElement ContentBottom<TElement>(this TElement element) where TElement : ElementType
        { element.VerticalContentAlignment = VerticalAlignment.Bottom; return element; }

        public static TElement ContentVerticalCenter<TElement>(this TElement element) where TElement : ElementType
        { element.VerticalContentAlignment = VerticalAlignment.Center; return element; }

        public static TElement ContentVerticalStretch<TElement>(this TElement element) where TElement : ElementType
        { element.VerticalContentAlignment = VerticalAlignment.Stretch; return element; }

        #endregion

        #endregion


        #region CornerRadius
        public static TElement CornerRadius<TElement>(this TElement element, double value) where TElement : ElementType
        { element.CornerRadius = new CornerRadius(value); return element; }

        public static TElement CornerRadius<TElement>(this TElement element, double topLeft, double topRight, double bottomRight, double bottomLeft) where TElement : ElementType
        { element.CornerRadius = new CornerRadius(topLeft, topRight, bottomRight, bottomLeft); return element; }

        public static TElement CornerRadius<TElement>(this TElement element, CornerRadius padding) where TElement : ElementType
        { element.CornerRadius = padding; return element; }
        #endregion


        #region Border Thickness
        public static TElement BorderThickness<TElement>(this TElement element, double value) where TElement : ElementType
        { element.BorderThickness = new Thickness(value); return element; }

        public static TElement BorderThickness<TElement>(this TElement element, double horizontal, double vertical) where TElement : ElementType
        { element.BorderThickness = new Thickness(horizontal, vertical, horizontal, vertical); return element; }

        public static TElement BorderThickness<TElement>(this TElement element, double left, double top, double right, double bottom) where TElement : ElementType
        { element.BorderThickness = new Thickness(left, top, right, bottom); return element; }

        public static TElement BorderThickness<TElement>(this TElement element, Thickness padding) where TElement : ElementType
        { element.BorderThickness = padding; return element; }
        #endregion


        #region BorderBrush
        public static TElement BorderBrush<TElement>(this TElement element, Brush value) where TElement : ElementType
        { element.BorderBrush = value; return element; }

        public static TElement BorderBrush<TElement>(this TElement element, Color value) where TElement : ElementType
        { element.BorderBrush = new SolidColorBrush(value); return element; }

        public static TElement BorderBrush<TElement>(this TElement element, string hex) where TElement : ElementType
        { element.BorderBrush = new SolidColorBrush(P42.Utils.Uno.ColorExtensions.ColorFromHex(hex)); return element; }
        #endregion


        #region Background
        public static TElement Background<TElement>(this TElement element, Brush brush) where TElement : ElementType
        { element.Background = brush; return element; }

        public static TElement Background<TElement>(this TElement element, Color color) where TElement : ElementType
        { element.Background = new SolidColorBrush(color); return element; }

        public static TElement Background<TElement>(this TElement element, string hex) where TElement : ElementType
        { element.Background = new SolidColorBrush(P42.Utils.Uno.ColorExtensions.ColorFromHex(hex)); return element; }
        #endregion

        public static TElement BackgroundTransition<TElement>(this TElement element, BrushTransition brushTransition) where TElement : ElementType
        { element.BackgroundTransition = brushTransition; return element; }

        public static TElement BackgroundSizing<TElement>(this TElement element, BackgroundSizing sizing) where TElement : ElementType
        { element.BackgroundSizing = sizing; return element; }


        public static TElement NullOrEmptyCollapse<TElement>(this TElement element) where TElement : ElementType
        {
            return element.Bind(ContentPresenter.VisibilityProperty, element, nameof(Content),
                           convert: (object content) => (content != null).ToVisibility());
        }
    }
}
