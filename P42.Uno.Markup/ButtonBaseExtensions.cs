﻿using System.Windows.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using ElementType = Microsoft.UI.Xaml.Controls.Primitives.ButtonBase;

namespace P42.Uno.Markup
{
    public static class ButtonBaseExtensions
    {
        public static TElement CommandParameter<TElement>(this TElement element, object parameter) where TElement : ElementType
        { element.CommandParameter = parameter; return element; }

        public static TElement Command<TElement>(this TElement element, ICommand command) where TElement : ElementType
        { element.Command = command; return element; }

        public static TElement ClickMode<TElement>(this TElement element, ClickMode mode) where TElement : ElementType
        { element.ClickMode = mode; return element; }

        public static TElement AddClickHandler<TElement>(this TElement element, RoutedEventHandler handler) where TElement : ElementType
        { element.Click += handler; return element; }
    }
}
