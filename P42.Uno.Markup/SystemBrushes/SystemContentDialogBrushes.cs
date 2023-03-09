using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Microsoft.UI.Xaml.Media;

namespace P42.Uno.Markup
{
    // Full list of system brushes found here: https://github.com/MicrosoftDocs/windows-uwp/issues/2072
    public static class SystemContentDialogBrushes
    {
        public static Brush Background => ColorExtensions.AppBrush("ContentDialogBackground");
        public static Brush Border => ColorExtensions.AppBrush("ContentDialogBorderBrush");
        public static Brush Foreground => ColorExtensions.AppBrush("ContentDialogForeground");
        public static Brush Dimming => ColorExtensions.AppBrush("ContentDialogDimmingThemeBrush");
    }
}