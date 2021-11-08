using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using ElementType = Windows.UI.Xaml.Controls.Primitives.Selector;

namespace P42.Uno.Markup
{
    public static class SelectorExtensions
    {
        public static TElement SelectedValuePath<TElement>(this TElement element, string value) where TElement : ElementType
        { element.SelectedValuePath = value; return element; }

        public static TElement SelectedValue<TElement>(this TElement element, object value) where TElement : ElementType
        { element.SelectedValue = value; return element; }

        public static TElement SelectedItem<TElement>(this TElement element, object value) where TElement : ElementType
        { element.SelectedItem = value; return element; }

        public static TElement SelectedIndex<TElement>(this TElement element, int value) where TElement : ElementType
        { element.SelectedIndex = value; return element; }

        public static TElement SynchronizedWithCurrentItem<TElement>(this TElement element, bool? value) where TElement : ElementType
        { element.IsSynchronizedWithCurrentItem = value; return element; }

        #region Events
        public static TElement AddOnSelectionChanged<TElement>(this TElement element, SelectionChangedEventHandler handler) where TElement : ElementType
        { element.SelectionChanged += handler; return element; }
        #endregion
    }
}
