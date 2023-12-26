using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Text;
using Microsoft.UI;
using Microsoft.UI.Text;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using ElementType = Microsoft.UI.Xaml.Media.Imaging.SvgImageSource;
using System.Reflection;
using Microsoft.UI.Xaml.Media.Imaging;
using System.IO;
using P42.Utils.Uno;


namespace P42.Uno.Markup
{
    public static class SvgImageSourceExtensions
    {
        public static TElement PixelHeight<TElement>(this TElement element, double value) where TElement : ElementType
        { element.RasterizePixelHeight = value; return element; }

        public static TElement PixelWidth<TElement>(this TElement element, double value) where TElement : ElementType
        { element.RasterizePixelWidth = value; return element; }

        public static TElement PixelSize<TElement>(this TElement element, Size value) where TElement : ElementType
        { element.RasterizePixelWidth = value.Width; element.RasterizePixelHeight = value.Height; return element; }

        public static TElement UriSource<TElement>(this TElement element, Uri value) where TElement : ElementType
        { element.UriSource = value; return element; }

        public static TElement ResourceSource<TElement>(this TElement element, string value, Assembly asm = null) where TElement : ElementType
        {
            if (EmbeddedResourceExtensions.FindStreamForResourceId(value, asm) is Stream stream)
            {
                using var randomAccessStream = stream.AsRandomAccessStream();
                element.SetSourceAsync(randomAccessStream).Forget();
                stream.Dispose();
                return element;
            }
            System.Console.WriteLine($"SvgImageExtensions.Source: Cannot find ImageSource from ResourceId string [{value}].");

            return element; 
        }

        public static TElement Source<TElement>(this TElement element, string uriOrResourceId, Assembly asm = null) where TElement : ElementType
        {
            if (uriOrResourceId.StartsWith("/"))
                uriOrResourceId = "ms-appx://" + uriOrResourceId;

            if (uriOrResourceId.Contains(":/"))
            {
                try
                {
                    var uri = new Uri(uriOrResourceId);
                    return element.UriSource(uri);
                }
                catch (Exception e)
                {
                    System.Console.WriteLine($"ImageExtensions.Source: Cannot create Uri from string [{uriOrResourceId}].  Exception: [{e}]");
                }
            }

            return element.ResourceSource(uriOrResourceId);
        }

        #region Events
        public static TElement AddOpenedHandler<TElement>(this TElement element, TypedEventHandler<SvgImageSource, SvgImageSourceOpenedEventArgs> handler) where TElement : ElementType
        { element.Opened += handler; return element; }

        public static TElement AddOpenedFailedHandler<TElement>(this TElement element, TypedEventHandler<SvgImageSource, SvgImageSourceFailedEventArgs> handler) where TElement : ElementType
        { element.OpenFailed += handler; return element; }
        #endregion
    }
}