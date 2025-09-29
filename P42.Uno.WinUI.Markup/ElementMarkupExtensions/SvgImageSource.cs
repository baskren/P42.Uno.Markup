using System;
using Windows.Foundation;
using ElementType = Microsoft.UI.Xaml.Media.Imaging.SvgImageSource;
using System.Reflection;
using Microsoft.UI.Xaml.Media.Imaging;
using System.IO;
using P42.Utils.Uno;
using P42.Utils;
using AsyncAwaitBestPractices;


namespace P42.Uno.Markup;

public static class SvgImageSourceExtensions
{
    public static TElement ResourceSourceT<TElement>(this TElement element, string value, Assembly asm = null) where TElement : ElementType
    {
        if (EmbeddedResourceExtensions.FindStream(value, asm) is { } stream)
        {
            using var randomAccessStream = stream.AsRandomAccessStream();
            //element.SetSourceAsync(randomAccessStream).Forget();
            element.SetSourceAsync(randomAccessStream).AsTask().SafeFireAndForget();
            stream.Dispose();
            return element;
        }
        Console.WriteLine($"SvgImageExtensions.Source: Cannot find ImageSource from ResourceId string [{value}].");

        return element; 
    }


}
