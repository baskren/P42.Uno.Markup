using Microsoft.UI.Xaml.Media;
using ElementType = Microsoft.UI.Xaml.Shapes.Polygon;

namespace P42.Uno.Markup;

public static class PolygonExtensions
{
    public static ElementType Points(this ElementType element, PointCollection value)
    { element.Points = value; return element; }

    public static ElementType FillRule(this ElementType element, FillRule value)
    { element.FillRule = value; return element; }


}