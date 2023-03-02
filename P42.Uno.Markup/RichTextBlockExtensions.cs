using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Text;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Documents;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Windows.Foundation;
using Windows.UI.Text;
using ElementType = Microsoft.UI.Xaml.Controls.RichTextBlock;

namespace P42.Uno.Markup
{
    public static class RichTextEditExtensions
    {
        #region Properties
        public static ElementType CharacterSpacing(this ElementType element, int thousanthsOfAnEm) 
        { element.CharacterSpacing = thousanthsOfAnEm; return element; }

        #region FontFamily
        public static ElementType FontFamily(this ElementType element, FontFamily family)
        { element.FontFamily = family; return element; }

        public static ElementType FontFamily(this ElementType element, string family)
        { element.FontFamily = new Microsoft.UI.Xaml.Media.FontFamily(family); return element; }
        #endregion

        public static ElementType FontSize(this ElementType element, double size)
        { element.FontSize = size; return element; }

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

        #region FontWeight
        public static ElementType FontWeight(this ElementType element, FontWeight weight)
        { element.FontWeight = weight; return element; }

        public static ElementType ThinFontWeight(this ElementType element)
        { element.FontWeight = FontWeights.Thin; return element; }

        public static ElementType ExtraLightFontWeight(this ElementType element)
        { element.FontWeight = FontWeights.ExtraLight; return element; }

        public static ElementType LightFontWeight(this ElementType element)
        { element.FontWeight = FontWeights.Light; return element; }

        public static ElementType SemiLightFontWeight(this ElementType element)
        { element.FontWeight = FontWeights.SemiLight; return element; }

        public static ElementType NormalFontWeight(this ElementType element)
        { element.FontWeight = FontWeights.Normal; return element; }

        public static ElementType MediumFontWeight(this ElementType element)
        { element.FontWeight = FontWeights.Medium; return element; }

        public static ElementType SemiBoldFontWeight(this ElementType element)
        { element.FontWeight = FontWeights.SemiBold; return element; }

        public static ElementType BoldFontWeight(this ElementType element)
        { element.FontWeight = FontWeights.Bold; return element; }

        public static ElementType ExtraBoldFontWeight(this ElementType element)
        { element.FontWeight = FontWeights.ExtraBold; return element; }

        public static ElementType BlackFontWeight(this ElementType element)
        { element.FontWeight = FontWeights.Black; return element; }

        public static ElementType ExtraBlackFontWeight(this ElementType element)
        { element.FontWeight = FontWeights.ExtraBlack; return element; }
        #endregion

        #region Foreground
        public static ElementType Foreground(this ElementType element, Brush brush)
        { element.Foreground = brush; return element; }

        public static ElementType Foreground(this ElementType element, Windows.UI.Color color)
        { element.Foreground = new SolidColorBrush(color); return element; }

        public static ElementType Foreground(this ElementType element, string color)
        { element.Foreground = new SolidColorBrush(ColorExtensions.ColorFromString(color)); return element; }

        public static ElementType Foreground(this ElementType element, uint hex)
        { element.Foreground = new SolidColorBrush(ColorExtensions.ColorFromUint(hex)); return element; }
        #endregion

        #region Text Alignment
        public static ElementType TextAlignment(this ElementType element, TextAlignment alignment)
        { element.TextAlignment = alignment; return element; }

        public static ElementType LeftTextAlignment(this ElementType element)
        { element.TextAlignment = Microsoft.UI.Xaml.TextAlignment.Left; return element; }

        public static ElementType CenterTextAlignment(this ElementType element)
        { element.TextAlignment = Microsoft.UI.Xaml.TextAlignment.Center; return element; }

        public static ElementType RightTextAlignment(this ElementType element)
        { element.TextAlignment = Microsoft.UI.Xaml.TextAlignment.Right; return element; }

        public static ElementType JustifyTextAlignment(this ElementType element)
        { element.TextAlignment = Microsoft.UI.Xaml.TextAlignment.Justify; return element; }

        public static ElementType DetectTextAlignment(this ElementType element)
        { element.TextAlignment = Microsoft.UI.Xaml.TextAlignment.DetectFromContent; return element; }
        #endregion

        public static ElementType ColorFontEnabled(this ElementType element, bool enabled = true)
        { element.IsColorFontEnabled = enabled; return element; }

        public static ElementType TextScaleFactorEnabled(this ElementType element, bool enabled = true)
        { element.IsTextScaleFactorEnabled = enabled; return element; }

