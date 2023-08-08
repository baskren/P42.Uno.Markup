using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElementType = Microsoft.UI.Xaml.Controls.TreeView;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using Windows.Foundation;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Media.Animation;

namespace P42.Uno.Markup
{
    public static class TreeViewExtensions
    {
        #region Properties
        public static TElement CanDragItems<TElement>(this TElement element, bool value = true) where TElement : ElementType
        {
            element.CanDragItems = value; return element;
        }

        public static TElement CanReorderItems<TElement>(this TElement element, bool value = true) where TElement : ElementType
        {
            element.CanReorderItems = value; return element;
        }

        public static TElement ItemContainerStyle<TElement>(this TElement element, Style value) where TElement : ElementType
        {
            element.ItemContainerStyle = value; return element;
        }

        public static TElement ItemContainerStyleSelector<TElement>(this TElement element, StyleSelector value) where TElement : ElementType
        {
            element.ItemContainerStyleSelector = value; return element;
        }

        public static TElement ItemContainerTransitions<TElement>(this TElement element, TransitionCollection value) where TElement : ElementType
        {
            element.ItemContainerTransitions = value; return element;
        }

        public static TElement ItemsSource<TElement>(this TElement element, object value) where TElement : ElementType
        {
            element.ItemsSource = value; return element;
        }

        public static TElement ItemTemplate<TElement>(this TElement element, DataTemplate value) where TElement : ElementType
        {
            element.ItemTemplate = value; return element;
        }

        public static TElement ItemTemplateSelector<TElement>(this TElement element, DataTemplateSelector value) where TElement : ElementType
        {
            element.ItemTemplateSelector = value; return element;
        }

        public static TElement SelectedItem<TElement>(this TElement element, object value) where TElement : ElementType
        {
            element.SelectedItem = value; return element;
        }

        public static TElement SelectionMode<TElement>(this TElement element, TreeViewSelectionMode value) where TElement : ElementType
        {
            element.SelectionMode = value; return element;
        }
        #endregion


        #region Events
        public static TElement AddCollapsedHandler<TElement>(this TElement element, TypedEventHandler<TreeView, TreeViewCollapsedEventArgs> handler) where TElement : ElementType
        { element.Collapsed += handler; return element; }

        public static TElement AddDragItemsCompletedHandler<TElement>(this TElement element, TypedEventHandler<TreeView, TreeViewDragItemsCompletedEventArgs> handler) where TElement : ElementType
        { element.DragItemsCompleted += handler; return element; }

        public static TElement AddDragItemsStartingHandler<TElement>(this TElement element, TypedEventHandler<TreeView, TreeViewDragItemsStartingEventArgs> handler) where TElement : ElementType
        { element.DragItemsStarting += handler; return element; }

        public static TElement AddExpandingHandler<TElement>(this TElement element, TypedEventHandler<TreeView, TreeViewExpandingEventArgs> handler) where TElement : ElementType
        { element.Expanding += handler; return element; }

        public static TElement AddItemInvokedHandler<TElement>(this TElement element, TypedEventHandler<TreeView, TreeViewItemInvokedEventArgs> handler) where TElement : ElementType
        { element.ItemInvoked += handler; return element; }

        #endregion

    }
}
