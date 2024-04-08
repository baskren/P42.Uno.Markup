using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Markup;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Media.Media3D;
using ElementType = Microsoft.UI.Xaml.UIElement;
using System.ComponentModel;

namespace P42.Uno.Markup
{
    public static class UIElementExtensions
    {
        #region Visibility
        public static TElement Visibility<TElement>(this TElement element, Visibility visibility) where TElement :ElementType
        { element.Visibility = visibility; return element; }

        public static TElement Visible<TElement>(this TElement element, bool isVisible = true) where TElement :ElementType
        { element.Visibility = isVisible ? Microsoft.UI.Xaml.Visibility.Visible : Microsoft.UI.Xaml.Visibility.Collapsed; return element; }

        public static TElement Collapsed<TElement>(this TElement element, bool isCollapsed = true) where TElement :ElementType
        { element.Visibility = isCollapsed ? Microsoft.UI.Xaml.Visibility.Collapsed : Microsoft.UI.Xaml.Visibility.Visible; return element; }

        [Obsolete("Use .BindVisible")]
        public static TElement BindVisibleFromBool<TElement>(this TElement element, object source, string path) where TElement : ElementType
        { element.Bind(UIElement.VisibilityProperty, source, path, convert: (bool visible) => visible ? Microsoft.UI.Xaml.Visibility.Visible : Microsoft.UI.Xaml.Visibility.Collapsed); return element; }

        public static TElement BindVisible<TElement>(this TElement element, object source, string path) where TElement : ElementType
        { element.Bind(UIElement.VisibilityProperty, source, path, converter: VisibilityConverter.Instance); return element; }

        public static TElement WBindVisible<TElement>(this TElement element, DependencyObject source, DependencyProperty property) where TElement : ElementType
        { element.WBind(UIElement.VisibilityProperty, source, property, converter: VisibilityConverter.Instance); return element; }

        public static TElement WBindVisible<TElement>(this TElement element, INotifyPropertyChanged source, string path) where TElement : ElementType
        { element.WBind(UIElement.VisibilityProperty, source, path, converter: VisibilityConverter.Instance); return element; }

        [Obsolete("Use .BindCollapsed")]
        public static TElement BindCollapsedFromBool<TElement>(this TElement element, object source, string path) where TElement : ElementType
        { element.Bind(UIElement.VisibilityProperty, source, path, convert: (bool visible) => !visible ? Microsoft.UI.Xaml.Visibility.Visible : Microsoft.UI.Xaml.Visibility.Collapsed); return element; }

        public static TElement BindCollapsed<TElement>(this TElement element, object source, string path) where TElement : ElementType
        { element.Bind(UIElement.VisibilityProperty, source, path, converter: CollapsedConverter.Instance); return element; }

        public static TElement WBindCollapsed<TElement>(this TElement element, DependencyObject source, DependencyProperty property) where TElement : ElementType
        { element.WBind(UIElement.VisibilityProperty, source, property, converter: CollapsedConverter.Instance); return element; }

        public static TElement WBindCollapsed<TElement>(this TElement element, INotifyPropertyChanged source, string path) where TElement : ElementType
        { element.WBind(UIElement.VisibilityProperty, source, path, converter: CollapsedConverter.Instance); return element; }

        public static bool IsVisible(this UIElement element)
            => element.Visibility == Microsoft.UI.Xaml.Visibility.Visible;

        public static bool IsCollapsed(this UIElement element)
            => element.Visibility == Microsoft.UI.Xaml.Visibility.Collapsed;

        #endregion


        public static TElement UseLayoutRounding<TElement>(this TElement element, bool useLayoutRounding = true) where TElement :ElementType
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

        #region Tap
        public static TElement TapEnabled<TElement>(this TElement element, bool isTapEnabled = true) where TElement :ElementType
        { element.IsTapEnabled = isTapEnabled; return element; }

        public static TElement AddTapHandler<TElement>(this TElement element, TappedEventHandler handler) where TElement : ElementType
        { element.Tapped += handler; return element; }

        #endregion

        #region Right Tap
        public static TElement RightTapEnabled<TElement>(this TElement element, bool isTapEnabled = true) where TElement :ElementType
        { element.IsRightTapEnabled = isTapEnabled; return element; }

        public static TElement AddRightTapHandler<TElement>(this TElement element, RightTappedEventHandler handler) where TElement : ElementType
        { element.RightTapped += handler; return element; }
        #endregion

        #region Holding
        public static TElement HoldingEnabled<TElement>(this TElement element, bool isTapEnabled = true) where TElement :ElementType
        { element.IsHoldingEnabled = isTapEnabled; return element; }

