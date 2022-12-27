using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using ElementType = Microsoft.UI.Xaml.Controls.CheckBox;

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

        public static TElement AddCheckedHandler<TElement>(this TElement element, RoutedEventHandler handler) where TElement : ElementType
        { element.Checked += handler; return element; }

        public static TElement AddIndeterminateHandler<TElement>(this TElement element, RoutedEventHandler handler) where TElement : ElementType
        { element.Indeterminate += handler; return element; }

        public static TElement AddUncheckedHandler<TElement>(this TElement element, RoutedEventHandler handler) where TElement : ElementType
        { element.Unchecked += handler; return element; }

    }
}