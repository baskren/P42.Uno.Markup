using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Media;
using ElementType = Windows.UI.Xaml.FrameworkElement;

namespace P42.Uno.Markup
{
    public static class FrameworkElementExtensions
    {
		public static TElement Name<TElement>(this TElement element, string name) where TElement :ElementType
		{ element.Name = name; return element; }

		public static TElement Tag<TElement>(this TElement element, object tag) where TElement :ElementType
		{ element.Tag = tag; return element; }

		public static TElement Resources<TElement>(this TElement element, ResourceDictionary resourceDictionary) where TElement :ElementType
		{ element.Resources = resourceDictionary; return element; }

		public static TElement FlowDirection<TElement>(this TElement element, FlowDirection flowDirection) where TElement :ElementType
		{ element.FlowDirection = flowDirection; return element; }

		public static TElement DataContext<TElement>(this TElement element, object dataContext) where TElement :ElementType
		{ element.DataContext = dataContext; return element; }

		public static TElement RequestedTheme<TElement>(this TElement element, ElementTheme elementTheme) where TElement :ElementType
		{ element.RequestedTheme = elementTheme; return element; }


		#region Style
		public static T Style<T>(this T element, Style style) where T :ElementType
		{ element.Style = style; return element; }

		public static T Style<T>(this T element, Style<T> style) where T :ElementType
		{ element.Style = style.FormsStyle; return element; }
		#endregion


		#region Size
		public static TElement Width<TElement>(this TElement element, double request) where TElement :ElementType
		{ element.Width = request; return element; }

		public static TElement Height<TElement>(this TElement element, double request) where TElement :ElementType
		{ element.Height = request; return element; }

		public static TElement MinWidth<TElement>(this TElement element, double request) where TElement :ElementType
		{ element.MinWidth = request; return element; }

		public static TElement MinHeight<TElement>(this TElement element, double request) where TElement :ElementType
		{ element.MinHeight = request; return element; }

		public static TElement MaxWidth<TElement>(this TElement element, double request) where TElement :ElementType
		{ element.MaxWidth = request; return element; }

		public static TElement MaxHeight<TElement>(this TElement element, double request) where TElement :ElementType
		{ element.MaxHeight = request; return element; }

		public static TElement Size<TElement>(this TElement element, double widthRequest, double heightRequest) where TElement :ElementType
			=> element.Width(widthRequest).Height(heightRequest);

		public static TElement Size<TElement>(this TElement element, double sizeRequest) where TElement :ElementType
			=> element.Width(sizeRequest).Height(sizeRequest);

		public static TElement MinSize<TElement>(this TElement element, double widthRequest, double heightRequest) where TElement :ElementType
			=> element.MinWidth(widthRequest).MinHeight(heightRequest);

		public static TElement MinSize<TElement>(this TElement element, double sizeRequest) where TElement :ElementType
			=> element.MinWidth(sizeRequest).MinHeight(sizeRequest);

		public static TElement MaxSize<TElement>(this TElement element, double widthRequest, double heightRequest) where TElement :ElementType
			=> element.MaxWidth(widthRequest).MaxHeight(heightRequest);

		public static TElement MaxSize<TElement>(this TElement element, double sizeRequest) where TElement :ElementType
			=> element.MaxWidth(sizeRequest).MaxHeight(sizeRequest);
		#endregion


		#region Alignment

		public static TElement Center<TElement>(this TElement element) where TElement :ElementType
		{ 
			element.VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Center; 
			element.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center; 
			return element; 
		}

		public static TElement Stretch<TElement>(this TElement element) where TElement :ElementType
		{
			element.VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Stretch;
			element.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Stretch;
			return element;
		}

		#region Vertical Alignment
		public static TElement VerticalAlignment<TElement>(this TElement element, VerticalAlignment verticalAlignment) where TElement :ElementType
		{ element.VerticalAlignment = verticalAlignment; return element; }

		public static TElement Top<TElement>(this TElement element) where TElement :ElementType
		{ element.VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Top; return element; }

		public static TElement CenterVertical<TElement>(this TElement element) where TElement :ElementType
		{ element.VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Center; return element; }

		public static TElement Bottom<TElement>(this TElement element) where TElement :ElementType
		{ element.VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Bottom; return element; }

		public static TElement StretchVertical<TElement>(this TElement element) where TElement :ElementType
		{ element.VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Stretch; return element; }

		#endregion

		#region Horizontal Alignment
		public static TElement HorizontalAlignment<TElement>(this TElement element, HorizontalAlignment horizontalAlignment) where TElement :ElementType
		{ element.HorizontalAlignment = horizontalAlignment; return element; }

		public static TElement Left<TElement>(this TElement element) where TElement :ElementType
		{ element.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Left; return element; }

		public static TElement CenterHorizontal<TElement>(this TElement element) where TElement :ElementType
		{ element.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center; return element; }

		public static TElement Right<TElement>(this TElement element) where TElement :ElementType
		{ element.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Right; return element; }

		public static TElement StretchHorizontal<TElement>(this TElement element) where TElement :ElementType
		{ element.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Stretch; return element; }
		#endregion


		#endregion


		#region Margin

		public static TElement Margin<TElement>(this TElement element, double value) where TElement :ElementType
		{ element.Margin = new Thickness(value); return element; }

		public static TElement Margin<TElement>(this TElement element, double horizontal, double vertical) where TElement :ElementType
		{ element.Margin = new Thickness(horizontal, vertical, horizontal, vertical); return element; }

		public static TElement Margin<TElement>(this TElement element, double left, double top, double right, double bottom) where TElement :ElementType
		{ element.Margin = new Thickness(left, top, right, bottom); return element; }

		public static TElement Margin<TElement>(this TElement element, Thickness margin) where TElement :ElementType
		{ element.Margin = margin; return element; }

		#endregion

		public static TElement Language<TElement>(this TElement element, string language) where TElement :ElementType
		{ element.Language = language; return element; }


		#region Focus
		public static TElement FocusVisualSecondaryThickness<TElement>(this TElement element, Thickness thickness) where TElement :ElementType
		{ element.FocusVisualSecondaryThickness = thickness; return element; }

		public static TElement FocusVisualSecondaryBrush<TElement>(this TElement element, Brush brush) where TElement :ElementType
		{ element.FocusVisualSecondaryBrush = brush; return element; }

		public static TElement FocusVisualPrimaryThickness<TElement>(this TElement element, Thickness thickness) where TElement :ElementType
		{ element.FocusVisualPrimaryThickness = thickness; return element; }

		public static TElement FocusVisualPrimaryBrush<TElement>(this TElement element, Brush brush) where TElement :ElementType
		{ element.FocusVisualPrimaryBrush = brush; return element; }

		public static TElement FocusVisualMargin<TElement>(this TElement element, Thickness thickness) where TElement :ElementType
		{ element.FocusVisualMargin = thickness; return element; }

		public static TElement AllowFocusWhenDisabled<TElement>(this TElement element, bool allow) where TElement :ElementType
		{ element.AllowFocusWhenDisabled = allow; return element; }

		public static TElement AllowFocusOnInteraction<TElement>(this TElement element, bool allow) where TElement :ElementType
		{ element.AllowFocusOnInteraction = allow; return element; }

        #endregion
    }
}
