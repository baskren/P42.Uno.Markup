using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Media;
using ElementType = Microsoft.UI.Xaml.Shapes.Polyline;

namespace P42.Uno.Markup
{
    public static class PolylineExtensions
    {
        public static ElementType Points(this ElementType element, PointCollection value)
        { element.Points = value; return element; }

        public static ElementType FillRule(this ElementType element, FillRule value)
        { element.FillRule = value; return element; }


    }
}
