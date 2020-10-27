using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;
using ElementType = Windows.UI.Xaml.Shapes.Shape;

namespace P42.Uno.Markup.Shapes
{
    public static class ShapeExtensions
    {
        #region Stroke
        public static TElement StrokeThickness<TElement>(this TElement element, double value) where TElement : ElementType
        { element.StrokeThickness = value; return element; }

        public static TElement StrokeStartLineCap<TElement>(this TElement element, PenLineCap value) where TElement : ElementType
        { element.StrokeStartLineCap = value; return element; }

        public static TElement StrokeMiterLimit<TElement>(this TElement element, double value) where TElement : ElementType
        { element.StrokeMiterLimit = value; return element; }

        public static TElement StrokeLineJoin<TElement>(this TElement element, PenLineJoin value) where TElement : ElementType
        { element.StrokeLineJoin = value; return element; }

        public static TElement StrokeEndLineCap<TElement>(this TElement element, PenLineCap value) where TElement : ElementType
        { element.StrokeEndLineCap = value; return element; }

        public static TElement StrokeDashOffset<TElement>(this TElement element, double value) where TElement : ElementType
        { element.StrokeDashOffset = value; return element; }

        public static TElement StrokeDashCap<TElement>(this TElement element, PenLineCap value) where TElement : ElementType
        { element.StrokeDashCap = value; return element; }

        public static TElement StrokeDashArray<TElement>(this TElement element, DoubleCollection value) where TElement : ElementType
        { element.StrokeDashArray = value; return element; }

        public static TElement Stroke<TElement>(this TElement element, Brush value) where TElement : ElementType
        { element.Stroke = value; return element; }

        public static TElement Stroke<TElement>(this TElement element, Color value) where TElement : ElementType
        { element.Stroke = new SolidColorBrush(value); return element; }

        #endregion

        public static TElement Stretch<TElement>(this TElement element, Stretch value) where TElement : ElementType
        { element.Stretch = value; return element; }

        public static TElement Fill<TElement>(this TElement element, Brush value) where TElement : ElementType
        { element.Fill = value; return element; }

        public static TElement Fill<TElement>(this TElement element, Color value) where TElement : ElementType
        { element.Fill = new SolidColorBrush(value); return element; }
    }
}
