using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElementType = Microsoft.UI.Xaml.Controls.ToolTip;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using Windows.Foundation;
using Microsoft.UI.Xaml.Controls.Primitives;

namespace P42.Uno.Markup
{
    public static class ToolTipExtensions
    {
        #region Properties
        public static TElement HorizontalOffset<TElement>(this TElement element, double value) where TElement : ElementType
        {
            element.HorizontalOffset = value; return element;
        }

        public static TElement IsOpen<TElement>(this TElement element, bool value = true) where TElement : ElementType
        {
            element.IsOpen = value; return element;
        }

        public static TElement Placement<TElement>(this TElement element, PlacementMode value) where TElement : ElementType
        {
            element.Placement = value; return element;
        }

        public static TElement PlacementRect<TElement>(this TElement element, Rect? value) where TElement : ElementType
        {
            element.PlacementRect = value; return element;
        }

        public static TElement PlacementTarget<TElement>(this TElement element, UIElement value) where TElement : ElementType
        {
            element.PlacementTarget = value; return element;
        }

        public static TElement VerticalOffset<TElement>(this TElement element, double value) where TElement : ElementType
        {
            element.VerticalOffset = value; return element;
        }
        #endregion


        #region Events
        public static TElement AddClosedHandler<TElement>(this TElement element, RoutedEventHandler handler) where TElement : ElementType
        { element.Closed += handler; return element; }

        public static TElement AddOpenedHandler<TElement>(this TElement element, RoutedEventHandler handler) where TElement : ElementType
        { element.Opened += handler; return element; }
        #endregion
    }
}
