using ElementType = Microsoft.UI.Xaml.Controls.Primitives.ToggleButton;

namespace P42.Uno.WinUI.Markup;

// ReSharper disable once UnusedType.Global
public static class ToggleButtonExtensions
{

    #region Events
    public static TElement AddCheckStateChangedHandler<TElement>(this TElement element, RoutedEventHandler handler) where TElement : ElementType
    { 
        element.Checked += handler;
        element.Indeterminate += handler;
        element.Unchecked += handler;
        return element; 
    }
    #endregion

}
