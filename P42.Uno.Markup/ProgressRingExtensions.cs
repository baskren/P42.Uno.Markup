using Microsoft.UI.Xaml.Controls;

namespace P42.Uno.Markup
{
    public static class ProgressRingExtensions
    {
        public static ProgressRing Active(this ProgressRing element, bool value = true) 
        { element.IsActive = value; return element; }
    }
}