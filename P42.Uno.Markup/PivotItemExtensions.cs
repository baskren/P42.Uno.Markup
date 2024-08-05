using ElementType = Microsoft.UI.Xaml.Controls.PivotItem;

namespace P42.Uno.Markup;
public static class PivotItemExtensions
{

    public static TElement Header<TElement>(this TElement element, object value) where TElement : ElementType
    { element.Header = value; return element; }
}
