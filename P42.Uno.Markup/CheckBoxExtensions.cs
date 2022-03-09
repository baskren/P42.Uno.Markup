using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using ElementType = Windows.UI.Xaml.Controls.CheckBox;

namespace P42.Uno.Markup
{
    public static class CheckBoxExtensions
    {
        public static TElement ThreeState<TElement>(this TElement element, bool isThreeState = true) where TElement : ElementType
        { element.IsThreeState = isThreeState; return element; }

        public static TElement Checked<TElement>(this TElement element, bool isChecked = true) where TElement : ElementType
        { element.IsChecked = isChecked; return element; }

        public static TElement Unchecked<TElement>(this TElement element, bool isUnchecked = true) where TElement : ElementType
        { element.IsChecked = !isUnchecked; return element; }

        public static TElement AddOnChecked<TElement>(this TElement element, RoutedEventHandler handler) where TElement : ElementType
        { element.Checked += handler; return element; }

        public static TElement AddOnIndeterminate<TElement>(this TElement element, RoutedEventHandler handler) where TElement : ElementType
        { element.Indeterminate += handler; return element; }

        public static TElement AddOnUnchecked<TElement>(this TElement element, RoutedEventHandler handler) where TElement : ElementType
        { element.Unchecked += handler; return element; }

    }
}