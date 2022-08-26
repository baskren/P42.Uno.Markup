using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using ElementType = Microsoft.UI.Xaml.Controls.Primitives.RangeBase;

namespace P42.Uno.Markup
{
    public static class RangeBaseExtensions
    {
        public static TElement Value<TElement>(this TElement element, double value) where TElement : ElementType
        { element.Value = value; return element; }

        public static TElement SmallChange<TElement>(this TElement element, double value) where TElement : ElementType
        { element.SmallChange = value; return element; }

        public static TElement Min<TElement>(this TElement element, double value) where TElement : ElementType
        { element.Minimum = value; return element; }

        public static TElement Max<TElement>(this TElement element, double value) where TElement : ElementType
        { element.Maximum = value; return element; }

        public static TElement LargeChange<TElement>(this TElement element, double value) where TElement : ElementType
        { element.LargeChange = value; return element; }

        public static TElement MinMax<TElement>(this TElement element, double min, double max) where TElement : ElementType
        { element.Minimum = min; element.Maximum = max; return element; }

        public static TElement MinMaxChange<TElement>(this TElement element, double min, double max, double largeChange) where TElement : ElementType
        { element.Minimum = min; element.Maximum = max; element.LargeChange = largeChange; return element; }

        public static TElement MinMaxChange<TElement>(this TElement element, double min, double max, double largeStep, double smallChange) where TElement : ElementType
        { element.Minimum = min; element.Maximum = max; element.LargeChange = largeStep; element.SmallChange = smallChange; return element; }

        public static TElement AddOnValueChanged<TElement>(this TElement element, RangeBaseValueChangedEventHandler handler) where TElement : ElementType
        { element.ValueChanged += handler; return element; }

    }
}