        public static TElement AddHoldingHandler<TElement>(this TElement element, HoldingEventHandler handler) where TElement : ElementType
        { element.Holding += handler; return element; }
        #endregion

        public static TElement HitTestVisible<TElement>(this TElement element, bool isTapEnabled = true) where TElement :ElementType
        { element.IsHitTestVisible = isTapEnabled; return element; }

        #region Double Tapped
        public static TElement DoubleTapEnabled<TElement>(this TElement element, bool isTapEnabled = true) where TElement :ElementType
        { element.IsDoubleTapEnabled = isTapEnabled; return element; }

        public static TElement AddDoubleTapHandler<TElement>(this TElement element, DoubleTappedEventHandler handler) where TElement : ElementType
        { element.DoubleTapped += handler; return element; }
        #endregion

        #endregion



        public static TElement Clip<TElement>(this TElement element, RectangleGeometry clipRectangle) where TElement :ElementType
        { element.Clip = clipRectangle; return element; }

        public static TElement CacheMode<TElement>(this TElement element, CacheMode cacheMode) where TElement :ElementType
        { element.CacheMode = cacheMode; return element; }

        public static TElement CompositeMode<TElement>(this TElement element, ElementCompositeMode compositeMode) where TElement :ElementType
        { element.CompositeMode = compositeMode; return element; }


        #region Drag Drop
        public static TElement AllowDrop<TElement>(this TElement element, bool allowDrop = true) where TElement :ElementType
        { element.AllowDrop = allowDrop; return element; }

        public static TElement CanDrag<TElement>(this TElement element, bool canDrag = true) where TElement :ElementType
        { element.CanDrag = canDrag; return element; }
        #endregion


        #region AccessKey
        public static TElement AccessKeyScope<TElement>(this TElement element, bool isAccessKeyScope = true) where TElement :ElementType
        { element.IsAccessKeyScope = isAccessKeyScope; return element; }

        public static TElement ExitDisplayModeOnAccessKeyInvoked<TElement>(this TElement element, bool exitDisplayMode = true) where TElement :ElementType
        { element.ExitDisplayModeOnAccessKeyInvoked = exitDisplayMode; return element; }

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

        public static TElement RenderTransformOrigin<TElement>(this TElement element, double x, double y) where TElement : ElementType
        {
            element.RenderTransformOrigin = new Point(x, y);
            return element;
        }

        public static TElement Transform3D<TElement>(this TElement element, Transform3D transform3D) where TElement :ElementType
        { element.Transform3D = transform3D; return element; }

        //public static TElement Transitions<TElement>(this TElement element, TransitionCollection collection) where TElement :ElementType
        //{ element.Transitions = collection; return element; }

        public static TElement TranslationTransition<TElement>(this TElement element, Vector3Transition transition) where TElement :ElementType
        { element.TranslationTransition = transition; return element; }

        public static TElement Translate<TElement>(this TElement element, Vector3 translation) where TElement :ElementType
        { element.Translation = translation; return element; }

        public static TElement Translate<TElement>(this TElement element, double x, double y) where TElement : ElementType
        {
            element.RenderTransform = new TranslateTransform
            {
                X = x,
                Y = y
            };
            return element;
        }

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


        #region Events
        public static TElement AddDoubleTappedHandler<TElement>(this TElement element, DoubleTappedEventHandler handler) where TElement : ElementType
        { element.DoubleTapped += handler; return element; }

        public static TElement AddDragEnterHandler<TElement>(this TElement element, DragEventHandler handler) where TElement : ElementType
        { element.DragEnter += handler; return element; }

        public static TElement AddDragLeaveHandler<TElement>(this TElement element, DragEventHandler handler) where TElement : ElementType
        { element.DragLeave += handler; return element; }

        public static TElement AddDragOverHandler<TElement>(this TElement element, DragEventHandler handler) where TElement : ElementType
        { element.DragOver += handler; return element; }

        public static TElement AddDropHandler<TElement>(this TElement element, DragEventHandler handler) where TElement : ElementType
        { element.Drop += handler; return element; }

        public static TElement AddGotFocusHandler<TElement>(this TElement element, RoutedEventHandler handler) where TElement : ElementType
        { element.GotFocus += handler; return element; }

        public static TElement AddKeyDownHandler<TElement>(this TElement element, KeyEventHandler handler) where TElement : ElementType
        { element.KeyDown += handler; return element; }