        public static ElementType TextSelectionEnabled(this ElementType element, bool enabled = true)
        { element.IsTextSelectionEnabled = enabled; return element; }

        public static ElementType LineHeight(this ElementType element, double height)
        { element.LineHeight = height; return element; }

        public static ElementType LineStackingStrategy(this ElementType element, LineStackingStrategy strategy)
        { element.LineStackingStrategy = strategy; return element; }

        public static ElementType MaxLines(this ElementType element, int value)
        { element.MaxLines = value; return element; }

        public static ElementType OpticalMarginAlignment(this ElementType element, OpticalMarginAlignment value)
        { element.OpticalMarginAlignment = value; return element; }

        public static ElementType OverflowContentTarget(this ElementType element, RichTextBlockOverflow value)
        { element.OverflowContentTarget = value; return element; }

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

        public static ElementType SelectionFlyout(this ElementType element, FlyoutBase flyout) 
        { element.SelectionFlyout = flyout; return element; }

        public static ElementType SelectionHighlightColor(this ElementType element, SolidColorBrush brush)
        { element.SelectionHighlightColor = brush; return element; }

        public static ElementType SelectionHighlightColor(this ElementType element, Windows.UI.Color color)
        { element.SelectionHighlightColor = color.ToBrush(); return element; }

        public static ElementType SelectionHighlightColor(this ElementType element, string color)
        { element.SelectionHighlightColor = ColorExtensions.ColorFromString(color).ToBrush(); return element; }

        #region Text Decorations
        public static ElementType TextDecorations(this ElementType element, TextDecorations enabled)
        { element.TextDecorations = enabled; return element; }

        public static ElementType Underline(this ElementType element)
        { element.TextDecorations = Windows.UI.Text.TextDecorations.Underline; return element; }

        public static ElementType Strikethrough(this ElementType element)
        { element.TextDecorations = Windows.UI.Text.TextDecorations.Strikethrough; return element; }
        #endregion

        public static ElementType TextIndent(this ElementType element, double value)
        { element.TextIndent = value; return element; }

        public static ElementType TextLineBounds(this ElementType element, TextLineBounds value)
        { element.TextLineBounds = value; return element; }

        public static ElementType TextReadingOrder(this ElementType element, TextReadingOrder value)
        { element.TextReadingOrder = value; return element; }

        #region TextTrimming
        public static ElementType TextTrimming(this ElementType element, TextTrimming trimming)
        { element.TextTrimming = trimming; return element; }

        public static ElementType CharacterEllipsisTextTrimming(this ElementType element)
        { element.TextTrimming = Microsoft.UI.Xaml.TextTrimming.CharacterEllipsis; return element; }

        public static ElementType ClipTextTrimming(this ElementType element)
        { element.TextTrimming = Microsoft.UI.Xaml.TextTrimming.Clip; return element; }

        public static ElementType NoTextTrimming(this ElementType element)
        { element.TextTrimming = Microsoft.UI.Xaml.TextTrimming.None; return element; }

        public static ElementType WordEllipsisTextTrimming(this ElementType element)
        { element.TextTrimming = Microsoft.UI.Xaml.TextTrimming.WordEllipsis; return element; }
        #endregion

        #region Wrapping
        public static ElementType TextWrapping(this ElementType element, TextWrapping wrapping)
        { element.TextWrapping = wrapping; return element; }

        public static ElementType NoWrap(this ElementType element)
        { element.TextWrapping = Microsoft.UI.Xaml.TextWrapping.NoWrap; return element; }

        public static ElementType Wrap(this ElementType element)
        { element.TextWrapping = Microsoft.UI.Xaml.TextWrapping.Wrap; return element; }

        public static ElementType WrapWords(this ElementType element)
        { element.TextWrapping = Microsoft.UI.Xaml.TextWrapping.WrapWholeWords; return element; }
        #endregion

        #endregion


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


        #region Events
        public static ElementType AddContextMenuOpeningHandler(this ElementType element, ContextMenuOpeningEventHandler handler)
        { element.ContextMenuOpening += handler; return element; }

        public static ElementType AddSelectionChangedHandler(this ElementType element, RoutedEventHandler handler)
        { element.SelectionChanged += handler; return element; }

        public static ElementType AddIsTextTrimmedChangedHandler(this ElementType element, TypedEventHandler<ElementType, IsTextTrimmedChangedEventArgs> handler)
        { element.IsTextTrimmedChanged += handler; return element; }
        #endregion
    }
}
