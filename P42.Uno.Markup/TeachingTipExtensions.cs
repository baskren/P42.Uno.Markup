using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Windows.Foundation;
using ElementType = Microsoft.UI.Xaml.Controls.TeachingTip;

namespace P42.Uno.Markup;
public static class TeachingTipExtensions
{
    #region Action Button
    public static TElement ActionButtonCommand<TElement>(this TElement element, ICommand value) where TElement : ElementType
    { element.ActionButtonCommand = value; return element; }

    public static TElement ActionButtonCommandParameter<TElement>(this TElement element, object item) where TElement : ElementType
    { element.ActionButtonCommandParameter = item; return element; }

    public static TElement ActionButtonContent<TElement>(this TElement element, object value) where TElement : ElementType
    { element.ActionButtonContent = value; return element; }

    public static TElement ActionButtonStyle<TElement>(this TElement element, Microsoft.UI.Xaml.Style value) where TElement : ElementType
    { element.ActionButtonStyle = value; return element; }
    #endregion

    #region Close Button
    public static TElement CloseButtonCommand<TElement>(this TElement element, ICommand value) where TElement : ElementType
    { element.CloseButtonCommand = value; return element; }

    public static TElement CloseButtonCommandParameter<TElement>(this TElement element, object item) where TElement : ElementType
    { element.CloseButtonCommandParameter = item; return element; }

    public static TElement CloseButtonContent<TElement>(this TElement element, object value) where TElement : ElementType
    { element.CloseButtonContent = value; return element; }

    public static TElement CloseButtonStyle<TElement>(this TElement element, Microsoft.UI.Xaml.Style value) where TElement : ElementType
    { element.CloseButtonStyle = value; return element; }
    #endregion

    #region Hero
    public static TElement HeroContent<TElement>(this TElement element, UIElement value) where TElement : ElementType
    { element.HeroContent = value; return element; }

    public static TElement HeroContentPlacement<TElement>(this TElement element, TeachingTipHeroContentPlacementMode value) where TElement : ElementType
    { element.HeroContentPlacement = value; return element; }
    #endregion

    #region IconSource
    public static TElement Icon<TElement>(this TElement element, IconSource value = null) where TElement : ElementType
    { element.IconSource = value; return element; }

    public static TElement Icon<TElement>(this TElement element, Symbol value) where TElement : ElementType
    { element.IconSource = new SymbolIconSource { Symbol = value }; return element; }

    public static TElement Icon<TElement>(this TElement element, string glyph, FontFamily fontFamily) where TElement : ElementType
    { element.IconSource = new FontIconSource { FontFamily = fontFamily, Glyph = glyph }; return element; }

    public static TElement Icon<TElement>(this TElement element, string glyph, FontFamily fontFamily, double fontSize) where TElement : ElementType
    { element.IconSource = new FontIconSource { FontFamily = fontFamily, FontSize = fontSize, Glyph = glyph }; return element; }

    public static TElement Icon<TElement>(this TElement element, Geometry path) where TElement : ElementType
    { element.IconSource = new PathIconSource { Data = path }; return element; }

    public static TElement Icon<TElement>(this TElement element, Uri bitMapUriSource, bool showAsMonoChrome = true) where TElement : ElementType
    { element.IconSource = new BitmapIconSource { UriSource = bitMapUriSource, ShowAsMonochrome = showAsMonoChrome }; return element; }
    #endregion

    public static TElement IsLightDismissEnabled<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsLightDismissEnabled = value; return element; }


    public static TElement IsOpen<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsOpen = value; return element; }

    public static TElement IsClosed<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsOpen = !value; return element; }

    public static TElement PlacementMargin<TElement>(this TElement element, Thickness value) where TElement : ElementType
    { element.PlacementMargin = value; return element; }

    public static TElement PreferredPlacement<TElement>(this TElement element, TeachingTipPlacementMode value) where TElement : ElementType
    { element.PreferredPlacement = value; return element; }

    public static TElement ShouldConstrainToRootBounds<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.ShouldConstrainToRootBounds = value; return element; }

    public static TElement Subtitle<TElement>(this TElement element, string value) where TElement : ElementType
    { element.Subtitle = value ?? string.Empty; return element; }

    public static TElement TailVisibility<TElement>(this TElement element, TeachingTipTailVisibility value) where TElement : ElementType
    { element.TailVisibility = value; return element; }

    public static TElement Target<TElement>(this TElement element, FrameworkElement value) where TElement : ElementType
    { element.Target = value; return element; }

    public static TElement Title<TElement>(this TElement element, string value) where TElement : ElementType
    { element.Title = value ?? string.Empty; return element; }

    #region Events
    public static TElement AddActionButtonClickHandler<TElement>(this TElement element, TypedEventHandler<TeachingTip, object> handler) where TElement : ElementType
    { element.ActionButtonClick += handler; return element; }

    public static TElement AddCloseButtonClickHandler<TElement>(this TElement element, TypedEventHandler<TeachingTip, object> handler) where TElement : ElementType
    { element.CloseButtonClick += handler; return element; }

    public static TElement AddClosedHandler<TElement>(this TElement element, TypedEventHandler<TeachingTip, TeachingTipClosedEventArgs> handler) where TElement : ElementType
    { element.Closed += handler; return element; }

    public static TElement AddClosingHandler<TElement>(this TElement element, TypedEventHandler<TeachingTip, TeachingTipClosingEventArgs> handler) where TElement : ElementType
    { element.Closing += handler; return element; }
    #endregion
}
