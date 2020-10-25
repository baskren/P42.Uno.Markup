using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using ElementType = Windows.UI.Xaml.Controls.ItemsControl;

namespace P42.Uno.Markup
{
    public static class ItemsControlExtensions
    {
        public static TElement ItemsPanel<TElement>(this TElement element, ItemsPanelTemplate brush) where TElement : ElementType
        { element.ItemsPanel = brush; return element; }

        public static TElement ItemTemplateSelector<TElement>(this TElement element, DataTemplateSelector brush) where TElement : ElementType
        { element.ItemTemplateSelector = brush; return element; }

        public static TElement ItemTemplate<TElement>(this TElement element, DataTemplate brush) where TElement : ElementType
        { element.ItemTemplate = brush; return element; }

        public static TElement ItemContainerTransitions<TElement>(this TElement element, TransitionCollection value) where TElement : ElementType
        { element.ItemContainerTransitions = value; return element; }

        public static TElement ItemContainerStyleSelector<TElement>(this TElement element, StyleSelector value) where TElement : ElementType
        { element.ItemContainerStyleSelector = value; return element; }

        public static TElement GroupStyleSelector<TElement>(this TElement element, GroupStyleSelector value) where TElement : ElementType
        { element.GroupStyleSelector = value; return element; }

        public static TElement DisplayMemberPath<TElement>(this TElement element, string value) where TElement : ElementType
        { element.DisplayMemberPath = value; return element; }

    }
}
