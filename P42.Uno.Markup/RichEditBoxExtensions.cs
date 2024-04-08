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
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Windows.Foundation;
using Windows.UI;
using ElementType = Microsoft.UI.Xaml.Controls.RichEditBox;

namespace P42.Uno.Markup
{
    public static class RichEditBoxExtensions
    {
        #region Text/Font Binding
        public static ElementType BindFont(this ElementType target, Control source, BindingMode bindingMode = BindingMode.OneWay, object except = null)
        {
            var excepts = InternalHelpers.GetExcepts(except);
            if (excepts is null || !excepts.Contains(nameof(Control.CharacterSpacing)))
                target.Bind(ElementType.CharacterSpacingProperty, source, nameof(Control.CharacterSpacing), bindingMode);
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

        public static ElementType BindTextProperties(this ElementType target, Control source, BindingMode bindingMode = BindingMode.OneWay, object except = null)
        {
            var excepts = InternalHelpers.GetExcepts(except);
            target.BindFont(source, bindingMode, excepts);
            if (excepts is null || !excepts.Contains(nameof(Control.IsTextScaleFactorEnabledProperty)))
                target.Bind(ElementType.IsTextScaleFactorEnabledProperty, source, nameof(Control.IsTextScaleFactorEnabled), bindingMode);

            return target;
        }

        public static ElementType BindFont(this ElementType target, TextBlock source, BindingMode bindingMode = BindingMode.OneWay, object except = null)
        {
            var excepts = InternalHelpers.GetExcepts(except);
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

        public static ElementType BindTextProperties(this ElementType target, TextBlock source, BindingMode bindingMode = BindingMode.OneWay, object except = null)
        {
            var excepts = InternalHelpers.GetExcepts(except);
            target.BindFont(source, bindingMode, excepts);
            if (excepts is null || !excepts.Contains(nameof(TextBlock.IsTextScaleFactorEnabledProperty)))
                target.Bind(ElementType.IsTextScaleFactorEnabledProperty, source, nameof(TextBlock.IsTextScaleFactorEnabled), bindingMode);
            if (excepts is null || !excepts.Contains(nameof(TextBlock.TextWrappingProperty)))
                target.Bind(ElementType.TextWrappingProperty, source, nameof(TextBlock.TextWrapping), bindingMode);

            return target;
        }


        public static ElementType BindFont(this ElementType target, ContentPresenter source, BindingMode bindingMode = BindingMode.OneWay, object except = null)
        {
            var excepts = InternalHelpers.GetExcepts(except);
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

        public static ElementType BindTextProperties(this ElementType target, ContentPresenter source, BindingMode bindingMode = BindingMode.OneWay, object except = null)
        {
            var excepts = InternalHelpers.GetExcepts(except);
            target.BindFont(source, bindingMode, excepts);
            if (excepts is null || !excepts.Contains(nameof(ContentPresenter.IsTextScaleFactorEnabled)))
                target.Bind(ElementType.IsTextScaleFactorEnabledProperty, source, nameof(ContentPresenter.IsTextScaleFactorEnabled), bindingMode);
            if (excepts is null || !excepts.Contains(nameof(ContentPresenter.TextWrappingProperty)))
                target.Bind(ElementType.TextWrappingProperty, source, nameof(ContentPresenter.TextWrapping), bindingMode);

            return target;
        }

        #endregion


        #region Text/Font Workaround Binding
        public static ElementType WBindFont(this ElementType target, Control source, BindingMode bindingMode = BindingMode.OneWay, object except = null)
        {
            var excepts = InternalHelpers.GetExcepts(except);
            if (excepts is null || !excepts.Contains(nameof(Control.CharacterSpacing)))
                target.WBind(ElementType.CharacterSpacingProperty, source, Control.CharacterSpacingProperty, bindingMode);
            if (excepts is null || !excepts.Contains(nameof(Control.FontFamily)))
                target.WBind(ElementType.FontFamilyProperty, source, Control.FontFamilyProperty, bindingMode);
            if (excepts is null || !excepts.Contains(nameof(Control.FontSize)))
                target.WBind(ElementType.FontSizeProperty, source, Control.FontSizeProperty, bindingMode);
            if (excepts is null || !excepts.Contains(nameof(Control.FontStretch)))
                target.WBind(ElementType.FontStretchProperty, source, Control.FontStretchProperty, bindingMode);
            if (excepts is null || !excepts.Contains(nameof(Control.FontStyle)))
                target.WBind(ElementType.FontStyleProperty, source, Control.FontStyleProperty, bindingMode);
            if (excepts is null || !excepts.Contains(nameof(Control.FontWeight)))
                target.WBind(ElementType.FontWeightProperty, source, Control.FontWeightProperty, bindingMode);
            if (excepts is null || !excepts.Contains(nameof(Control.Foreground)))
                target.WBind(ElementType.ForegroundProperty, source, Control.ForegroundProperty, bindingMode);
            return target;
        }

        public static ElementType WBindTextProperties(this ElementType target, Control source, BindingMode bindingMode = BindingMode.OneWay, object except = null)
        {
            var excepts = InternalHelpers.GetExcepts(except);
            target.WBindFont(source, bindingMode, excepts);
            if (excepts is null || !excepts.Contains(nameof(Control.IsTextScaleFactorEnabledProperty)))
                target.WBind(ElementType.IsTextScaleFactorEnabledProperty, source, Control.IsTextScaleFactorEnabledProperty, bindingMode);

            return target;
        }

        public static ElementType WBindFont(this ElementType target, TextBlock source, BindingMode bindingMode = BindingMode.OneWay, object except = null)
        {
            var excepts = InternalHelpers.GetExcepts(except);
            if (excepts is null || !excepts.Contains(nameof(TextBlock.FontFamily)))
                target.WBind(ElementType.FontFamilyProperty, source, TextBlock.FontFamilyProperty, bindingMode);
            if (excepts is null || !excepts.Contains(nameof(TextBlock.FontSize)))
                target.WBind(ElementType.FontSizeProperty, source, TextBlock.FontSizeProperty, bindingMode);
            if (excepts is null || !excepts.Contains(nameof(TextBlock.FontStretch)))
                target.WBind(ElementType.FontStretchProperty, source, TextBlock.FontStretchProperty, bindingMode);
            if (excepts is null || !excepts.Contains(nameof(TextBlock.FontStyle)))
                target.WBind(ElementType.FontStyleProperty, source, TextBlock.FontStyleProperty, bindingMode);
            if (excepts is null || !excepts.Contains(nameof(TextBlock.FontWeight)))
                target.WBind(ElementType.FontWeightProperty, source, TextBlock.FontWeightProperty, bindingMode);
            if (excepts is null || !excepts.Contains(nameof(TextBlock.Foreground)))
                target.WBind(ElementType.ForegroundProperty, source, TextBlock.ForegroundProperty, bindingMode);
            return target;
        }

        public static ElementType WBindTextProperties(this ElementType target, TextBlock source, BindingMode bindingMode = BindingMode.OneWay, object except = null)
        {
            var excepts = InternalHelpers.GetExcepts(except);
            target.WBindFont(source, bindingMode, excepts);
            if (excepts is null || !excepts.Contains(nameof(TextBlock.IsTextScaleFactorEnabledProperty)))
                target.WBind(ElementType.IsTextScaleFactorEnabledProperty, source, TextBlock.IsTextScaleFactorEnabledProperty, bindingMode);
            if (excepts is null || !excepts.Contains(nameof(TextBlock.TextWrappingProperty)))
                target.WBind(ElementType.TextWrappingProperty, source, TextBlock.TextWrappingProperty, bindingMode);

            return target;
        }


        public static ElementType WBindFont(this ElementType target, ContentPresenter source, BindingMode bindingMode = BindingMode.OneWay, object except = null)
        {
            var excepts = InternalHelpers.GetExcepts(except);
            if (excepts is null || !excepts.Contains(nameof(ContentPresenter.FontFamily)))
                target.WBind(ElementType.FontFamilyProperty, source, ContentPresenter.FontFamilyProperty, bindingMode);
            if (excepts is null || !excepts.Contains(nameof(ContentPresenter.FontSize)))
                target.WBind(ElementType.FontSizeProperty, source, ContentPresenter.FontSizeProperty, bindingMode);
            if (excepts is null || !excepts.Contains(nameof(ContentPresenter.FontStretch)))
                target.WBind(ElementType.FontStretchProperty, source, ContentPresenter.FontStretchProperty, bindingMode);
            if (excepts is null || !excepts.Contains(nameof(ContentPresenter.FontStyle)))
                target.WBind(ElementType.FontStyleProperty, source, ContentPresenter.FontStyleProperty, bindingMode);
            if (excepts is null || !excepts.Contains(nameof(ContentPresenter.FontWeight)))
                target.WBind(ElementType.FontWeightProperty, source, ContentPresenter.FontWeightProperty, bindingMode);
            if (excepts is null || !excepts.Contains(nameof(ContentPresenter.Foreground)))
                target.WBind(ElementType.ForegroundProperty, source, ContentPresenter.ForegroundProperty, bindingMode);

            return target;
        }

        public static ElementType WBindTextProperties(this ElementType target, ContentPresenter source, BindingMode bindingMode = BindingMode.OneWay, object except = null)
        {
            var excepts = InternalHelpers.GetExcepts(except);
            target.WBindFont(source, bindingMode, excepts);
            if (excepts is null || !excepts.Contains(nameof(ContentPresenter.IsTextScaleFactorEnabled)))
                target.WBind(ElementType.IsTextScaleFactorEnabledProperty, source, ContentPresenter.IsTextScaleFactorEnabledProperty, bindingMode);
            if (excepts is null || !excepts.Contains(nameof(ContentPresenter.TextWrappingProperty)))
                target.WBind(ElementType.TextWrappingProperty, source, ContentPresenter.TextWrappingProperty, bindingMode);

            return target;
        }

        #endregion


        #region Properties
        public static TElement AcceptsReturn<TElement>(this TElement element, bool acceptsReturn = true) where TElement : ElementType
        { element.AcceptsReturn = acceptsReturn; return element; }

        public static TElement CharacterCasing<TElement>(this TElement element, CharacterCasing casing) where TElement : ElementType
        { element.CharacterCasing = casing; return element; }

        public static TElement ClipboardCopyFormat<TElement>(this TElement element, RichEditClipboardFormat format) where TElement : ElementType
        { element.ClipboardCopyFormat = format; return element; }

        public static TElement Description<TElement>(this TElement element, object description) where TElement : ElementType
        { element.Description = description; return element; }

        public static TElement DesiredCandidateWindowAlignment<TElement>(this TElement element, CandidateWindowAlignment alignment) where TElement : ElementType
        { element.DesiredCandidateWindowAlignment = alignment; return element; }

        public static TElement DisabledFormattingAccelerators<TElement>(this TElement element, DisabledFormattingAccelerators accelerators) where TElement : ElementType
        { element.DisabledFormattingAccelerators = accelerators; return element; }

        public static TElement Header<TElement>(this TElement element, object header) where TElement : ElementType
        { element.Header = header; return element; }

        public static TElement HeaderTemplate<TElement>(this TElement element, DataTemplate headerTemplate) where TElement : ElementType
        { element.HeaderTemplate = headerTemplate; return element; }

        public static TElement HeaderTemplate<TElement>(this TElement element, Type type) where TElement : ElementType
        { element.HeaderTemplate = type.AsDataTemplate(); return element; }

        public static TElement HorizontalTextAlignment<TElement>(this TElement element, TextAlignment textAlignment) where TElement : ElementType
        { element.HorizontalTextAlignment = textAlignment; return element; }

        public static TElement InputScope<TElement>(this TElement element, InputScope inputScope) where TElement : ElementType
        { element.InputScope = inputScope; return element; }

        public static TElement ColorFontEnabled<TElement>(this TElement element, bool enabled = true) where TElement : ElementType
        { element.IsColorFontEnabled = enabled; return element; }

        public static TElement ReadOnly<TElement>(this TElement element, bool readOnly = true) where TElement : ElementType
        { element.IsReadOnly = readOnly; return element; }

        public static TElement SpellCheckEnabled<TElement>(this TElement element, bool enabled = true) where TElement : ElementType
        { element.IsSpellCheckEnabled = enabled; return element; }

        public static TElement TextPredictionEnabled<TElement>(this TElement element, bool enabled = true) where TElement : ElementType
        { element.IsTextPredictionEnabled = enabled; return element; }

        public static TElement MaxLength<TElement>(this TElement element, int lines = 0) where TElement : ElementType
        { element.MaxLength = lines; return element; }

        public static TElement PlaceholderText<TElement>(this TElement element, string text) where TElement : ElementType
        { element.PlaceholderText = text; return element; }

        public static TElement PreventKeyboardDisplayOnProgrammaticFocus<TElement>(this TElement element, bool enabled = true) where TElement : ElementType
        { element.PreventKeyboardDisplayOnProgrammaticFocus = enabled; return element; }

        public static TElement SelectionFlyout<TElement>(this TElement element, FlyoutBase flyout) where TElement : ElementType
        { element.SelectionFlyout = flyout; return element; }

        public static TElement SelectionHighlightColor<TElement>(this TElement element, SolidColorBrush brush) where TElement : ElementType
        { element.SelectionHighlightColor = brush; return element; }

        public static TElement SelectionHighlightColor<TElement>(this TElement element, Color color) where TElement : ElementType
        { element.SelectionHighlightColor = color.ToBrush(); return element; }

        public static TElement SelectionHighlightColor<TElement>(this TElement element, string color) where TElement : ElementType
        { element.SelectionHighlightColor = ColorExtensions.ColorFromString(color).ToBrush(); return element; }

        public static ElementType SelectionHighlightColor(this ElementType element, uint hex)
        { element.SelectionHighlightColor = new SolidColorBrush(ColorExtensions.ColorFromUint(hex)); return element; }

        public static TElement SelectionHighlightColorWhenNotFocused<TElement>(this TElement element, SolidColorBrush brush) where TElement : ElementType
        { element.SelectionHighlightColorWhenNotFocused = brush; return element; }

        public static TElement SelectionHighlightColorWhenNotFocused<TElement>(this TElement element, Color color) where TElement : ElementType
        { element.SelectionHighlightColorWhenNotFocused = color.ToBrush(); return element; }

        public static TElement SelectionHighlightColorWhenNotFocused<TElement>(this TElement element, string color) where TElement : ElementType
        { element.SelectionHighlightColorWhenNotFocused = ColorExtensions.ColorFromString(color).ToBrush(); return element; }

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

        public static TElement TextReadingOrder<TElement>(this TElement element, TextReadingOrder readingOrder) where TElement : ElementType
        { element.TextReadingOrder = readingOrder; return element; }

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


        #region Events
        public static TElement AddCandidateWindowBoundsChangedHandler<TElement>(this TElement element, TypedEventHandler<RichEditBox, CandidateWindowBoundsChangedEventArgs> handler) where TElement : ElementType
        { element.CandidateWindowBoundsChanged += handler; return element; }

        public static TElement AddContextMenuOpeningHandler<TElement>(this TElement element, ContextMenuOpeningEventHandler handler) where TElement : ElementType
        { element.ContextMenuOpening += handler; return element; }

        public static TElement AddCopyingToClipboardHandler<TElement>(this TElement element, TypedEventHandler<RichEditBox, TextControlCopyingToClipboardEventArgs> handler) where TElement : ElementType
        { element.CopyingToClipboard += handler; return element; }

        public static TElement AddCuttingToClipboardHandler<TElement>(this TElement element, TypedEventHandler<RichEditBox, TextControlCuttingToClipboardEventArgs> handler) where TElement : ElementType
        { element.CuttingToClipboard += handler; return element; }

        public static TElement AddPasteHandler<TElement>(this TElement element, TextControlPasteEventHandler handler) where TElement : ElementType
        { element.Paste += handler; return element; }

        public static TElement AddSelectionChangedHandler<TElement>(this TElement element, RoutedEventHandler handler) where TElement : ElementType
        { element.SelectionChanged += handler; return element; }

        public static TElement AddSelectionChangingHandler<TElement>(this TElement element, TypedEventHandler<RichEditBox, RichEditBoxSelectionChangingEventArgs> handler) where TElement : ElementType
        { element.SelectionChanging += handler; return element; }

        public static TElement AddTextChangedHandler<TElement>(this TElement element, RoutedEventHandler handler) where TElement : RichEditBox
        { element.TextChanged += handler; return element; }

        public static TElement AddTextChangingHandler<TElement>(this TElement element, TypedEventHandler<RichEditBox, RichEditBoxTextChangingEventArgs> handler) where TElement : ElementType
        { element.TextChanging += handler; return element; }

        public static TElement AddTextCompositionChangedHandler<TElement>(this TElement element, TypedEventHandler<RichEditBox, TextCompositionChangedEventArgs> handler) where TElement : ElementType
        { element.TextCompositionChanged += handler; return element; }

        public static TElement AddTextCompositionEndedHandler<TElement>(this TElement element, TypedEventHandler<RichEditBox, TextCompositionEndedEventArgs> handler) where TElement : ElementType
        { element.TextCompositionEnded += handler; return element; }

        public static TElement AddTextCompositionStartedHandler<TElement>(this TElement element, TypedEventHandler<RichEditBox, TextCompositionStartedEventArgs> handler) where TElement : ElementType
        { element.TextCompositionStarted += handler; return element; }


        #endregion

    }
}
