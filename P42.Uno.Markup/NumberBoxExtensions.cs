using Windows.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Media;
using Windows.Globalization.NumberFormatting;
using ElementType = Microsoft.UI.Xaml.Controls.NumberBox;
using Microsoft.UI.Xaml.Controls;
using Windows.Foundation;

namespace P42.Uno.Markup;
public static class NumberBoxExtensions
{

    public static TElement AcceptsExpression<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.AcceptsExpression = value; return element; }

    public static TElement Description<TElement>(this TElement element, object value) where TElement : ElementType
    { element.Description = value; return element; }

    public static TElement Header<TElement>(this TElement element, object value) where TElement : ElementType
    { element.Header = value; return element; }

    public static TElement HeaderTemplate<TElement>(this TElement element, DataTemplate value) where TElement : ElementType
    { element.HeaderTemplate = value; return element; }

    public static TElement IsWrapEnabled<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsWrapEnabled = value; return element; }

    public static TElement LargeChange<TElement>(this TElement element, double value) where TElement : ElementType
    { element.LargeChange = value; return element; }

    public static TElement Maximum<TElement>(this TElement element, double value) where TElement : ElementType
    { element.Maximum = value; return element; }

    public static TElement Minimum<TElement>(this TElement element, double value) where TElement : ElementType
    { element.Minimum = value; return element; }

    public static TElement NumberFormatter<TElement>(this TElement element, INumberFormatter2 value) where TElement : ElementType
    { element.NumberFormatter = value; return element; }

    public static TElement PlaceholderText<TElement>(this TElement element, string value) where TElement : ElementType
    { element.PlaceholderText = value; return element; }

    public static TElement PreventKeyboardDisplayOnProgrammaticFocus<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.PreventKeyboardDisplayOnProgrammaticFocus = value; return element; }

    public static TElement SelectionFlyout<TElement>(this TElement element, FlyoutBase value) where TElement : ElementType
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

    public static TElement SmallChange<TElement>(this TElement element, double value) where TElement : ElementType
    { element.SmallChange = value; return element; }

    public static TElement SpinButtonPlacementMode<TElement>(this TElement element, NumberBoxSpinButtonPlacementMode value) where TElement : ElementType
    { element.SpinButtonPlacementMode = value; return element; }

    public static TElement Text<TElement>(this TElement element, string value) where TElement : ElementType
    { element.Text = value; return element; }

    public static TElement TextReadingOrder<TElement>(this TElement element, TextReadingOrder value) where TElement : ElementType
    { element.TextReadingOrder = value; return element; }

    public static TElement ValidationMode<TElement>(this TElement element, NumberBoxValidationMode value) where TElement : ElementType
    { element.ValidationMode = value; return element; }

    public static TElement Value<TElement>(this TElement element, double value) where TElement : ElementType
    { element.Value = value; return element; }

    #region Events

    public static TElement AddValueChangedHandler<TElement>(this TElement element, TypedEventHandler<NumberBox, NumberBoxValueChangedEventArgs> handler) where TElement : ElementType
    { element.ValueChanged += handler; return element; }
    #endregion
}
