using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace P42.Uno.Markup
{
    public static class ProgressRingExtensions
    {
        public static ProgressRing Active(this ProgressRing element, bool value = true) 
        { element.IsActive = value; return element; }
    }
}