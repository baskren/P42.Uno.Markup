using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;
using ElementType = Microsoft.UI.Xaml.Controls.RadioMenuFlyoutItem;

namespace P42.Uno.Markup;
public static class RadioMenuFlyoutItemExtensions
{

    public static TElement GroupName<TElement>(this TElement element, string value) where TElement : ElementType
    { element.GroupName = value; return element; }

    public static TElement IsChecked<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsChecked = value; return element; }
}
