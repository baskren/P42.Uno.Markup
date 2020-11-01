using P42.Utils.Uno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using ElementType = Windows.UI.Xaml.Controls.TextBlock;

namespace P42.Uno.Markup
{
    public static class TextBlockExtensions
    {
        #region Wrapping
        public static ElementType TextWrapping(this ElementType element, TextWrapping wrapping) 
        { element.TextWrapping = wrapping; return element; }

        public static ElementType NoWrap(this ElementType element)
        { element.TextWrapping = Windows.UI.Xaml.TextWrapping.NoWrap; return element; }

        public static ElementType Wrap(this ElementType element)
        { element.TextWrapping = Windows.UI.Xaml.TextWrapping.Wrap; return element; }

        public static ElementType WrapWords(this ElementType element)
        { element.TextWrapping = Windows.UI.Xaml.TextWrapping.WrapWholeWords; return element; }
        #endregion


        #region TextTrimming
        public static ElementType TextTrimming(this ElementType element, TextTrimming trimming)
        { element.TextTrimming = trimming; return element; }

        public static ElementType CharacterEllipsisTextTrimming(this ElementType element)
        { element.TextTrimming = Windows.UI.Xaml.TextTrimming.CharacterEllipsis; return element; }

        public static ElementType ClipTextTrimming(this ElementType element)
        { element.TextTrimming = Windows.UI.Xaml.TextTrimming.Clip; return element; }

        public static ElementType NoTextTrimming(this ElementType element)
        { element.TextTrimming = Windows.UI.Xaml.TextTrimming.None; return element; }

        public static ElementType WordEllipsisTextTrimming(this ElementType element)
        { element.TextTrimming = Windows.UI.Xaml.TextTrimming.WordEllipsis; return element; }
        #endregion


        #region Text Alignment
        public static ElementType TextAlignment(this ElementType element, TextAlignment alignment)
        { element.TextAlignment = alignment; return element; }

        public static ElementType LeftTextAlignment(this ElementType element)
        { element.TextAlignment = Windows.UI.Xaml.TextAlignment.Left; return element; }

        public static ElementType CenterTextAlignment(this ElementType element)
        { element.TextAlignment = Windows.UI.Xaml.TextAlignment.Center; return element; }

        public static ElementType RightTextAlignment(this ElementType element)
        { element.TextAlignment = Windows.UI.Xaml.TextAlignment.Right; return element; }

        public static ElementType JustifyTextAlignment(this ElementType element)
        { element.TextAlignment = Windows.UI.Xaml.TextAlignment.Justify; return element; }

        public static ElementType DetectTextAlignment(this ElementType element)
        { element.TextAlignment = Windows.UI.Xaml.TextAlignment.DetectFromContent; return element; }
        #endregion

        public static ElementType Text(this ElementType element, string text)
        { element.Text = text; return element; }


        #region Padding
        public static ElementType Padding(this ElementType element, double value)
        { element.Padding = new Thickness(value); return element; }

        public static ElementType Padding(this ElementType element, double horizontal, double vertical)
        { element.Padding = new Thickness(horizontal, vertical, horizontal, vertical); return element; }

        public static ElementType Padding(this ElementType element, double left, double top, double right, double bottom)
        { element.Padding = new Thickness(left, top, right, bottom); return element; }

        public static ElementType Padding(this ElementType element, Thickness padding)
        { element.Padding = padding; return element; }
        #endregion

        #region Font Properties

