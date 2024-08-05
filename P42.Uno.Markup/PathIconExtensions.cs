using Microsoft.UI.Xaml.Media;
using ElementType = Microsoft.UI.Xaml.Controls.PathIcon;

namespace P42.Uno.Markup
{
    public static class PathIconExtensions
    {
        public static TElement Data<TElement>(this TElement element, Geometry data) where TElement : ElementType
        { element.Data = data; return element; }

    }
}