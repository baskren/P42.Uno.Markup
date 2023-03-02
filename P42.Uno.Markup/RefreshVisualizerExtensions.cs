using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Animation;
using Windows.Foundation;
using ElementType = Microsoft.UI.Xaml.Controls.RefreshVisualizer;

namespace P42.Uno.Markup
{
    public static class RefreshVisualizerExtensions
    {
        #region Properties
        public static TElement Content<TElement>(this TElement element, UIElement content) where TElement : ElementType
        { element.Content = content; return element; }

        public static TElement Orientation<TElement>(this TElement element, RefreshVisualizerOrientation orientation) where TElement : ElementType
        { element.Orientation = orientation; return element; }
        #endregion


        #region Events
        public static TElement AddRefreshStateChangedHandler<TElement>(this TElement element, TypedEventHandler<RefreshVisualizer, RefreshStateChangedEventArgs> handler) where TElement : ElementType
        { element.RefreshStateChanged += handler; return element; }
        #endregion

    }
}