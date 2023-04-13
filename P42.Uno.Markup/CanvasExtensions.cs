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
using ElementType = Microsoft.UI.Xaml.UIElement;

namespace P42.Uno.Markup
{
    public static class CanvasExtensions
    {
        public static TElement CanvasLeft<TElement>(this TElement element, double value) where TElement : ElementType
        { Canvas.SetLeft(element, value); return element; }

        public static TElement CanvasTop<TElement>(this TElement element, double value) where TElement : ElementType
        { Canvas.SetTop(element, value); return element; }

        public static TElement CanvasZ<TElement>(this TElement element, int value) where TElement : ElementType
        { Canvas.SetZIndex(element, value); return element; }



    }
}
