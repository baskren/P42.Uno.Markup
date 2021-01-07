﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using ElementType = Windows.UI.Xaml.Controls.Button;

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
