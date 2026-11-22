using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

//using ElementType = Microsoft.UI.Xaml.Controls.ToggleSwitch;
namespace P42.Uno.Markup;

public static class ToggleSwitchExtensions
{
    public static ToggleSwitch OnContent(this ToggleSwitch element, object value = null) 
    { element.OnContent = value; return element; }

    public static ToggleSwitch OffContent(this ToggleSwitch element, object value = null)
    { element.OffContent = value; return element; }

    public static ToggleSwitch On(this ToggleSwitch element, bool value = true)
    { element.IsOn = value; return element; }

    public static ToggleSwitch Off(this ToggleSwitch element, bool value = true)
    { element.IsOn = !value; return element; }

    public static ToggleSwitch Header(this ToggleSwitch element, object Header = null)
    { element.Header = Header; return element; }

    public static ToggleSwitch AddToggledHandler(this ToggleSwitch element, RoutedEventHandler handler)
    { element.Toggled += handler; return element; }
}