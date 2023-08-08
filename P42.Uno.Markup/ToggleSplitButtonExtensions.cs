using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElementType = Microsoft.UI.Xaml.Controls.ToggleSplitButton;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using Windows.Foundation;

namespace P42.Uno.Markup
{
    public static class ToggleSplitButtonExtensions
    {
        #region Properties
        public static TElement IsChecked<TElement>(this TElement element, bool value = true) where TElement : ElementType
        {
            element.IsChecked = value; return element;
        }
        #endregion


        #region Events
        public static TElement AddIsCheckedChangedHandler<TElement>(this TElement element, TypedEventHandler<ToggleSplitButton, ToggleSplitButtonIsCheckedChangedEventArgs> handler) where TElement : ElementType
        { element.IsCheckedChanged += handler; return element; }

        #endregion
    }
}
