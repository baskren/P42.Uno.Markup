using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using ElementType = Microsoft.UI.Xaml.Controls.Page;

namespace P42.Uno.Markup;
public static class PageExtensions
{

    public static TElement BottomAppBar<TElement>(this TElement element, AppBar value) where TElement : ElementType
    { element.BottomAppBar = value; return element; }

    public static TElement NavigationCacheMode<TElement>(this TElement element, NavigationCacheMode value) where TElement : ElementType
    { element.NavigationCacheMode = value; return element; }

    public static TElement TopAppBar<TElement>(this TElement element, AppBar value) where TElement : ElementType
    { element.TopAppBar = value; return element; }

}
