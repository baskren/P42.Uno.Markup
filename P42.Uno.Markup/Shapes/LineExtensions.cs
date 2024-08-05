using ElementType = Microsoft.UI.Xaml.Shapes.Line;

namespace P42.Uno.Markup
{
    public static class LineExtensions
    {
        public static ElementType X1(this ElementType element, double value) 
        { element.X1 = value; return element; }

        public static ElementType Y1(this ElementType element, double value)
        { element.Y1 = value; return element; }

        public static ElementType X2(this ElementType element, double value)
        { element.X2 = value; return element; }

        public static ElementType Y2(this ElementType element, double value)
        { element.Y2 = value; return element; }

    }
}
