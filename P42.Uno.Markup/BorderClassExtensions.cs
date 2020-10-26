using P42.Utils.Uno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using ElementType = Windows.UI.Xaml.Controls.Border;

namespace P42.Uno.Markup
{
    public static class BorderClassExtensions
    {
        #region Padding
        public static ElementType Padding(this ElementType element, double value)
        { element.Padding = new Thickness(value); return element; }

        public static ElementType Padding(this ElementType element, double horizontal, double vertical)
        { element.Padding = new Thickness(horizontal, vertical, horizontal, vertical); return element; }

        public static ElementType Padding(this ElementType element, double left, double top, double right, double bottom)
        { element.Padding = new Thickness(left, top, right, bottom); return element; }

        public static ElementType Padding(this ElementType element, Thickness padding)
        { element.Padding = padding; return element; }
        #endregion


        #region CornerRadius
        public static ElementType CornerRadius(this ElementType element, double value)
        { element.CornerRadius = new CornerRadius(value); return element; }

        public static ElementType CornerRadius(this ElementType element, double topLeft, double topRight, double bottomRight, double bottomLeft)
        { element.CornerRadius = new CornerRadius(topLeft, topRight, bottomRight, bottomLeft); return element; }

        public static ElementType CornerRadius(this ElementType element, CornerRadius padding)
        { element.CornerRadius = padding; return element; }
        #endregion


        public static ElementType ChildTransitions(this ElementType element, TransitionCollection transitions)
        { element.ChildTransitions = transitions; return element; }

        public static ElementType Child(this ElementType element, UIElement child)
        { element.Child = child; return element; }


        #region Border Thickness
        public static ElementType BorderThickness(this ElementType element, double value)
        { element.BorderThickness = new Thickness(value); return element; }

        public static ElementType BorderThickness(this ElementType element, double horizontal, double vertical)
        { element.BorderThickness = new Thickness(horizontal, vertical, horizontal, vertical); return element; }

        public static ElementType BorderThickness(this ElementType element, double left, double top, double right, double bottom)
        { element.BorderThickness = new Thickness(left, top, right, bottom); return element; }

        public static ElementType BorderThickness(this ElementType element, Thickness padding)
        { element.BorderThickness = padding; return element; }
        #endregion


        #region BorderBrush
        public static ElementType BorderBrush(this ElementType element, Brush value)
        { element.BorderBrush = value; return element; }

        public static ElementType BorderBrush(this ElementType element, Color value)
        { element.BorderBrush = new SolidColorBrush(value); return element; }

        public static ElementType BorderBrush(this ElementType element, string hex)
        { element.BorderBrush = new SolidColorBrush(P42.Utils.Uno.ColorExtensions.ColorFromHex(hex)); return element; }
        #endregion


        #region Background
        public static ElementType Background(this ElementType element, Brush brush)
        { element.Background = brush; return element; }

        public static ElementType Background(this ElementType element, Color color)
        { element.Background = new SolidColorBrush(color); return element; }

        public static ElementType Background(this ElementType element, string hex)
        { element.Background = new SolidColorBrush(P42.Utils.Uno.ColorExtensions.ColorFromHex(hex)); return element; }
        #endregion

        public static ElementType BackgroundTransition(this ElementType element, BrushTransition brushTransition)
        { element.BackgroundTransition = brushTransition; return element; }

        public static ElementType BackgroundSizing(this ElementType element, BackgroundSizing sizing)
        { element.BackgroundSizing = sizing; return element; }

        public static ElementType NullOrEmptyCollapse(this ElementType element)
        {
            return element.Bind(TextBlock.VisibilityProperty, element, nameof(TextBlock.Text),
                           convert: (string text) => (!string.IsNullOrEmpty(text)).ToVisibility());
        }
    }
}
