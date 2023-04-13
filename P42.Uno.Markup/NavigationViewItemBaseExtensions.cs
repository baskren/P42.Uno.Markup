//NavigationViewItem
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using ElementType = Microsoft.UI.Xaml.Controls.NavigationViewItemBase;

namespace P42.Uno.Markup
{
    public static class NavigationViewItemBaseExtensions
    {
        public static TElement IsSelected<TElement>(this TElement element, bool value) where TElement : ElementType
        { element.IsSelected = value; return element; }


    }
}