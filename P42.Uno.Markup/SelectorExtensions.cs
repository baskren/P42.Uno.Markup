﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Animation;
using ElementType = Microsoft.UI.Xaml.Controls.Primitives.Selector;

namespace P42.Uno.Markup
{
    public static class SelectorExtensions
    {
        #region Properties
        public static TElement SynchronizedWithCurrentItem<TElement>(this TElement element, bool? value) where TElement : ElementType
        { element.IsSynchronizedWithCurrentItem = value; return element; }
        public static TElement SelectedIndex<TElement>(this TElement element, int value) where TElement : ElementType
        { element.SelectedIndex = value; return element; }

        public static TElement SelectedItem<TElement>(this TElement element, object value) where TElement : ElementType
        { element.SelectedItem = value; return element; }

        public static TElement SelectedValue<TElement>(this TElement element, object value) where TElement : ElementType
        { element.SelectedValue = value; return element; }

        public static TElement SelectedValuePath<TElement>(this TElement element, string value) where TElement : ElementType
        { element.SelectedValuePath = value; return element; }

        #endregion

        #region Events
        public static TElement AddSelectionChangedHandler<TElement>(this TElement element, SelectionChangedEventHandler handler) where TElement : ElementType
        { element.SelectionChanged += handler; return element; }
        #endregion

    }
}