        public static TElement AddKeyUpHandler<TElement>(this TElement element, KeyEventHandler handler) where TElement : ElementType
        { element.KeyUp += handler; return element; }

        public static TElement AddLostFocusHandler<TElement>(this TElement element, RoutedEventHandler handler) where TElement : ElementType
        { element.LostFocus += handler; return element; }

        public static TElement AddManipulationCompletedHandler<TElement>(this TElement element, ManipulationCompletedEventHandler handler) where TElement : ElementType
        { element.ManipulationCompleted += handler; return element; }

        public static TElement AddManipulationDeltaHandler<TElement>(this TElement element, ManipulationDeltaEventHandler handler) where TElement : ElementType
        { element.ManipulationDelta += handler; return element; }

        public static TElement AddManipulationInertiaStartingHandler<TElement>(this TElement element, ManipulationInertiaStartingEventHandler handler) where TElement : ElementType
        { element.ManipulationInertiaStarting += handler; return element; }

        public static TElement AddManipulationStartedHandler<TElement>(this TElement element, ManipulationStartedEventHandler handler) where TElement : ElementType
        { element.ManipulationStarted += handler; return element; }

        public static TElement AddManipulationStartingHandler<TElement>(this TElement element, ManipulationStartingEventHandler handler) where TElement : ElementType
        { element.ManipulationStarting += handler; return element; }

        public static TElement AddPointerCanceledHandler<TElement>(this TElement element, PointerEventHandler handler) where TElement : ElementType
        { element.PointerCanceled += handler; return element; }

        public static TElement AddPointerCaptureLostHandler<TElement>(this TElement element, PointerEventHandler handler) where TElement : ElementType
        { element.PointerCaptureLost += handler; return element; }

        public static TElement AddPointerEnteredHandler<TElement>(this TElement element, PointerEventHandler handler) where TElement : ElementType
        { element.PointerEntered += handler; return element; }

        public static TElement AddPointerExitedHandler<TElement>(this TElement element, PointerEventHandler handler) where TElement : ElementType
        { element.PointerExited += handler; return element; }

        public static TElement AddPointerMovedHandler<TElement>(this TElement element, PointerEventHandler handler) where TElement : ElementType
        { element.PointerMoved += handler; return element; }

        public static TElement AddPointerPressedHandler<TElement>(this TElement element, PointerEventHandler handler) where TElement : ElementType
        { element.PointerPressed += handler; return element; }

        public static TElement AddPointerReleasedHandler<TElement>(this TElement element, PointerEventHandler handler) where TElement : ElementType
        { element.PointerReleased += handler; return element; }

        public static TElement AddPointerWheelChangedHandler<TElement>(this TElement element, PointerEventHandler handler) where TElement : ElementType
        { element.PointerWheelChanged += handler; return element; }

        public static TElement AddRightTappedHandler<TElement>(this TElement element, RightTappedEventHandler handler) where TElement : ElementType
        { element.RightTapped += handler; return element; }

        public static TElement AddTappedHandler<TElement>(this TElement element, TappedEventHandler handler) where TElement : ElementType
        { element.Tapped += handler; return element; }

        public static TElement AddDragStartingHandler<TElement>(this TElement element, TypedEventHandler<UIElement, DragStartingEventArgs> handler) where TElement : ElementType
        { element.DragStarting += handler; return element; }

        public static TElement AddDropCompletedHandler<TElement>(this TElement element, TypedEventHandler<UIElement, DropCompletedEventArgs> handler) where TElement : ElementType
        { element.DropCompleted += handler; return element; }

        public static TElement AddAccessKeyDisplayDismissedHandler<TElement>(this TElement element, TypedEventHandler<UIElement, AccessKeyDisplayDismissedEventArgs> handler) where TElement : ElementType
        { element.AccessKeyDisplayDismissed += handler; return element; }

        public static TElement AddAccessKeyDisplayRequestedHandler<TElement>(this TElement element, TypedEventHandler<UIElement, AccessKeyDisplayRequestedEventArgs> handler) where TElement : ElementType
        { element.AccessKeyDisplayRequested += handler; return element; }

        public static TElement AddDropCAccessKeyInvokedompleted<TElement>(this TElement element, TypedEventHandler<UIElement, AccessKeyInvokedEventArgs> handler) where TElement : ElementType
        { element.AccessKeyInvoked += handler; return element; }

        public static TElement AddContextCanceledHandler<TElement>(this TElement element, TypedEventHandler<UIElement, RoutedEventArgs> handler) where TElement : ElementType
        { element.ContextCanceled += handler; return element; }

