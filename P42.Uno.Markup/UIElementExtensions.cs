using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Media3D;
using ElementType = Windows.UI.Xaml.UIElement;

namespace P42.Uno.Markup
{
    public static class UIElementExtensions
    {
        #region Visibility
        public static TElement IsVisible<TElement>(this TElement element, bool isVisible = true) where TElement :ElementType
        { element.Visibility = isVisible ? Windows.UI.Xaml.Visibility.Visible : Windows.UI.Xaml.Visibility.Collapsed; return element; }

        public static TElement Visibility<TElement>(this TElement element, Visibility visibility) where TElement :ElementType
        { element.Visibility = visibility; return element; }

        public static TElement Visible<TElement>(this TElement element) where TElement :ElementType
        { element.Visibility = Windows.UI.Xaml.Visibility.Visible; return element; }

        public static TElement Collapsed<TElement>(this TElement element) where TElement :ElementType
        { element.Visibility = Windows.UI.Xaml.Visibility.Collapsed; return element; }
        #endregion


        public static TElement UseLayoutRounding<TElement>(this TElement element, bool useLayoutRounding) where TElement :ElementType
        { element.UseLayoutRounding = useLayoutRounding; return element; }

        public static TElement Projection<TElement>(this TElement element, Projection projection) where TElement :ElementType
        { element.Projection = projection; return element; }


        #region Opacity
        public static TElement Opacity<TElement>(this TElement element, double opacity) where TElement :ElementType
        { element.Opacity = opacity; return element; }

        public static TElement OpacityTransition<TElement>(this TElement element, ScalarTransition transition) where TElement :ElementType
        { element.OpacityTransition = transition; return element; }

        #endregion


        #region Gestures
        public static TElement ManipulationMode<TElement>(this TElement element, ManipulationModes manipulationMode) where TElement :ElementType
        { element.ManipulationMode = manipulationMode; return element; }

        public static TElement IsTapEnabled<TElement>(this TElement element, bool isTapEnabled) where TElement :ElementType
        { element.IsTapEnabled = isTapEnabled; return element; }

        public static TElement TapEnabled<TElement>(this TElement element) where TElement :ElementType
        { element.IsTapEnabled = true; return element; }

        public static TElement IsRightTapEnabled<TElement>(this TElement element, bool isTapEnabled) where TElement :ElementType
        { element.IsRightTapEnabled = isTapEnabled; return element; }

        public static TElement RightTapEnabled<TElement>(this TElement element) where TElement :ElementType
        { element.IsRightTapEnabled = true; return element; }

        public static TElement IsHoldingEnabled<TElement>(this TElement element, bool isTapEnabled) where TElement :ElementType
        { element.IsHoldingEnabled = isTapEnabled; return element; }

        public static TElement HoldingEnabled<TElement>(this TElement element) where TElement :ElementType
        { element.IsHoldingEnabled = true; return element; }

        public static TElement IsHitTestVisible<TElement>(this TElement element, bool isTapEnabled) where TElement :ElementType
        { element.IsHitTestVisible = isTapEnabled; return element; }

        public static TElement HitTestVisible<TElement>(this TElement element) where TElement :ElementType
        { element.IsHitTestVisible = true; return element; }

        public static TElement IsDoubleTapEnabled<TElement>(this TElement element, bool isTapEnabled) where TElement :ElementType
        { element.IsDoubleTapEnabled = isTapEnabled; return element; }

        public static TElement DoubleTapEnabled<TElement>(this TElement element) where TElement :ElementType
        { element.IsDoubleTapEnabled = true; return element; }
        #endregion


        public static TElement Clip<TElement>(this TElement element, RectangleGeometry clipRectangle) where TElement :ElementType
        { element.Clip = clipRectangle; return element; }

        public static TElement CacheMode<TElement>(this TElement element, CacheMode cacheMode) where TElement :ElementType
        { element.CacheMode = cacheMode; return element; }

        public static TElement CompositeMode<TElement>(this TElement element, ElementCompositeMode compositeMode) where TElement :ElementType
        { element.CompositeMode = compositeMode; return element; }


        #region Drag Drop
        public static TElement AllowDrop<TElement>(this TElement element, bool allowDrop) where TElement :ElementType
        { element.AllowDrop = allowDrop; return element; }

        public static TElement AllowDrop<TElement>(this TElement element) where TElement :ElementType
        { element.AllowDrop = true; return element; }

        public static TElement CanDrag<TElement>(this TElement element, bool canDrag) where TElement :ElementType
        { element.CanDrag = canDrag; return element; }

        public static TElement CanDrag<TElement>(this TElement element) where TElement :ElementType
        { element.CanDrag = true; return element; }
        #endregion


        #region AccessKey
        public static TElement IsAccessKeyScope<TElement>(this TElement element, bool isAccessKeyScope) where TElement :ElementType
        { element.IsAccessKeyScope = isAccessKeyScope; return element; }

        public static TElement IsAccessKeyScope<TElement>(this TElement element) where TElement :ElementType
        { element.IsAccessKeyScope = true; return element; }

        public static TElement ExitDisplayModeOnAccessKeyInvoked<TElement>(this TElement element, bool exitDisplayMode) where TElement :ElementType
        { element.ExitDisplayModeOnAccessKeyInvoked = exitDisplayMode; return element; }

        public static TElement ExitDisplayModeOnAccessKeyInvoked<TElement>(this TElement element) where TElement :ElementType
        { element.ExitDisplayModeOnAccessKeyInvoked = true; return element; }

