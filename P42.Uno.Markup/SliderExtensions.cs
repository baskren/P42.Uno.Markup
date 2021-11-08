using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using ElementType = Windows.UI.Xaml.Controls.Slider;

namespace P42.Uno.Markup
{
    public static class SliderExtensions
    {
        #region TickPlacement
        public static TElement TickPlacement<TElement>(this TElement slider, TickPlacement placement) where TElement : ElementType
        { slider.TickPlacement = placement; return slider; }

        public static TElement TicksNone<TElement>(this TElement slider) where TElement : ElementType
        { slider.TickPlacement = Windows.UI.Xaml.Controls.Primitives.TickPlacement.None; return slider; }

        public static TElement TicksTopLeft<TElement>(this TElement slider) where TElement : ElementType
        { slider.TickPlacement = Windows.UI.Xaml.Controls.Primitives.TickPlacement.TopLeft; return slider; }

        public static TElement TicksBottomRight<TElement>(this TElement slider) where TElement : ElementType
        { slider.TickPlacement = Windows.UI.Xaml.Controls.Primitives.TickPlacement.BottomRight; return slider; }

        public static TElement TicksOutside<TElement>(this TElement slider) where TElement : ElementType
        { slider.TickPlacement = Windows.UI.Xaml.Controls.Primitives.TickPlacement.Outside; return slider; }

        public static TElement TicksInline<TElement>(this TElement slider) where TElement : ElementType
        { slider.TickPlacement = Windows.UI.Xaml.Controls.Primitives.TickPlacement.Inline; return slider; }
        #endregion

        public static TElement TickFrequency<TElement>(this TElement slider, double freq) where TElement : ElementType
        { slider.TickFrequency = freq; return slider; }

        public static TElement StepFrequency<TElement>(this TElement slider, double freq) where TElement : ElementType
        { slider.StepFrequency = freq; return slider; }

        public static TElement Orientation<TElement>(this TElement slider, Orientation orientation) where TElement : ElementType
        { slider.Orientation = orientation; return slider; }

        public static TElement ThumbToolTipEnabled<TElement>(this TElement slider, bool enabled = true) where TElement : ElementType
        { slider.IsThumbToolTipEnabled = enabled; return slider; }

        public static TElement DirectionReversed<TElement>(this TElement slider, bool enabled = true) where TElement : ElementType
        { slider.IsDirectionReversed = enabled; return slider; }

        public static TElement IntermediateValue<TElement>(this TElement slider, double freq) where TElement : ElementType
        { slider.IntermediateValue = freq; return slider; }

        public static TElement Header<TElement>(this TElement slider, object header) where TElement : ElementType
        { slider.Header = header; return slider; }

        public static TElement MinMaxStep<TElement>(this TElement element, double min, double max, double step) where TElement : ElementType
        { element.Minimum = min; element.Maximum = max; element.StepFrequency = step; return element; }

        public static TElement MinMaxTick<TElement>(this TElement element, double min, double max, double tick) where TElement : ElementType
        { element.Minimum = min; element.Maximum = max; element.TickFrequency = tick; return element; }

        public static TElement MinMaxStepTick<TElement>(this TElement element, double min, double max, double step, double tick) where TElement : ElementType
        { element.Minimum = min; element.Maximum = max; element.StepFrequency = step; element.TickFrequency = tick; return element; }


    }
}