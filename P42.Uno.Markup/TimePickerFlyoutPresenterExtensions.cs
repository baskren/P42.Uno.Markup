using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;

namespace P42.Uno.Markup;
public static class TimePickerFlyoutPresenterExtensions
{
    public static TimePickerFlyoutPresenter IsDefaultShadowEnabled(this TimePickerFlyoutPresenter presenter, bool value = true)
    { presenter.IsDefaultShadowEnabled = value; return presenter; }
}
