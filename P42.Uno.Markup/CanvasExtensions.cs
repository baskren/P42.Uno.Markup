using Microsoft.UI.Xaml.Controls;
using ElementType = Microsoft.UI.Xaml.UIElement;

namespace P42.Uno.Markup;

public static class CanvasExtensions
{
    public static TElement CanvasLeft<TElement>(this TElement element, double value) where TElement : ElementType
    { Canvas.SetLeft(element, value); return element; }

    public static TElement CanvasTop<TElement>(this TElement element, double value) where TElement : ElementType
    { Canvas.SetTop(element, value); return element; }

    public static TElement CanvasZ<TElement>(this TElement element, int value) where TElement : ElementType
    { Canvas.SetZIndex(element, value); return element; }



}
