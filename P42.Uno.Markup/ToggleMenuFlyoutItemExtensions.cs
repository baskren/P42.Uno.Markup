using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElementType = Microsoft.UI.Xaml.Controls.ToggleMenuFlyoutItem;

namespace P42.Uno.Markup;
public static class ToggleMenuFlyoutItemExtensions
{
    public static TElement IsChecked<TElement>(this TElement element, bool isChecked = true) where TElement : ElementType
    { element.IsChecked = isChecked; return element; }

    public static TElement IsUnchecked<TElement>(this TElement element, bool isUnchecked = true) where TElement : ElementType
    { element.IsChecked = !isUnchecked; return element; }
}