        #region Binding
        public static ElementType BindFont(this ElementType target, Control source, BindingMode bindingMode = BindingMode.OneWay, object except = null) 
        {
            var excepts = InternalHelpers.GetExcepts<Control>(except);
            if (excepts is null || !excepts.Contains(nameof(Control.FontFamily)))
                target.Bind(ElementType.FontFamilyProperty, source, nameof(Control.FontFamily), bindingMode);
            if (excepts is null || !excepts.Contains(nameof(Control.FontSize)))
                target.Bind(ElementType.FontSizeProperty, source, nameof(Control.FontSize), bindingMode);
            if (excepts is null || !excepts.Contains(nameof(Control.FontStretch)))
                target.Bind(ElementType.FontStretchProperty, source, nameof(Control.FontStretch), bindingMode);
            if (excepts is null || !excepts.Contains(nameof(Control.FontStyle)))
                target.Bind(ElementType.FontStyleProperty, source, nameof(Control.FontStyle), bindingMode);
            if (excepts is null || !excepts.Contains(nameof(Control.FontWeight)))
                target.Bind(ElementType.FontWeightProperty, source, nameof(Control.FontWeight), bindingMode);
            if (excepts is null || !excepts.Contains(nameof(Control.Foreground)))
                target.Bind(ElementType.ForegroundProperty, source, nameof(Control.Foreground), bindingMode);
            return target;
        }
        public static ElementType BindFont(this ElementType target, TextBlock source, BindingMode bindingMode = BindingMode.OneWay, object except = null)
        {
            var excepts = InternalHelpers.GetExcepts<TextBlock>(except);
            if (excepts is null || !excepts.Contains(nameof(TextBlock.FontFamily)))
                target.Bind(ElementType.FontFamilyProperty, source, nameof(TextBlock.FontFamily), bindingMode);
            if (excepts is null || !excepts.Contains(nameof(TextBlock.FontSize)))
                target.Bind(ElementType.FontSizeProperty, source, nameof(TextBlock.FontSize), bindingMode);
            if (excepts is null || !excepts.Contains(nameof(TextBlock.FontStretch)))
                target.Bind(ElementType.FontStretchProperty, source, nameof(TextBlock.FontStretch), bindingMode);
            if (excepts is null || !excepts.Contains(nameof(TextBlock.FontStyle)))
                target.Bind(ElementType.FontStyleProperty, source, nameof(TextBlock.FontStyle), bindingMode);
            if (excepts is null || !excepts.Contains(nameof(TextBlock.FontWeight)))
                target.Bind(ElementType.FontWeightProperty, source, nameof(TextBlock.FontWeight), bindingMode);
            if (excepts is null || !excepts.Contains(nameof(TextBlock.Foreground)))
                target.Bind(ElementType.ForegroundProperty, source, nameof(TextBlock.Foreground), bindingMode);
            return target;
        }
        public static ElementType BindFont(this ElementType target, ContentPresenter source, BindingMode bindingMode = BindingMode.OneWay, object except = null)
        {
            var excepts = InternalHelpers.GetExcepts<ContentPresenter>(except);
            if (excepts is null || !excepts.Contains(nameof(ContentPresenter.FontFamily)))
                target.Bind(ElementType.FontFamilyProperty, source, nameof(ContentPresenter.FontFamily), bindingMode);
            if (excepts is null || !excepts.Contains(nameof(ContentPresenter.FontSize)))
                target.Bind(ElementType.FontSizeProperty, source, nameof(ContentPresenter.FontSize), bindingMode);
            if (excepts is null || !excepts.Contains(nameof(ContentPresenter.FontStretch)))
                target.Bind(ElementType.FontStretchProperty, source, nameof(ContentPresenter.FontStretch), bindingMode);
            if (excepts is null || !excepts.Contains(nameof(ContentPresenter.FontStyle)))
                target.Bind(ElementType.FontStyleProperty, source, nameof(ContentPresenter.FontStyle), bindingMode);
            if (excepts is null || !excepts.Contains(nameof(ContentPresenter.FontWeight)))
                target.Bind(ElementType.FontWeightProperty, source, nameof(ContentPresenter.FontWeight), bindingMode);
            if (excepts is null || !excepts.Contains(nameof(ContentPresenter.Foreground)))
                target.Bind(ElementType.ForegroundProperty, source, nameof(ContentPresenter.Foreground), bindingMode);
            return target;
        }

        #endregion


        #region Foreground
        public static ElementType Foreground(this ElementType element, Brush brush)
        { element.Foreground = brush; return element; }

        public static ElementType Foreground(this ElementType element, Color color)
        { element.Foreground = new SolidColorBrush(color); return element; }

        public static ElementType Foreground(this ElementType element, string hex)
        { element.Foreground = new SolidColorBrush(P42.Utils.Uno.ColorExtensions.ColorFromString(hex)); return element; }
        #endregion


