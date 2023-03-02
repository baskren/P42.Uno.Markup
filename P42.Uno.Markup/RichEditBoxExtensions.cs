using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Text;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
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
        public static TElement AddCandidateWindowBoundsChangedHandler<TElement>(this TElement element, TypedEventHandler<ElementType, CandidateWindowBoundsChangedEventArgs> handler) where TElement : ElementType
        { element.CandidateWindowBoundsChanged += handler; return element; }

        public static TElement AddContextMenuOpeningHandler<TElement>(this TElement element, ContextMenuOpeningEventHandler handler) where TElement : ElementType
        { element.ContextMenuOpening += handler; return element; }

        public static TElement AddCopyingToClipboardHandler<TElement>(this TElement element, TypedEventHandler<ElementType, TextControlCopyingToClipboardEventArgs> handler) where TElement : ElementType
        { element.CopyingToClipboard += handler; return element; }

        public static TElement AddCuttingToClipboardHandler<TElement>(this TElement element, TypedEventHandler<ElementType, TextControlCuttingToClipboardEventArgs> handler) where TElement : ElementType
        { element.CuttingToClipboard += handler; return element; }

        public static TElement AddPasteHandler<TElement>(this TElement element, TextControlPasteEventHandler handler) where TElement : ElementType
        { element.Paste += handler; return element; }

        public static TElement AddSelectionChangedHandler<TElement>(this TElement element, RoutedEventHandler handler) where TElement : ElementType
        { element.SelectionChanged += handler; return element; }

        public static TElement AddSelectionChangingHandler<TElement>(this TElement element, TypedEventHandler<ElementType, RichEditBoxSelectionChangingEventArgs> handler) where TElement : ElementType
        { element.SelectionChanging += handler; return element; }

        public static TElement AddTextChangedHandler<TElement>(this TElement element, RoutedEventHandler handler) where TElement : ElementType
        { element.TextChanged += handler; return element; }

        public static TElement AddTextChangingHandler<TElement>(this TElement element, TypedEventHandler<ElementType, RichEditBoxTextChangingEventArgs> handler) where TElement : ElementType
        { element.TextChanging += handler; return element; }

        public static TElement AddTextCompositionChangedHandler<TElement>(this TElement element, TypedEventHandler<ElementType, TextCompositionChangedEventArgs> handler) where TElement : ElementType
        { element.TextCompositionChanged += handler; return element; }

        public static TElement AddTextCompositionEndedHandler<TElement>(this TElement element, TypedEventHandler<ElementType, TextCompositionEndedEventArgs> handler) where TElement : ElementType
        { element.TextCompositionEnded += handler; return element; }

        public static TElement AddTextCompositionStartedHandler<TElement>(this TElement element, TypedEventHandler<ElementType, TextCompositionStartedEventArgs> handler) where TElement : ElementType
        { element.TextCompositionStarted += handler; return element; }


        #endregion

    }
}