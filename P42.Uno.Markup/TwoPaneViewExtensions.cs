using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElementType = Microsoft.UI.Xaml.Controls.TwoPaneView;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using Windows.Foundation;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Media;
using Windows.UI;
using System.Xml.Linq;


namespace P42.Uno.Markup
{
    public static class TwoPaneViewExtensions
    {
        #region Properties
        public static TElement MinTallModeHeight<TElement>(this TElement element, double value) where TElement : ElementType
        {
            element.MinTallModeHeight = value; return element;
        }

        public static TElement MinWideModeWidth<TElement>(this TElement element, double value) where TElement : ElementType
        {
            element.MinWideModeWidth = value; return element;
        }


        public static TElement Pane1<TElement>(this TElement element, UIElement value) where TElement : ElementType
        {
            element.Pane1 = value; return element;
        }

        public static TElement Pane1Length<TElement>(this TElement element, GridLength value) where TElement : ElementType
        {
            element.Pane1Length = value; return element;
        }

        public static TElement Pane2<TElement>(this TElement element, UIElement value) where TElement : ElementType
        {
            element.Pane2 = value; return element;
        }

        public static TElement Pane2Length<TElement>(this TElement element, GridLength value) where TElement : ElementType
        {
            element.Pane2Length = value; return element;
        }

        public static TElement PanePriority<TElement>(this TElement element, TwoPaneViewPriority value) where TElement : ElementType
        {
            element.PanePriority = value; return element;
        }

        public static TElement TallModeConfiguration<TElement>(this TElement element, TwoPaneViewTallModeConfiguration value) where TElement : ElementType
        {
            element.TallModeConfiguration = value; return element;
        }

        public static TElement WideModeConfiguration<TElement>(this TElement element, TwoPaneViewWideModeConfiguration value) where TElement : ElementType
        {
            element.WideModeConfiguration = value; return element;
        }


        #endregion


        #region Events
        public static TElement AddModeChangedHandler<TElement>(this TElement element, TypedEventHandler<TwoPaneView, object> handler) where TElement : ElementType
        { element.ModeChanged += handler; return element; }

        #endregion
    }
}
