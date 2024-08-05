using Microsoft.UI.Xaml.Controls;
using ElementType = Microsoft.UI.Xaml.Controls.StackLayout;

namespace P42.Uno.Markup;
public static class StackLayoutExtensions
{
    public static TElement Orientation<TElement>(this TElement element, Orientation orientation) where TElement : ElementType
    { element.Orientation = orientation; return element; }

    public static TElement Spacing<TElement>(this TElement element, double spacing) where TElement : ElementType
    { element.Spacing = spacing; return element; }

}
