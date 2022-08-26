using System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;

namespace P42.Uno.Markup
{
    public static class ScrollViewerExtensions
    {
        public static ScrollViewer VeritcalRailEnabled(this ScrollViewer element, bool value = true)    
        { element.IsVerticalRailEnabled = value; return element; }

        public static ScrollViewer ScrollInertiaEnabled(this ScrollViewer element, bool value = true)
        { element.IsScrollInertiaEnabled = value; return element; }

        public static ScrollViewer HorizontalScrollChainingEnabled(this ScrollViewer element, bool value = true)
        { element.IsHorizontalScrollChainingEnabled = value; return element; }

        public static ScrollViewer HorizontalRailEnabled(this ScrollViewer element, bool value = true)
        { element.IsHorizontalRailEnabled = value; return element; }

        public static ScrollViewer DeferredScrollingEnabled(this ScrollViewer element, bool value = true)
        { element.IsDeferredScrollingEnabled = value; return element; }

        public static ScrollViewer HorizontalSnapPointsType(this ScrollViewer element, SnapPointsType value)
        { element.HorizontalSnapPointsType = value; return element; }

        public static ScrollViewer HorizontalSnapPointsAlignment(this ScrollViewer element, SnapPointsAlignment value)
        { element.HorizontalSnapPointsAlignment = value; return element; }

        public static ScrollViewer HorizontalScrollMode(this ScrollViewer element, ScrollMode value)
        { element.HorizontalScrollMode = value; return element; }

        public static ScrollViewer HorizontalScrollBarVisibility(this ScrollViewer element, ScrollBarVisibility value)
        { element.HorizontalScrollBarVisibility = value; return element; }

        public static ScrollViewer MinZoomFactor(this ScrollViewer element, float value)
        { element.MinZoomFactor = value; return element; }

        public static ScrollViewer MaxZoomFactor(this ScrollViewer element, float value)
        { element.MaxZoomFactor = value; return element; }

        public static ScrollViewer ZoomInertiaEnabled(this ScrollViewer element, bool value = true)
        { element.IsZoomInertiaEnabled = value; return element; }

        public static ScrollViewer ZoomChainingEnabled(this ScrollViewer element, bool value = true)
        { element.IsZoomChainingEnabled = value; return element; }

        public static ScrollViewer VerticalScrollChainingEnabled(this ScrollViewer element, bool value = true)
        { element.IsVerticalScrollChainingEnabled = value; return element; }

        public static ScrollViewer BringIntoViewOnFocusChange(this ScrollViewer element, bool value = true)
        { element.BringIntoViewOnFocusChange = value; return element; }

        public static ScrollViewer ZoomSnapPointsType(this ScrollViewer element, SnapPointsType value)
        { element.ZoomSnapPointsType = value; return element; }

        public static ScrollViewer ZoomMode(this ScrollViewer element, ZoomMode value)
        { element.ZoomMode = value; return element; }

        public static ScrollViewer VerticalSnapPointsType(this ScrollViewer element, SnapPointsType value)
        { element.VerticalSnapPointsType = value; return element; }

        public static ScrollViewer VerticalSnapPointsAlignment(this ScrollViewer element, SnapPointsAlignment value)
        { element.VerticalSnapPointsAlignment = value; return element; }

        public static ScrollViewer VerticalScrollMode(this ScrollViewer element, ScrollMode value)
        { element.VerticalScrollMode = value; return element; }

        public static ScrollViewer VerticalScrollBarVisibility(this ScrollViewer element, ScrollBarVisibility value)
        { element.VerticalScrollBarVisibility = value; return element; }



        public static ScrollViewer TopLeftHeader(this ScrollViewer element, UIElement value = null)
        { element.TopLeftHeader = value; return element; }

        public static ScrollViewer TopHeader(this ScrollViewer element, UIElement value = null)
        { element.TopHeader = value; return element; }

        public static ScrollViewer LeftHeader(this ScrollViewer element, UIElement value = null)
        { element.LeftHeader = value; return element; }

        public static ScrollViewer VerticalAnchorRatio(this ScrollViewer element, double value)
        { element.VerticalAnchorRatio = value; return element; }

        public static ScrollViewer ReduceViewportForCoreInputViewOcclusions(this ScrollViewer element, bool value = true)
        { element.ReduceViewportForCoreInputViewOcclusions = value; return element; }

        public static ScrollViewer HorizontalAnchorRatio(this ScrollViewer element, double value)
        { element.HorizontalAnchorRatio = value; return element; }

        public static ScrollViewer CanContentRenderOutsideBounds(this ScrollViewer element, bool value = true)
        { element.CanContentRenderOutsideBounds = value; return element; }

    }
}