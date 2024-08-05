using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using ElementType = Microsoft.UI.Xaml.DependencyObject;

namespace P42.Uno.Markup;
public static class ToolTipServiceExtensions
{
    public static TElement Placement<TElement>(this TElement element, PlacementMode  value) where TElement : ElementType
    { ToolTipService.SetPlacement(element, value); return element; }

    public static TElement PlacementTarget<TElement>(this TElement element, UIElement value) where TElement : ElementType
    { ToolTipService.SetPlacementTarget(element, value); return element; }

    public static TElement ToolTip<TElement>(this TElement element, object value) where TElement : ElementType
    { ToolTipService.SetToolTip(element, value); return element; }
}
