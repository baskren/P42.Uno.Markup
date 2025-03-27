using System;
using ElementType = Microsoft.UI.Xaml.Controls.TimePicker;
using Microsoft.UI.Xaml.Controls;
using Windows.Foundation;

namespace P42.Uno.Markup;

public static class TimePickerExtensions
{

    #region Properties
    public static TElement ClockIdentifier<TElement>(this TElement element, string value) where TElement : ElementType
    {
        element.ClockIdentifier = value; return element;
    }

    public static TElement Header<TElement>(this TElement element, object value) where TElement : ElementType
    {
        element.Header = value; return element;
    }

    public static TElement LightDismissOverlayMode<TElement>(this TElement element, LightDismissOverlayMode value) where TElement : ElementType
    {
        element.LightDismissOverlayMode = value; return element;
    }

    public static TElement MinuteIncrement<TElement>(this TElement element, int value) where TElement : ElementType
    {
        element.MinuteIncrement = value; return element;
    }

    public static TElement SelectedTime<TElement>(this TElement element, TimeSpan value) where TElement : ElementType
    {
        element.SelectedTime = value; return element;
    }

    public static TElement Time<TElement>(this TElement element, TimeSpan value) where TElement : ElementType
    {
        element.Time = value; return element;
    }
    #endregion


    #region Events
    public static TElement AddSelectedTimeChangedHandler<TElement>(this TElement element, TypedEventHandler<TimePicker, TimePickerSelectedValueChangedEventArgs> handler) where TElement : ElementType
    { element.SelectedTimeChanged += handler; return element; }

    public static TElement AddTimeChangedHandler<TElement>(this TElement element, EventHandler<TimePickerValueChangedEventArgs> handler) where TElement : ElementType
    { element.TimeChanged += handler; return element; }
    #endregion
}
