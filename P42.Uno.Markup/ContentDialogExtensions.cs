using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ElementType = Windows.UI.Xaml.Controls.ContentDialog;

namespace P42.Uno.Markup
{
    public static class ContentDialogExtensions
    {
        public static TElement TitleTemplate<TElement>(this TElement element, DataTemplate value) where TElement : ElementType
        { element.TitleTemplate = value; return element; }

        public static TElement Title<TElement>(this TElement element, object value) where TElement : ElementType
        { element.Title = value; return element; }

        public static TElement SecondaryButtonText<TElement>(this TElement element, string value) where TElement : ElementType
        { element.SecondaryButtonText = value; return element; }

        public static TElement SecondaryButtonCommandParameter<TElement>(this TElement element, object value) where TElement : ElementType
        { element.SecondaryButtonCommandParameter = value; return element; }

        public static TElement SecondaryButtonCommand<TElement>(this TElement element, ICommand value) where TElement : ElementType
        { element.SecondaryButtonCommand = value; return element; }

        public static TElement PrimaryButtonText<TElement>(this TElement element, string value) where TElement : ElementType
        { element.PrimaryButtonText = value; return element; }

        public static TElement PrimaryButtonCommandParameter<TElement>(this TElement element, object value) where TElement : ElementType
        { element.PrimaryButtonCommandParameter = value; return element; }

        public static TElement PrimaryButtonCommand<TElement>(this TElement element, ICommand value) where TElement : ElementType
        { element.PrimaryButtonCommand = value; return element; }

        public static TElement IsSecondaryButtonEnabled<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsSecondaryButtonEnabled = value; return element; }

        public static TElement IsPrimaryButtonEnabled<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsPrimaryButtonEnabled = value; return element; }

        public static TElement FullSizeDesired<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.FullSizeDesired = value; return element; }

        public static TElement SecondaryButtonStyle<TElement>(this TElement element, Style value) where TElement : ElementType
        { element.SecondaryButtonStyle = value; return element; }

        public static TElement PrimaryButtonStyle<TElement>(this TElement element, Style value) where TElement : ElementType
        { element.PrimaryButtonStyle = value; return element; }

        public static TElement DefaultButton<TElement>(this TElement element, ContentDialogButton value) where TElement : ElementType
        { element.DefaultButton = value; return element; }

        public static TElement CloseButtonText<TElement>(this TElement element, string value) where TElement : ElementType
        { element.CloseButtonText = value; return element; }

        public static TElement CloseButtonStyle<TElement>(this TElement element, Style value) where TElement : ElementType
        { element.CloseButtonStyle = value; return element; }

        public static TElement CloseButtonCommandParameter<TElement>(this TElement element, object value) where TElement : ElementType
        { element.CloseButtonCommandParameter = value; return element; }

        public static TElement CloseButtonCommand<TElement>(this TElement element, ICommand value) where TElement : ElementType
        { element.CloseButtonCommand = value; return element; }


    }
}
