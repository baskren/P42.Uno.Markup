using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using ElementType = Windows.UI.Xaml.Controls.TextBox;

namespace P42.Uno.Markup
{
    public static class TextBoxExtensions
    {
        public static TElement TextWrapping<TElement>(this TElement element, TextWrapping value) where TElement : ElementType
        { element.TextWrapping = value; return element; }

        public static TElement TextAlignment<TElement>(this TElement element, TextAlignment value) where TElement : ElementType
        { element.TextAlignment = value; return element; }

        public static TElement Text<TElement>(this TElement element, string value) where TElement : ElementType
        { element.Text = value ?? string.Empty; return element; }

        public static TElement SelectionStart<TElement>(this TElement element, int value) where TElement : ElementType
        { element.SelectionStart = value; return element; }

        public static TElement SelectionLength<TElement>(this TElement element, int value) where TElement : ElementType
        { element.SelectionLength = value; return element; }

        public static TElement SelectedText<TElement>(this TElement element, string value) where TElement : ElementType
        { element.SelectedText = value; return element; }

        public static TElement MaxLength<TElement>(this TElement element, int value) where TElement : ElementType
        { element.MaxLength = value; return element; }

        public static TElement TextPredictionEnabled<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsTextPredictionEnabled = value; return element; }

        public static TElement SpellCheckEnabled<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsSpellCheckEnabled = value; return element; }

        public static TElement ReadOnly<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsReadOnly = value; return element; }

        public static TElement InputScope<TElement>(this TElement element, InputScope value) where TElement : ElementType
        { element.InputScope = value; return element; }

        public static TElement AcceptsReturn<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.AcceptsReturn = value; return element; }

        public static TElement ColorFontEnabled<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsColorFontEnabled = value; return element; }

        public static TElement PlaceholderText<TElement>(this TElement element, string value) where TElement : ElementType
        { element.PlaceholderText = value; return element; }

        public static TElement PreventKeyboardDisplayOnProgrammaticFocus<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.PreventKeyboardDisplayOnProgrammaticFocus = value; return element; }

        public static TElement SelectionHighlightColor<TElement>(this TElement element, SolidColorBrush value) where TElement : ElementType
        { element.SelectionHighlightColor = value; return element; }

        public static TElement SelectionHighlightColor<TElement>(this TElement element, Color value) where TElement : ElementType
        { element.SelectionHighlightColor = new SolidColorBrush(value); return element; }

        public static TElement HeaderTemplate<TElement>(this TElement element, DataTemplate value) where TElement : ElementType
        { element.HeaderTemplate = value; return element; }

        public static TElement Header<TElement>(this TElement element, object value) where TElement : ElementType
        { element.Header = value; return element; }

        public static TElement DesiredCandidateWindowAlignment<TElement>(this TElement element, CandidateWindowAlignment value) where TElement : ElementType
        { element.DesiredCandidateWindowAlignment = value; return element; }

        public static TElement TextReadingOrder<TElement>(this TElement element, TextReadingOrder value) where TElement : ElementType
        { element.TextReadingOrder = value; return element; }

        public static TElement SelectionHighlightColorWhenNotFocused<TElement>(this TElement element, SolidColorBrush value) where TElement : ElementType
        { element.SelectionHighlightColorWhenNotFocused = value; return element; }

        public static TElement SelectionHighlightColorWhenNotFocused<TElement>(this TElement element, Color value) where TElement : ElementType
        { element.SelectionHighlightColorWhenNotFocused = new SolidColorBrush(value); return element; }

        public static TElement PlaceholderForeground<TElement>(this TElement element, Brush value) where TElement : ElementType
        { element.PlaceholderForeground = value; return element; }

        public static TElement PlaceholderForeground<TElement>(this TElement element, Color value) where TElement : ElementType
        { element.PlaceholderForeground = new SolidColorBrush(value); return element; }

        public static TElement HorizontalTextAlignment<TElement>(this TElement element, TextAlignment value) where TElement : ElementType
        { element.HorizontalTextAlignment = value; return element; }

        public static TElement CharacterCasing<TElement>(this TElement element, CharacterCasing value) where TElement : ElementType
        { element.CharacterCasing = value; return element; }

        public static TElement HandwritingViewEnabled<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsHandwritingViewEnabled = value; return element; }

        public static TElement HandwritingView<TElement>(this TElement element, HandwritingView value) where TElement : ElementType
        { element.HandwritingView = value; return element; }

        public static TElement SelectionFlyout<TElement>(this TElement element, FlyoutBase value) where TElement : ElementType
        { element.SelectionFlyout = value; return element; }

        public static TElement Description<TElement>(this TElement element, object value) where TElement : ElementType
        { element.Description = value; return element; }


        #region Events
        public static TElement AddOnContextMenuOpening<TElement>(this TElement element, ContextMenuOpeningEventHandler handler) where TElement : ElementType
        { element.ContextMenuOpening += handler; return element; }

        public static TElement AddOnSelectionChanged<TElement>(this TElement element, RoutedEventHandler handler) where TElement : ElementType
        { element.SelectionChanged += handler; return element; }

        public static TElement AddOnTextChanged<TElement>(this TElement element, TextChangedEventHandler handler) where TElement : ElementType
        { element.TextChanged += handler; return element; }

        public static TElement AddOnPaste<TElement>(this TElement element, TextControlPasteEventHandler handler) where TElement : ElementType
        { element.Paste += handler; return element; }

        public static TElement AddOnCandidateWindowBoundsChanged<TElement>(this TElement element, TypedEventHandler<TextBox, CandidateWindowBoundsChangedEventArgs> handler) where TElement : ElementType
        { element.CandidateWindowBoundsChanged += handler; return element; }

        public static TElement AddOnCandidateWindowBoundsChanged<TElement>(this TElement element, TypedEventHandler<TextBox, TextBoxTextChangingEventArgs> handler) where TElement : ElementType
        { element.TextChanging += handler; return element; }

        public static TElement AddOnCandidateWindowBoundsChanged<TElement>(this TElement element, TypedEventHandler<TextBox, TextCompositionChangedEventArgs> handler) where TElement : ElementType
        { element.TextCompositionChanged += handler; return element; }

        public static TElement AddOnCandidateWindowBoundsChanged<TElement>(this TElement element, TypedEventHandler<TextBox, TextCompositionEndedEventArgs> handler) where TElement : ElementType
        { element.TextCompositionEnded += handler; return element; }

        public static TElement AddOnCandidateWindowBoundsChanged<TElement>(this TElement element, TypedEventHandler<TextBox, TextCompositionStartedEventArgs> handler) where TElement : ElementType
        { element.TextCompositionStarted += handler; return element; }

        public static TElement AddOnCandidateWindowBoundsChanged<TElement>(this TElement element, TypedEventHandler<TextBox, TextBoxBeforeTextChangingEventArgs> handler) where TElement : ElementType
        { element.BeforeTextChanging += handler; return element; }

        public static TElement AddOnCandidateWindowBoundsChanged<TElement>(this TElement element, TypedEventHandler<TextBox, TextControlCopyingToClipboardEventArgs> handler) where TElement : ElementType
        { element.CopyingToClipboard += handler; return element; }

        public static TElement AddOnCandidateWindowBoundsChanged<TElement>(this TElement element, TypedEventHandler<TextBox, TextControlCuttingToClipboardEventArgs> handler) where TElement : ElementType
        { element.CuttingToClipboard += handler; return element; }

        public static TElement AddOnCandidateWindowBoundsChanged<TElement>(this TElement element, TypedEventHandler<TextBox, TextBoxSelectionChangingEventArgs> handler) where TElement : ElementType
        { element.SelectionChanging += handler; return element; }

        #endregion

    }
}
