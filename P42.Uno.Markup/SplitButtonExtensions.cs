using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Windows.Foundation;
using ElementType = Microsoft.UI.Xaml.Controls.SplitButton;

namespace P42.Uno.Markup;

public static class SplitButtonExtensions
{
    public static TElement CommandParameter<TElement>(this TElement element, object parameter) where TElement : ElementType
    { element.CommandParameter = parameter; return element; }

    public static TElement Command<TElement>(this TElement element, ICommand command) where TElement : ElementType
    { element.Command = command; return element; }

    public static TElement Flyout<TElement>(this TElement element, FlyoutBase flyout) where TElement : ElementType
    { element.Flyout = flyout; return element; }


    #region Events

    public static TElement AddClickHandler<TElement>(this TElement element, TypedEventHandler<SplitButton, SplitButtonClickEventArgs> handler) where TElement : ElementType
    { element.Click += handler; return element; }

    #endregion
}
