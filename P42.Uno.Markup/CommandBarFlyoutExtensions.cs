using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Collections;
using Windows.UI.Xaml.Controls;
using ElementType = Windows.UI.Xaml.Controls.CommandBarFlyout;

namespace P42.Uno.Markup
{
    public static class CommandBarFlyoutExtensions
    {
        public static TElement AddPrimaryCommands<TElement>(this TElement element, IObservableVector<ICommandBarElement> value) where TElement : ElementType
        {
            foreach (var command in value)
                element.PrimaryCommands.Add(command);
            return element;
        }

        public static TElement AddSecondaryCommands<TElement>(this TElement element, IObservableVector<ICommandBarElement> value) where TElement : ElementType
        {
            foreach (var command in value)
                element.SecondaryCommands.Add(command);
            return element;
        }


    }
}
