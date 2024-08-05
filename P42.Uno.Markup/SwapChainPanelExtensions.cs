using Microsoft.UI.Xaml.Controls;
using Windows.Foundation;
using ElementType = Microsoft.UI.Xaml.Controls.SwapChainPanel;

namespace P42.Uno.Markup;
public static class SwapChainPanelExtensions
{
    public static TElement AddCompositionScaleChangedHandler<TElement>(this TElement element, TypedEventHandler<SwapChainPanel, object> handler) where TElement : ElementType
    {  element.CompositionScaleChanged += handler; return element; }
}
