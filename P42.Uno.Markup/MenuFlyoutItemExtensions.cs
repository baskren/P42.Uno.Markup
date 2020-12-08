using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ElementType = Windows.UI.Xaml.Controls.MenuFlyoutItem;

namespace P42.Uno.Markup
{
    public static class MenuFlyoutItemExtensions
    {
        public static TElement OnClick<TElement>(this TElement element, RoutedEventHandler click) where TElement : ElementType
        {
            element.Click += click;
            return element;
        }
    }
}
