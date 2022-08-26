using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Text;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;

namespace P42.Uno.Markup
{
    public static class ProgressRingExtensions
    {
        public static ProgressRing Active(this ProgressRing element, bool value = true) 
        { element.IsActive = value; return element; }
    }
}