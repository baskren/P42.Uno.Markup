using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Foundation;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Windows.Media.Capture;
using Microsoft.UI.Xaml.Media;
using ElementType = Microsoft.UI.Xaml.Controls.CalendarViewDayItem;

namespace P42.Uno.Markup
{
    public static class CalendarViewDayItemExtensions
    {
        public static TElement IsBlackout<TElement>(this TElement element, bool value) where TElement : ElementType
        { element.IsBlackout = value; return element; }


    }
}
