using System.Windows.Input;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using ElementType = Microsoft.UI.Xaml.Controls.Button;

namespace P42.Uno.Markup
{
    public static class ButtonExtensions
    {
        public static TElement Flyout<TElement>(this TElement element, FlyoutBase flyout) where TElement : ElementType
        { element.Flyout = flyout; return element; }

        public static TElement CommandParameter<TElement>(this TElement element, object parameter) where TElement : ElementType
        { element.CommandParameter = parameter; return element; }

        public static TElement Command<TElement>(this TElement element, ICommand command) where TElement : ElementType
        { element.Command = command; return element; }

        public static TElement ClickMode<TElement>(this TElement element, ClickMode mode) where TElement : ElementType
        { element.ClickMode = mode; return element; }

    }
}
