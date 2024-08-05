using System;
using Microsoft.UI.Xaml.Controls;
using Windows.Foundation;
//using ElementType = Microsoft.UI.Xaml.Controls.TimePickerFlyout;

namespace P42.Uno.Markup;
public static class TimePickerFlyoutExtensions
{
    public static TimePickerFlyout ClockIdentifier(this TimePickerFlyout flyout, string value)
    { flyout.ClockIdentifier = value; return flyout; }

    public static TimePickerFlyout MinuteIncrement(this TimePickerFlyout flyout, int value)
    { flyout.MinuteIncrement = value; return flyout; }

    public static TimePickerFlyout Time(this TimePickerFlyout flyout, TimeSpan value)
    { flyout.Time = value; return flyout; }


    #region Events
    public static TimePickerFlyout AddTimePickedHandler(this TimePickerFlyout flyout, TypedEventHandler<TimePickerFlyout, TimePickedEventArgs> value)
    { flyout.TimePicked += value; return flyout; }
    #endregion
}
