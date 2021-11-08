using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
//using ElementType = Windows.UI.Xaml.Controls.ToggleSwitch;
namespace P42.Uno.Markup
{
    public static class ToggleSwitchExtensions
    {
        public static ToggleSwitch OnContent(this ToggleSwitch element, object value = null) 
        { element.OnContent = value; return element; }

        public static ToggleSwitch OffContent(this ToggleSwitch element, object value = null)
        { element.OffContent = value; return element; }

        public static ToggleSwitch On(this ToggleSwitch element)
        { element.IsOn = true; return element; }

        public static ToggleSwitch Off(this ToggleSwitch element)
        { element.IsOn = false; return element; }

        public static ToggleSwitch Header(this ToggleSwitch element, object Header = null)
        { element.Header = Header; return element; }

        public static ToggleSwitch AddOnToggled(this ToggleSwitch element, RoutedEventHandler handler)
        { element.Toggled += handler; return element; }
    }
}