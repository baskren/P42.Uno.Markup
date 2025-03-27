using Microsoft.UI.Xaml.Media;
using ElementType = Microsoft.UI.Xaml.Shapes.Path;

namespace P42.Uno.Markup;

public static class PathExtensions
{
    public static TElement Data<TElement>(this TElement element, Geometry value) where TElement : ElementType
    { element.Data = value; return element; }

}