        #region FontWeight
        public static ElementType FontWeight(this ElementType element, FontWeight weight)
        { element.FontWeight = weight; return element; }

        public static ElementType Thin(this ElementType element)
        { element.FontWeight = Windows.UI.Text.FontWeights.Thin; return element; }

        public static ElementType ExtraLight(this ElementType element)
        { element.FontWeight = Windows.UI.Text.FontWeights.ExtraLight; return element; }

        public static ElementType Light(this ElementType element)
        { element.FontWeight = Windows.UI.Text.FontWeights.Light; return element; }

        public static ElementType SemiLight(this ElementType element)
        { element.FontWeight = Windows.UI.Text.FontWeights.SemiLight; return element; }

        public static ElementType NormalFontWieght(this ElementType element)
        { element.FontWeight = Windows.UI.Text.FontWeights.Normal; return element; }

        public static ElementType Medium(this ElementType element)
        { element.FontWeight = Windows.UI.Text.FontWeights.Medium; return element; }

        public static ElementType SemiBold(this ElementType element)
        { element.FontWeight = Windows.UI.Text.FontWeights.SemiBold; return element; }

        public static ElementType Bold(this ElementType element)
        { element.FontWeight = Windows.UI.Text.FontWeights.Bold; return element; }

        public static ElementType ExtraBold(this ElementType element)
        { element.FontWeight = Windows.UI.Text.FontWeights.ExtraBold; return element; }

        public static ElementType BlackFontWeight(this ElementType element)
        { element.FontWeight = Windows.UI.Text.FontWeights.Black; return element; }

        public static ElementType ExtraBlack(this ElementType element)
        { element.FontWeight = Windows.UI.Text.FontWeights.ExtraBlack; return element; }
        #endregion


        #region FontStyle
        public static ElementType FontStyle(this ElementType element, FontStyle fontStyle)
        { element.FontStyle = fontStyle; return element; }

        public static ElementType NormalFontStyle(this ElementType element)
        { element.FontStyle = Windows.UI.Text.FontStyle.Normal; return element; }

        public static ElementType Oblique(this ElementType element)
        { element.FontStyle = Windows.UI.Text.FontStyle.Oblique; return element; }

        public static ElementType Italic(this ElementType element)
        { element.FontStyle = Windows.UI.Text.FontStyle.Italic; return element; }
        #endregion


        #region FontStretch
        public static ElementType FontStretch(this ElementType element, FontStretch stretch)
        { element.FontStretch = stretch; return element; }

        public static ElementType FontStretch(this ElementType element)
        { element.FontStretch = Windows.UI.Text.FontStretch.Undefined; return element; }

        public static ElementType UltraCondensed(this ElementType element)
        { element.FontStretch = Windows.UI.Text.FontStretch.UltraCondensed; return element; }

        public static ElementType ExtraCondensed(this ElementType element)
        { element.FontStretch = Windows.UI.Text.FontStretch.ExtraCondensed; return element; }

        public static ElementType Condensed(this ElementType element)
        { element.FontStretch = Windows.UI.Text.FontStretch.Condensed; return element; }

        public static ElementType SemiCondensed(this ElementType element)
        { element.FontStretch = Windows.UI.Text.FontStretch.SemiCondensed; return element; }

        public static ElementType NormalFontStretch(this ElementType element)
        { element.FontStretch = Windows.UI.Text.FontStretch.Normal; return element; }

        public static ElementType SemiExpanded(this ElementType element)
        { element.FontStretch = Windows.UI.Text.FontStretch.SemiExpanded; return element; }

        public static ElementType Expanded(this ElementType element)
        { element.FontStretch = Windows.UI.Text.FontStretch.Expanded; return element; }

        public static ElementType ExtraExpanded(this ElementType element)
        { element.FontStretch = Windows.UI.Text.FontStretch.ExtraExpanded; return element; }

        public static ElementType UltraExpanded(this ElementType element)
        { element.FontStretch = Windows.UI.Text.FontStretch.UltraExpanded; return element; }
        #endregion


        public static ElementType FontSize(this ElementType element, double size)
        { element.FontSize = size; return element; }


        #region FontFamily
        public static ElementType FontFamily(this ElementType element, FontFamily family)
        { element.FontFamily = family; return element; }

