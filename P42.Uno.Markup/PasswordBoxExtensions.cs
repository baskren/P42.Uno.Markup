using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Windows.UI;
using ElementType = Microsoft.UI.Xaml.Controls.PasswordBox;

namespace P42.Uno.Markup;
public static class PasswordBoxExtensions
{

    public static ElementType Description(this ElementType element, object value)
    { element.Description = value; return element; }

    public static ElementType Header(this ElementType element, object value)
    { element.Header = value; return element; }

    public static ElementType HeaderTemplate(this ElementType element, DataTemplate value)
    { element.HeaderTemplate = value; return element; }

    public static ElementType InputScope(this ElementType element, InputScope value)
    { element.InputScope = value; return element; }

    public static ElementType IsPasswordRevealButtonEnabled(this ElementType element, bool value = true)
    { element.IsPasswordRevealButtonEnabled = value; return element; }

    public static ElementType MaxLength(this ElementType element, int value)
    { element.MaxLength = value; return element; }

    public static ElementType Password(this ElementType element, string value)
    { element.Password = value; return element; }

    public static ElementType PasswordChar(this ElementType element, string value)
    { element.PasswordChar = value; return element; }

    public static ElementType PasswordRevealMode(this ElementType element, PasswordRevealMode value)
    { element.PasswordRevealMode = value; return element; }

    public static ElementType PlaceholderText(this ElementType element, string value)
    { element.PlaceholderText = value; return element; }

    public static ElementType PreventKeyboardDisplayOnProgrammaticFocus(this ElementType element, bool value = true)
    { element.PreventKeyboardDisplayOnProgrammaticFocus = value; return element; }

    public static ElementType SelectionFlyout(this ElementType element, FlyoutBase value)
    { element.SelectionFlyout = value; return element; }

    #region SelectionHighlightColor 
    public static ElementType SelectionHighlightColor(this ElementType element, SolidColorBrush brush)
    { element.SelectionHighlightColor = brush; return element; }

    public static ElementType SelectionHighlightColor(this ElementType element, Color color)
    { element.SelectionHighlightColor = new SolidColorBrush(color); return element; }

    public static ElementType SelectionHighlightColor(this ElementType element, string color)
    { element.SelectionHighlightColor = new SolidColorBrush(ColorExtensions.ColorFromString(color)); return element; }

    public static ElementType SelectionHighlightColor(this ElementType element, uint hex)
    { element.SelectionHighlightColor = new SolidColorBrush(ColorExtensions.ColorFromUint(hex)); return element; }
    #endregion

    public static ElementType TextReadingOrder(this ElementType element, TextReadingOrder value)
    { element.TextReadingOrder = value; return element; }
   
}
