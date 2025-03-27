using Microsoft.UI.Xaml;
using ElementType = Microsoft.UI.Xaml.Controls.Primitives.ToggleButton;

namespace P42.Uno.Markup;

public static class ToggleButtonExtensions
{
    #region Properties
    public static TElement IsChecked<TElement>(this TElement element, bool isChecked = true) where TElement : ElementType
    { element.IsChecked = isChecked; return element; }

    public static TElement IsThreeState<TElement>(this TElement element, bool threeState = true) where TElement : ElementType
    { element.IsThreeState = threeState; return element; }
    #endregion


    #region Events
    public static TElement AddCheckedHandler<TElement>(this TElement element, RoutedEventHandler handler) where TElement : ElementType
    { element.Checked += handler; return element; }

    public static TElement AddIndeterminateHandler<TElement>(this TElement element, RoutedEventHandler handler) where TElement : ElementType
    { element.Indeterminate += handler; return element; }

    public static TElement AddUncheckedHandler<TElement>(this TElement element, RoutedEventHandler handler) where TElement : ElementType
    { element.Unchecked += handler; return element; }

    public static TElement AddCheckStateChangedHandler<TElement>(this TElement element, RoutedEventHandler handler) where TElement : ElementType
    { 
        element.Checked += handler;
        element.Indeterminate += handler;
        element.Unchecked += handler;
        return element; 
    }
    #endregion

}
