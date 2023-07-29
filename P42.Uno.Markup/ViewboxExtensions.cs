using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using ElementType = Microsoft.UI.Xaml.Controls.Viewbox;

namespace P42.Uno.Markup
{
    public static class ViewboxExtensions
    {
        #region Properties

        public static Viewbox Child(this Viewbox element, UIElement child) 
        { element.Child = child; return element; }

        public static Viewbox Stretch(this Viewbox element, Stretch value)
        { element.Stretch = value; return element; }

        public static Viewbox StretchDirection(this Viewbox element, StretchDirection value) 
        { element.StretchDirection = value; return element; }

        #endregion



    }
}
