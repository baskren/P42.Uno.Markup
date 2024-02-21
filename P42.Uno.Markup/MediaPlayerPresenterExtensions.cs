using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Media;
using ElementType = Microsoft.UI.Xaml.Controls.MediaPlayerPresenter;

namespace P42.Uno.Markup;
public static class MediaPlayerPresenterExtensions
{

    public static TElement IsFullWindow<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsFullWindow = value; return element; }

    public static TElement MediaPlayer<TElement>(this TElement element, Windows.Media.Playback.MediaPlayer value) where TElement : ElementType
    { element.MediaPlayer = value; return element; }

    public static TElement Stretch<TElement>(this TElement element, Stretch value) where TElement : ElementType
    { element.Stretch = value; return element; }
}
