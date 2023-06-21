using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml.Controls;
using ElementType = Microsoft.UI.Xaml.Controls.CommandBarFlyout;

namespace P42.Uno.Markup
{
    public static class CommandBarFlyoutExtensions
    {

        public static TElement AddPrimaryCommands<TElement>(this TElement element, IObservableVector<ICommandBarElement> value) where TElement : ElementType
        {
            if (value != null)
            {
                foreach (var command in value)
                    element.PrimaryCommands.Add(command);
            }
            return element;
        }

        public static TElement AddPrimaryCommands<TElement>(this TElement element, params ICommandBarElement[] value) where TElement : ElementType
        {
            if (value != null)
            {
                foreach (var command in value)
                    element.PrimaryCommands.Add(command);
            }
            return element;
        }

        public static TElement PrimaryCommands<TElement>(this TElement element, IObservableVector<ICommandBarElement> value) where TElement : ElementType
        {
            element.PrimaryCommands.Clear();
            return element.AddPrimaryCommands(value);
        }

        public static TElement PrimaryCommands<TElement>(this TElement element, params ICommandBarElement[] value) where TElement : ElementType
        {
            element.PrimaryCommands.Clear();
            return element.AddPrimaryCommands(value);
        }

        public static TElement AddSecondaryCommands<TElement>(this TElement element, IObservableVector<ICommandBarElement> value) where TElement : ElementType
        {
            if (value != null)
            {
                foreach (var command in value)
                    element.SecondaryCommands.Add(command);
            }
            return element;
        }

        public static TElement AddSecondaryCommands<TElement>(this TElement element, params ICommandBarElement[] value) where TElement : ElementType
        {
            if (value != null)
            {
                foreach (var command in value)
                    element.SecondaryCommands.Add(command);
            }
            return element;
        }

        public static TElement SecondaryCommands<TElement>(this TElement element, IObservableVector<ICommandBarElement> value) where TElement : ElementType
        {
            element.SecondaryCommands.Clear();
            return element.AddSecondaryCommands(value);
        }

        public static TElement SecondaryCommands<TElement>(this TElement element, params ICommandBarElement[] value) where TElement : ElementType
        {
            element.SecondaryCommands.Clear();
            return element.AddSecondaryCommands(value);
        }
    }
}
