//NavigationViewItem
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using ElementType = Microsoft.UI.Xaml.Controls.NavigationViewItem;

namespace P42.Uno.Markup
{
    public static class NavigationViewItemExtensions
    {
        public static TElement HasUnrealizedChildren<TElement>(this TElement element, bool value) where TElement : ElementType
        { element.HasUnrealizedChildren = value; return element; }

        public static TElement Icon<TElement>(this TElement element, IconElement value) where TElement : ElementType
        { element.Icon = value; return element; }

        public static TElement IsExpanded<TElement>(this TElement element, bool value) where TElement : ElementType
        { element.IsExpanded = value; return element; }

        public static TElement MenuItemsSource<TElement>(this TElement element, object value) where TElement : ElementType
        { element.MenuItemsSource = value; return element; }

        public static TElement SelectsOnInvoked<TElement>(this TElement element, bool value) where TElement : ElementType
        { element.SelectsOnInvoked = value; return element; }

    }
}