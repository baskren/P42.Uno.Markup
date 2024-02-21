using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Windows.Media.Playback;
using ElementType = Microsoft.UI.Xaml.Controls.MediaPlayerElement;

namespace P42.Uno.Markup;
public static class MediaPlayerElementExtensions
{

    public static TElement AreTransportControlsEnabled<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.AreTransportControlsEnabled = value; return element; }

    public static TElement AutoPlay<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.AutoPlay = value; return element; }

    public static TElement IsFullWindow<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsFullWindow = value; return element; }

    public static TElement PosterSource<TElement>(this TElement element, ImageSource value) where TElement : ElementType
    { element.PosterSource = value; return element; }

    public static TElement Source<TElement>(this TElement element, IMediaPlaybackSource value) where TElement : ElementType
    { element.Source = value; return element; }

    public static TElement Stretch<TElement>(this TElement element, Stretch value) where TElement : ElementType
    { element.Stretch = value; return element; }

    public static TElement TransportControls<TElement>(this TElement element, MediaTransportControls value) where TElement : ElementType
    { element.TransportControls = value; return element; }
    
}
