using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using ElementType = Windows.UI.Xaml.Controls.AppBarButton;


namespace P42.Uno.Markup
{
    public static class AppBarButtonExtensions
    {
        public static TElement Label<TElement>(this TElement element, string value = null) where TElement : ElementType
        { element.Label = value; return element; }

        public static TElement Icon<TElement>(this TElement element, IconElement value = null) where TElement : ElementType
        { element.Icon = value; return element; }

        public static TElement Icon<TElement>(this TElement element, Symbol value) where TElement : ElementType
        { element.Icon = new SymbolIcon { Symbol = value }; return element; }

        public static TElement LabelCollapsed<TElement>(this TElement element, bool isCollapsed = true) where TElement : ElementType
        { element.LabelPosition = isCollapsed ? CommandBarLabelPosition.Collapsed : CommandBarLabelPosition.Default; return element; }

        public static TElement KeyboardAcceleratorTextOverride<TElement>(this TElement element, string textOverride) where TElement : ElementType
        { element.KeyboardAcceleratorTextOverride = textOverride; return element; }

        public static TElement Compact<TElement>(this TElement element, bool isCompact = true) where TElement : ElementType
        { element.IsCompact = isCompact; return element; }

        public static TElement DynamicOverflowOrder<TElement>(this TElement element, int index) where TElement : ElementType
        { element.DynamicOverflowOrder = index; return element; }

    }
}
