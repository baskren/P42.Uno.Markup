using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using ElementType = Windows.UI.Xaml.Shapes.Path;

namespace P42.Uno.Markup.Shapes
{
    public static class PathExtensions
    {
        public static TElement Data<TElement>(this TElement element, Geometry value) where TElement : ElementType
        { element.Data = value; return element; }

    }
}