        public static TElement AddContextRequestedHandler<TElement>(this TElement element, TypedEventHandler<UIElement, ContextRequestedEventArgs> handler) where TElement : ElementType
        { element.ContextRequested += handler; return element; }

        public static TElement AddGettingFocusHandler<TElement>(this TElement element, TypedEventHandler<UIElement, GettingFocusEventArgs> handler) where TElement : ElementType
        { element.GettingFocus += handler; return element; }

        public static TElement AddLosingFocusHandler<TElement>(this TElement element, TypedEventHandler<UIElement, LosingFocusEventArgs> handler) where TElement : ElementType
        { element.LosingFocus += handler; return element; }

        public static TElement AddNoFocusCandidateFoundHandler<TElement>(this TElement element, TypedEventHandler<UIElement, NoFocusCandidateFoundEventArgs> handler) where TElement : ElementType
        { element.NoFocusCandidateFound += handler; return element; }

        public static TElement AddCharacterReceivedHandler<TElement>(this TElement element, TypedEventHandler<UIElement, CharacterReceivedRoutedEventArgs> handler) where TElement : ElementType
        { element.CharacterReceived += handler; return element; }

        public static TElement AddPreviewKeyDownHandler<TElement>(this TElement element, KeyEventHandler handler) where TElement : ElementType
        { element.PreviewKeyDown += handler; return element; }

        public static TElement AddPreviewKeyUpHandler<TElement>(this TElement element, KeyEventHandler handler) where TElement : ElementType
        { element.PreviewKeyUp += handler; return element; }

        public static TElement AddProcessKeyboardAcceleratorsHandler<TElement>(this TElement element, TypedEventHandler<UIElement, ProcessKeyboardAcceleratorEventArgs> handler) where TElement : ElementType
        { element.ProcessKeyboardAccelerators += handler; return element; }

        public static TElement AddBringIntoViewRequestedHandler<TElement>(this TElement element, TypedEventHandler<UIElement, BringIntoViewRequestedEventArgs> handler) where TElement : ElementType
        { element.BringIntoViewRequested += handler; return element; }
        #endregion


        #region DataTemplate
        internal static string AsDataTemplateXaml(this Type templateType)
        {
            if (templateType == null || !typeof(FrameworkElement).IsAssignableFrom(templateType))
                throw new Exception("Cannot convert type [" + templateType + "] into DataTemplate");
            var markup = string.Empty;
            //if (dataType is null)
            markup = $"<DataTemplate \n\t xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" \n\t xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\" \n\t xmlns:local=\"using:{templateType.Namespace}\"> \n\t\t<local:{templateType.Name} /> \n</DataTemplate>";
            //if (dataType.Namespace == typeof(Type).Namespace)
            //    markup = $"<DataTemplate xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\" xmlns:tlocal=\"using:{templateType.Namespace}\" xmlns:system=\"using:System\" x:DataType=\"system:{dataType.Name}\"><tlocal:{templateType.Name} /></DataTemplate>";
            //else
            //    markup = $"<DataTemplate xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" \n\t xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\" \n\t xmlns:tlocal=\"using:{templateType.Namespace}\" \n\t xmlns:dlocal=\"using:{dataType.Namespace}\" \n\t x:DataType=\"dlocal:{dataType.Name}\"> \n\t\t<tlocal:{templateType.Name} /> \n</DataTemplate>";
            System.Diagnostics.Debug.WriteLine("BcGroupView.GenerateDatatemplate: markup: " + markup);
            //template.
            return markup;
        }

        internal static DataTemplate AsDataTemplate(this Type templateType)
        {
            try
            {
                if (templateType == null || !typeof(FrameworkElement).IsAssignableFrom(templateType))
                    throw new Exception("Cannot convert type [" + templateType + "] into DataTemplate");
                var markup = $"<Xml.DataTemplate \n\t xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" \n\t xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\" \n\t xmlns:local=\"using:{templateType.Namespace}\"> \n\t\t<local:{templateType.Name} /> \n</DataTemplate>";
                //System.Diagnostics.Trace.WriteLine($"AsDataTemplate : [{markup}]");
                var template = (DataTemplate)XamlReader.Load(markup);
                //template.
                return template;
            }
            catch (Exception e)
            {
                //System.Console.WriteLine($"EXCEPTION [{e.Message}] [{e.StackTrace}]");
                System.Diagnostics.Trace.WriteLine($"EXCEPTION [{e.Message}] [{e.StackTrace}]");
            }
            return null;
        }
        #endregion


        #region Transforms






        #endregion

    }
}
