using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using ElementType = Windows.UI.Xaml.Controls.StackPanel ;

namespace P42.Uno.Markup
{
    public static class StackPanelExtensions
    {
        #region Orientation
        public static TElement Orientation<TElement>(this TElement element, Orientation orientation) where TElement : ElementType
        { element.Orientation = orientation; return element; }

        public static TElement Horizontal<TElement>(this TElement element) where TElement : ElementType
        { element.Orientation = Windows.UI.Xaml.Controls.Orientation.Horizontal; return element; }

        public static TElement Vertical<TElement>(this TElement element) where TElement : ElementType
        { element.Orientation = Windows.UI.Xaml.Controls.Orientation.Vertical; return element; }
        #endregion


        public static TElement RegularScrollSnapPoints<TElement>(this TElement element, bool regular = true) where TElement : ElementType
        { element.AreScrollSnapPointsRegular = regular; return element; }


        #region Padding
        public static TElement Padding<TElement>(this TElement element, double value) where TElement : ElementType
        { element.Padding = new Thickness(value); return element; }

        public static TElement Padding<TElement>(this TElement element, double horizontal, double vertical) where TElement : ElementType
        { element.Padding = new Thickness(horizontal, vertical, horizontal, vertical); return element; }

        public static TElement Padding<TElement>(this TElement element, double left, double top, double right, double bottom) where TElement : ElementType
        { element.Padding = new Thickness(left, top, right, bottom); return element; }

        public static TElement Padding<TElement>(this TElement element, Thickness padding) where TElement : ElementType
        { element.Padding = padding; return element; }
        #endregion


        #region CornerRadius
        public static TElement CornerRadius<TElement>(this TElement element, double value) where TElement : ElementType
        { element.CornerRadius = new CornerRadius(value); return element; }

        public static TElement CornerRadius<TElement>(this TElement element, double topLeft, double topRight, double bottomRight, double bottomLeft) where TElement : ElementType
        { element.CornerRadius = new CornerRadius(topLeft, topRight, bottomRight, bottomLeft); return element; }

        public static TElement CornerRadius<TElement>(this TElement element, CornerRadius padding) where TElement : ElementType
        { element.CornerRadius = padding; return element; }
        #endregion


        #region Border Thickness
        public static TElement BorderThickness<TElement>(this TElement element, double value) where TElement : ElementType
        { element.BorderThickness = new Thickness(value); return element; }

        public static TElement BorderThickness<TElement>(this TElement element, double horizontal, double vertical) where TElement : ElementType
        { element.BorderThickness = new Thickness(horizontal, vertical, horizontal, vertical); return element; }

        public static TElement BorderThickness<TElement>(this TElement element, double left, double top, double right, double bottom) where TElement : ElementType
        { element.BorderThickness = new Thickness(left, top, right, bottom); return element; }

        public static TElement BorderThickness<TElement>(this TElement element, Thickness padding) where TElement : ElementType
        { element.BorderThickness = padding; return element; }
        #endregion


        #region BorderBrush
        public static TElement BorderBrush<TElement>(this TElement element, Brush value) where TElement : ElementType
        { element.BorderBrush = value; return element; }

        public static TElement BorderBrush<TElement>(this TElement element, Color value) where TElement : ElementType
        { element.BorderBrush = new SolidColorBrush(value); return element; }

        public static TElement BorderBrush<TElement>(this TElement element, string hex) where TElement : ElementType
        { element.BorderBrush = new SolidColorBrush(ColorExtensions.ColorFromString(hex)); return element; }
        #endregion


        public static TElement Spacing<TElement>(this TElement element, double value) where TElement : ElementType
        { element.Spacing = value; return element; }

        public static TElement BackgroundSizing<TElement>(this TElement element, BackgroundSizing value) where TElement : ElementType
        { element.BackgroundSizing = value; return element; }


        #region Events
        public static TElement AddOnHorizontalSnapPointsChanged<TElement>(this TElement element, EventHandler<object> handler) where TElement : ElementType
        { element.HorizontalSnapPointsChanged += handler; return element; }

        public static TElement AddOnVerticalSnapPointsChanged<TElement>(this TElement element, EventHandler<object> handler) where TElement : ElementType
        { element.VerticalSnapPointsChanged += handler; return element; }
        #endregion
    }
}
