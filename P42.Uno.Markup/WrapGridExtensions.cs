using Microsoft.UI.Xaml.Controls;
using ElementType = Microsoft.UI.Xaml.Controls.WrapGrid;
using Microsoft.UI.Xaml;

namespace P42.Uno.Markup;
public static class WrapGridExtensions
{

    public static ElementType HorizontalChildrenAlignment(this ElementType element, HorizontalAlignment value)
    { element.HorizontalChildrenAlignment = value; return element; }

    public static ElementType ItemHeight(this ElementType element, double value)
    { element.ItemHeight = value; return element; }

    public static ElementType ItemWidth(this ElementType element, double value)
    { element.ItemWidth = value; return element; }

    public static ElementType MaximumRowsOrColumns(this ElementType element, int value)
    { element.MaximumRowsOrColumns = value; return element; }

    public static ElementType Orientation(this ElementType element, Orientation value)
    { element.Orientation = value; return element; }

    public static ElementType VerticalChildrenAlignment(this ElementType element, VerticalAlignment value)
    { element.VerticalChildrenAlignment = value; return element; }
}
