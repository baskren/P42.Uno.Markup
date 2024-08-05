using Microsoft.UI.Xaml.Controls;
using ElementType = Microsoft.UI.Xaml.Controls.VirtualizingStackPanel;
using DependencyObject = Microsoft.UI.Xaml.DependencyObject;

namespace P42.Uno.Markup;
public static class VirtualizingStackPanelExtensions
{

    public static ElementType AreScrollSnapPointsRegular(this ElementType element, bool value = true)
    { element.AreScrollSnapPointsRegular = value; return element; }


    public static ElementType Orientation(this ElementType element, Orientation value)
    { element.Orientation = value; return element; }


    #region Attached Properties
    public static TElement SetVirtualizationMode<TElement>(this TElement element, VirtualizationMode value) where TElement : DependencyObject
    { VirtualizingStackPanel.SetVirtualizationMode(element, value); return element; }
    #endregion
}
