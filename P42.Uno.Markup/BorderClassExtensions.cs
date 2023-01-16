using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using ElementType = Microsoft.UI.Xaml.Controls.Border;

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

        public static ElementType CornerRadius(this ElementType element, CornerRadius radii)
        { element.CornerRadius = radii; return element; }
        #endregion


        public static ElementType ChildTransitions(this ElementType element, TransitionCollection transitions)
        { element.ChildTransitions = transitions; return element; }

        public static ElementType Child(this ElementType element, UIElement child = null)
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

        public static ElementType BorderBrush(this ElementType element, string color)
        { element.BorderBrush = new SolidColorBrush(ColorExtensions.ColorFromString(color)); return element; }

        public static ElementType BorderBrush(this ElementType element, uint hex)
        { element.BorderBrush = new SolidColorBrush(ColorExtensions.ColorFromUint(hex)); return element; }
        #endregion


        #region Background
        public static ElementType Background(this ElementType element, Brush brush)
        { element.Background = brush; return element; }

        public static ElementType Background(this ElementType element, Color color)
        { element.Background = new SolidColorBrush(color); return element; }

        public static ElementType Background(this ElementType element, string color)
        { element.Background = new SolidColorBrush(ColorExtensions.ColorFromString(color)); return element; }

        public static ElementType Background(this ElementType element, uint hex)
        { element.Background = new SolidColorBrush(ColorExtensions.ColorFromUint(hex)); return element; }
        #endregion

        public static ElementType BackgroundTransition(this ElementType element, BrushTransition brushTransition)
        { element.BackgroundTransition = brushTransition; return element; }

        public static ElementType BackgroundSizing(this ElementType element, BackgroundSizing sizing)
        { element.BackgroundSizing = sizing; return element; }

        public static ElementType BindNullCollapse(this ElementType element)
        {
            return element.Bind(TextBlock.VisibilityProperty, element, nameof(TextBlock.Text),
                           convert: (string text) => (!string.IsNullOrEmpty(text)?Visibility.Visible:Visibility.Collapsed));
        }

        #region BindBorder

        public static Border BindBorder(this Border target, Control source, BindingMode bindingMode = BindingMode.OneWay) 
        {
            target.Bind(ElementType.BorderBrushProperty, source, nameof(Control.BorderBrush), bindingMode);
            target.Bind(ElementType.BorderThicknessProperty, source, nameof(Control.BorderThickness), bindingMode);
            target.Bind(ElementType.CornerRadiusProperty, source, nameof(Control.CornerRadius), bindingMode);
            return target;
        }
        public static Border BindBorder(this Border target, ContentPresenter source, BindingMode bindingMode = BindingMode.OneWay)
        {
            target.Bind(ElementType.BorderBrushProperty, source, nameof(ContentPresenter.BorderBrush), bindingMode);
            target.Bind(ElementType.BorderThicknessProperty, source, nameof(ContentPresenter.BorderThickness), bindingMode);
            target.Bind(ElementType.CornerRadiusProperty, source, nameof(ContentPresenter.CornerRadius), bindingMode);
            return target;
        }
        public static Border BindBorder(this Border target, Border source, BindingMode bindingMode = BindingMode.OneWay) 
        {
            target.Bind(ElementType.BorderBrushProperty, source, nameof(Border.BorderBrush), bindingMode);
            target.Bind(ElementType.BorderThicknessProperty, source, nameof(Border.BorderThickness), bindingMode);
            target.Bind(ElementType.CornerRadiusProperty, source, nameof(Border.CornerRadius), bindingMode);
            return target;
        }

        #endregion

    }
}
