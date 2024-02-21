using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Windows.Foundation;
using ElementType = Microsoft.UI.Xaml.Controls.MediaTransportControls;

namespace P42.Uno.Markup;
public static class MediaTransportControlsExtensions
{

    public static TElement FastPlayFallbackBehaviour<TElement>(this TElement element, FastPlayFallbackBehaviour value) where TElement : ElementType
    { element.FastPlayFallbackBehaviour = value; return element; }

    public static TElement IsCompact<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsCompact = value; return element; }

    public static TElement IsFastForwardButtonVisible<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsFastForwardButtonVisible = value; return element; }

    public static TElement IsFastForwardEnabled<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsFastForwardEnabled = value; return element; }

    public static TElement IsFastRewindButtonVisible<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsFastRewindButtonVisible = value; return element; }

    public static TElement IsFastRewindEnabled<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsFastRewindEnabled = value; return element; }

    public static TElement IsNextTrackButtonVisible<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsNextTrackButtonVisible = value; return element; }

    public static TElement IsPlaybackRateButtonVisible<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsPlaybackRateButtonVisible = value; return element; }

    public static TElement IsPlaybackRateEnabled<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsPlaybackRateEnabled = value; return element; }

    public static TElement IsPreviousTrackButtonVisible<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsPreviousTrackButtonVisible = value; return element; }

    public static TElement IsRepeatButtonVisible<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsRepeatButtonVisible = value; return element; }

    public static TElement IsRepeatEnabled<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsRepeatEnabled = value; return element; }

    public static TElement IsSeekBarVisible<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsSeekBarVisible = value; return element; }

    public static TElement IsSeekEnabled<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsSeekEnabled = value; return element; }

    public static TElement IsSkipBackwardButtonVisible<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsSkipBackwardButtonVisible = value; return element; }

    public static TElement IsSkipBackwardEnabled<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsSkipBackwardEnabled = value; return element; }

    public static TElement IsSkipForwardButtonVisible<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsSkipForwardButtonVisible = value; return element; }

    public static TElement IsSkipForwardEnabled<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsSkipForwardEnabled = value; return element; }

    public static TElement IsStopButtonVisible<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsStopButtonVisible = value; return element; }

    public static TElement IsStopEnabled<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsStopEnabled = value; return element; }

    public static TElement IsVolumeButtonVisible<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsVolumeButtonVisible = value; return element; }

    public static TElement IsVolumeEnabled<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsVolumeEnabled = value; return element; }

    public static TElement IsZoomButtonVisible<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsZoomButtonVisible = value; return element; }

    public static TElement IsZoomEnabled<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsZoomEnabled = value; return element; }

    public static TElement ShowAndHideAutomatically<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.ShowAndHideAutomatically = value; return element; }

    #region Events

    public static TElement AddThumbnailRequestedHandler<TElement>(this TElement element, TypedEventHandler<MediaTransportControls, MediaTransportControlsThumbnailRequestedEventArgs> handler) where TElement : ElementType
    { element.ThumbnailRequested += handler; return element; }
    #endregion
}