        public static ElementType FontFamily(this ElementType element, string family)
        { element.FontFamily = new Windows.UI.Xaml.Media.FontFamily(family); return element; }
        #endregion

        #endregion

        public static ElementType LineStackingStrategy(this ElementType element, LineStackingStrategy strategy)
        { element.LineStackingStrategy = strategy; return element; }

        public static ElementType LineHeight(this ElementType element, double height)
        { element.LineHeight = height; return element; }

        public static ElementType CharacterSpacing(this ElementType element, int ems)
        { element.CharacterSpacing = ems; return element; }


        #region Text Selection
        public static ElementType IsTextSelectionEnabled(this ElementType element, bool enabled)
        { element.IsTextSelectionEnabled = enabled; return element; }

        public static ElementType TextSelectionEnabled(this ElementType element)
        { element.IsTextSelectionEnabled = true; return element; }
        #endregion


        public static ElementType TextReadingOrder(this ElementType element, TextReadingOrder value)
        { element.TextReadingOrder = value; return element; }

        public static ElementType TextLineBounds(this ElementType element, TextLineBounds value)
        { element.TextLineBounds = value; return element; }

        public static ElementType SelectionHighlightColor(this ElementType element, SolidColorBrush value)
        { element.SelectionHighlightColor = value; return element; }

        public static ElementType SelectionHighlightColor(this ElementType element, Color value)
        { element.SelectionHighlightColor = new SolidColorBrush( value); return element; }

        public static ElementType OpticalMarginAlignment(this ElementType element, OpticalMarginAlignment value)
        { element.OpticalMarginAlignment = value; return element; }

        public static ElementType MaxLines(this ElementType element, int value)
        { element.MaxLines = value; return element; }

        #region Color Font Enabled
        public static ElementType IsColorFontEnabled(this ElementType element, bool enabled)
        { element.IsColorFontEnabled = enabled; return element; }

        public static ElementType ColorFontEnabled(this ElementType element)
        { element.IsColorFontEnabled = true; return element; }
        #endregion

        #region Text Scale Factor Enabled
        public static ElementType IsTextScaleFactorEnabled(this ElementType element, bool enabled)
        { element.IsTextScaleFactorEnabled = enabled; return element; }

        public static ElementType TextScaleFactorEnabled(this ElementType element)
        { element.IsTextScaleFactorEnabled = true; return element; }
        #endregion

        #region Text Decorations
        public static ElementType TextDecorations(this ElementType element, TextDecorations enabled)
        { element.TextDecorations = enabled; return element; }

        public static ElementType Underline(this ElementType element)
        { element.TextDecorations = Windows.UI.Text.TextDecorations.Underline; return element; }

        public static ElementType Strikethrough(this ElementType element)
        { element.TextDecorations = Windows.UI.Text.TextDecorations.Strikethrough; return element; }
        #endregion

        public static ElementType SelectionFlyout(this ElementType element, FlyoutBase flyout)
        { element.SelectionFlyout = flyout; return element; }

        public static ElementType BindNullOrEmptyCollapse(this ElementType element)
        {
            return element.Bind(TextBlock.VisibilityProperty, element, nameof(TextBlock.Text),
                       convert: (string text) => (!string.IsNullOrEmpty(text)).ToVisibility());
        }


        #region Events
        public static ElementType AddContextMenuOpening(this ElementType element, ContextMenuOpeningEventHandler handler) 
        { element.ContextMenuOpening += handler; return element; }

        public static ElementType AddSelectionChanged(this ElementType element, RoutedEventHandler handler) 
        { element.SelectionChanged += handler; return element; }

        public static ElementType AddIsTextTrimmedChanged(this ElementType element, TypedEventHandler<TextBlock, IsTextTrimmedChangedEventArgs> handler)
        { element.IsTextTrimmedChanged += handler; return element; }
        #endregion


        #region HTML
        public static ElementType Html(this ElementType element, string value)
        { element.SetHtml(value); return element; }

        public static ElementType BindHtml(this ElementType element, object source, string path)
        {
            element.Bind(P42.Utils.Uno.TextBlockExtensions.HtmlProperty, source, path);
            return element;
        }
        #endregion
    }
}
