using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Windows.Foundation;
using ElementType = Microsoft.UI.Xaml.Controls.PickerFlyout;

namespace P42.Uno.Markup;
public static class PickerFlyoutExtensions
{

    public static ElementType ConfirmationButtonsVisible(this ElementType element, bool value = true)
    { element.ConfirmationButtonsVisible = value; return element; }

    public static ElementType Content(this ElementType element, UIElement value)
    { element.Content = value; return element; }

    #region Events

    public static ElementType AddConfirmedHandler(this ElementType element, TypedEventHandler<PickerFlyout, PickerConfirmedEventArgs> handler)
    { element.Confirmed += handler; return element; }
    #endregion
}
