using ElementType = Microsoft.UI.Xaml.Controls.Primitives.ToggleButton;

// ReSharper disable once CheckNamespace
namespace P42.Uno.WinUI.Markup;

// ReSharper disable once UnusedType.Global
public static class ToggleButtonExtensions
{

    #region Events
    
    /// <summary>
    /// Adds the same handler for Check, Indeterminate, and Unchecked property changed events
    /// </summary>
    /// <param name="element"></param>
    /// <param name="handler"></param>
    /// <typeparam name="TElement"></typeparam>
    /// <returns></returns>
    public static TElement AddCheckStateChangedHandler<TElement>(this TElement element, RoutedEventHandler handler) where TElement : ElementType
    { 
        element.Checked += handler;
        element.Indeterminate += handler;
        element.Unchecked += handler;
        return element; 
    }
    #endregion

}