        public static TElement AccessKeyScopeOwner<TElement>(this TElement element, DependencyObject owner) where TElement :ElementType
        { element.AccessKeyScopeOwner = owner; return element; }

        public static TElement AccessKey<TElement>(this TElement element, string key) where TElement :ElementType
        { element.AccessKey = key; return element; }
        #endregion


        public static TElement ContextFlyout<TElement>(this TElement element, FlyoutBase flyout) where TElement :ElementType
        { element.ContextFlyout = flyout; return element; }

        public static TElement HighContrastAdjustment<TElement>(this TElement element, ElementHighContrastAdjustment adjustment) where TElement :ElementType
        { element.HighContrastAdjustment = adjustment; return element; }


        #region Focus Navigation
        public static TElement XYFocusLeftNavigationStrategy<TElement>(this TElement element, XYFocusNavigationStrategy strategy) where TElement :ElementType
        { element.XYFocusLeftNavigationStrategy = strategy; return element; }

        public static TElement XYFocusUpNavigationStrategy<TElement>(this TElement element, XYFocusNavigationStrategy strategy) where TElement :ElementType
        { element.XYFocusUpNavigationStrategy = strategy; return element; }

        public static TElement XYFocusRightNavigationStrategy<TElement>(this TElement element, XYFocusNavigationStrategy strategy) where TElement :ElementType
        { element.XYFocusRightNavigationStrategy = strategy; return element; }

        public static TElement XYFocusKeyboardNavigation<TElement>(this TElement element, XYFocusKeyboardNavigationMode strategy) where TElement :ElementType
        { element.XYFocusKeyboardNavigation = strategy; return element; }

        public static TElement XYFocusDownNavigationStrategy<TElement>(this TElement element, XYFocusNavigationStrategy strategy) where TElement :ElementType
        { element.XYFocusDownNavigationStrategy = strategy; return element; }

        public static TElement TabFocusNavigation<TElement>(this TElement element, KeyboardNavigationMode mode) where TElement :ElementType
        { element.TabFocusNavigation = mode; return element; }
        #endregion


        #region KeyTip
        public static TElement KeyTipHorizontalOffset<TElement>(this TElement element, double offset) where TElement :ElementType
        { element.KeyTipHorizontalOffset = offset; return element; }

        public static TElement KeyTipVerticalOffset<TElement>(this TElement element, double offset) where TElement :ElementType
        { element.KeyTipVerticalOffset = offset; return element; }

        public static TElement KeyTipPlacementMode<TElement>(this TElement element, KeyTipPlacementMode mode) where TElement :ElementType
        { element.KeyTipPlacementMode = mode; return element; }

        public static TElement KeyTipTarget<TElement>(this TElement element, DependencyObject target) where TElement :ElementType
        { element.KeyTipTarget = target; return element; }

        #endregion


        #region Keyboard Accelerators
        public static TElement KeyboardAcceleratorPlacementTarget<TElement>(this TElement element, DependencyObject target) where TElement :ElementType
        { element.KeyboardAcceleratorPlacementTarget = target; return element; }

        public static TElement KeyboardAcceleratorPlacementMode<TElement>(this TElement element, KeyboardAcceleratorPlacementMode mode) where TElement :ElementType
        { element.KeyboardAcceleratorPlacementMode = mode; return element; }

        #endregion


        #region Transforms / Transitions
        public static TElement RenderTransform<TElement>(this TElement element, Transform transform) where TElement :ElementType
        { element.RenderTransform = transform; return element; }

        public static TElement RenderTransformOrigin<TElement>(this TElement element, Point point) where TElement :ElementType
        { element.RenderTransformOrigin = point; return element; }

        public static TElement Transform3D<TElement>(this TElement element, Transform3D transform3D) where TElement :ElementType
        { element.Transform3D = transform3D; return element; }

        //public static TElement Transitions<TElement>(this TElement element, TransitionCollection collection) where TElement :ElementType
        //{ element.Transitions = collection; return element; }

        public static TElement TranslationTransition<TElement>(this TElement element, Vector3Transition transition) where TElement :ElementType
        { element.TranslationTransition = transition; return element; }

        public static TElement Translation<TElement>(this TElement element, Vector3 translation) where TElement :ElementType
        { element.Translation = translation; return element; }

        public static TElement ScaleTransition<TElement>(this TElement element, Vector3Transition transition) where TElement :ElementType
        { element.ScaleTransition = transition; return element; }

        public static TElement Scale<TElement>(this TElement element, Vector3 scale) where TElement :ElementType
        { element.Scale = scale; return element; }

        public static TElement RotationTransition<TElement>(this TElement element, ScalarTransition transition) where TElement :ElementType
        { element.RotationTransition = transition; return element; }

        public static TElement RotationAxis<TElement>(this TElement element, Vector3 axis) where TElement :ElementType
        { element.RotationAxis = axis; return element; }

        public static TElement Rotation<TElement>(this TElement element, float rotation) where TElement :ElementType
        { element.Rotation = rotation; return element; }

        public static TElement CenterPoint<TElement>(this TElement element, Vector3 point) where TElement :ElementType
        { element.CenterPoint = point; return element; }
        #endregion


        public static TElement CanBeScrollAnchor<TElement>(this TElement element, bool canBe) where TElement :ElementType
        { element.CanBeScrollAnchor = canBe; return element; }

        public static TElement CanBeScrollAnchor<TElement>(this TElement element) where TElement :ElementType
        { element.CanBeScrollAnchor = true; return element; }

    }
}
