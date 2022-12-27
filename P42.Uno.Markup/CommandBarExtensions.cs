using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using ElementType = Microsoft.UI.Xaml.Controls.CommandBar;


namespace P42.Uno.Markup
{
    public static class CommandBarExtensions
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

        public static TElement PrimaryCommands<TElement>(this TElement element, IObservableVector<ICommandBarElement> value) where TElement : ElementType
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

        public static TElement SecondaryCommands<TElement>(this TElement element, IObservableVector<ICommandBarElement> value) where TElement : ElementType
        {
            element.SecondaryCommands.Clear();
            return element.AddSecondaryCommands(value);
        }

        public static TElement CommandBarOverflowPresenterStyle<TElement>(this TElement element, Style value) where TElement : ElementType
        { element.CommandBarOverflowPresenterStyle = value; return element; }

        public static TElement OverflowButtonVisibility<TElement>(this TElement element, CommandBarOverflowButtonVisibility value) where TElement : ElementType
        { element.OverflowButtonVisibility = value; return element; }

        public static TElement DynamicOverflowEnabled<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsDynamicOverflowEnabled = value; return element; }

        public static TElement DefaultLabelPosition<TElement>(this TElement element, CommandBarDefaultLabelPosition value) where TElement : ElementType
        { element.DefaultLabelPosition = value; return element; }

        #region Events
        public static TElement AddDynamicOverflowItemsChangingHandler<TElement>(this TElement element, TypedEventHandler<CommandBar, DynamicOverflowItemsChangingEventArgs> handler) where TElement : ElementType
        { element.DynamicOverflowItemsChanging += handler; return element; }
        #endregion
    }
}
