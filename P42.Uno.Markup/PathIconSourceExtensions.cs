using Microsoft.UI.Xaml.Media;
using ElementType = Microsoft.UI.Xaml.Controls.PathIconSource;

namespace P42.Uno.Markup
{
    public static class PathIconSourceExtensions
    {
        public static TElement Data<TElement>(this TElement element, Geometry data) where TElement : ElementType
        { element.Data = data; return element; }

    }
}