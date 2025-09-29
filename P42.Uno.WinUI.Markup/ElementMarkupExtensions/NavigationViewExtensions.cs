using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Markup;
using Windows.Foundation;
using ElementType = Microsoft.UI.Xaml.Controls.NavigationView;

namespace P42.Uno.Markup;

public static class NavigationViewExtensions
{
    #region Properties



    public static TElement NewMenuItemsX<TElement>(this TElement element, params NavigationViewItem[] items) where TElement : ElementType
    {
        element.MenuItems.Clear();
        return element.MenuItems(items);
    }
    #endregion



}
