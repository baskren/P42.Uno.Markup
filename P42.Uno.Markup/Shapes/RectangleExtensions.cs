using ElementType = Microsoft.UI.Xaml.Shapes.Rectangle;

namespace P42.Uno.Markup
{
    public static class RectangleExtensions
    {
        public static ElementType RadiusX(this ElementType element, double value)
        { element.RadiusX = value; return element; }

        public static ElementType RadiusY(this ElementType element, double value)
        { element.RadiusY = value; return element; }


    }
}
