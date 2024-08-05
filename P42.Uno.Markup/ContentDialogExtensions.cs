using System;
using System.Windows.Input;
using Windows.Foundation;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using ElementType = Microsoft.UI.Xaml.Controls.ContentDialog;

namespace P42.Uno.Markup
{
    public static class ContentDialogExtensions
    {
        public static TElement TitleTemplate<TElement>(this TElement element, DataTemplate value) where TElement : ElementType
        { element.TitleTemplate = value; return element; }

        public static TElement TitleTemplate<TElement>(this TElement element, Type type) where TElement : ElementType
        { element.TitleTemplate = type.AsDataTemplate(); return element; }

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

        public static TElement SecondaryButtonEnabled<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsSecondaryButtonEnabled = value; return element; }

        public static TElement PrimaryButtonEnabled<TElement>(this TElement element, bool value = true) where TElement : ElementType
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


        #region Events
        public static TElement AddClosedHandler<TElement>(this TElement element, TypedEventHandler<ContentDialog, ContentDialogClosedEventArgs> handler) where TElement : ElementType
        { element.Closed += handler; return element; }

        public static TElement AddClosingHandler<TElement>(this TElement element, TypedEventHandler<ContentDialog, ContentDialogClosingEventArgs> handler) where TElement : ElementType
        { element.Closing += handler; return element; }

        public static TElement AddOpenedHandler<TElement>(this TElement element, TypedEventHandler<ContentDialog, ContentDialogOpenedEventArgs> handler) where TElement : ElementType
        { element.Opened += handler; return element; }

        public static TElement AddPrimaryButtonClickHandler<TElement>(this TElement element, TypedEventHandler<ContentDialog, ContentDialogButtonClickEventArgs> handler) where TElement : ElementType
        { element.PrimaryButtonClick += handler; return element; }

        public static TElement AddSecondaryButtonClickHandler<TElement>(this TElement element, TypedEventHandler<ContentDialog, ContentDialogButtonClickEventArgs> handler) where TElement : ElementType
        { element.SecondaryButtonClick += handler; return element; }

        public static TElement AddCloseButtonClickHandler<TElement>(this TElement element, TypedEventHandler<ContentDialog, ContentDialogButtonClickEventArgs> handler) where TElement : ElementType
        { element.CloseButtonClick += handler; return element; }

        #endregion
    }
}
