using ElementType = Microsoft.UI.Xaml.UIElement;

namespace P42.Uno.WinUI.Markup;

// ReSharper disable once UnusedType.Global
public static class ElementOnCanvasExtensions
{
    /// <summary>
    /// Canvas element Attached Properties Fluent extensions
    /// </summary>
    /// <param name="element"></param>
    /// <typeparam name="TElement"></typeparam>
    // ReSharper disable once UnusedType.Global
    extension<TElement>(TElement element) where TElement : ElementType
    {
        /// <summary>
        /// Fluent setter: Position element from the left of the canvas
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public TElement LeftCanvas(double value)
        { Canvas.SetLeft(element, value); return element; }

        /// <summary>
        /// Fluent setter: Position element from the top of the canvas
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public TElement TopCanvas(double value)
        { Canvas.SetTop(element, value); return element; }

        /// <summary>
        /// Fluent setter: Position element in the Z-direction of the canvas
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public TElement ZCanvas(int value)
        { Canvas.SetZIndex(element, value); return element; }
    }
}
