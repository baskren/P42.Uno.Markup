using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using ElementType = Microsoft.UI.Xaml.Controls.VirtualizingLayoutContext;

namespace P42.Uno.Markup;
public static class VirtualizingLayoutContextExtensions
{

    public static TElement LayoutOrigin<TElement>(this TElement element, Point value) where TElement : ElementType
    { element.LayoutOrigin = value; return element; }


}
