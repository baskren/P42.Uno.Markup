using Microsoft.UI.Xaml;
using ElementType = Microsoft.UI.Xaml.Controls.Primitives.ToggleButton;

namespace P42.Uno.Markup;

public static class ToggleButtonExtensions
{

    #region Events
    public static TElement AddCheckStateChangedHandlerX<TElement>(this TElement element, RoutedEventHandler handler) where TElement : ElementType
    { 
        element.Checked += handler;
        element.Indeterminate += handler;
        element.Unchecked += handler;
        return element; 
    }
    #endregion

}
