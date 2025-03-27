using System;
using Microsoft.UI.Xaml.Media;
using ElementType = Microsoft.UI.Xaml.Controls.ImageIcon;
using Microsoft.UI.Xaml.Media.Imaging;
using System.Reflection;

namespace P42.Uno.Markup;

public static class ImageIconExtensions
{
    #region Source
    public static TElement Source<TElement>(this TElement element, ImageSource source) where TElement : ElementType
    { element.Source = source; return element; }

    public static TElement Source<TElement>(this TElement element, Uri uri) where TElement : ElementType
    {
        try
        {
            var bitmap = new BitmapImage(uri);
            return element.Source(bitmap);
        }
        catch (Exception e)
        {
            Console.WriteLine($"ImageExtensions.Source: Cannot create BitmapImage from Uri [{uri}].  Exception: [{e}]");
        }
        return element;
    }

    public static TElement Source<TElement>(this TElement element, string uriOrResourceId, Assembly asm = null) where TElement : ElementType
    {
        if (uriOrResourceId.StartsWith("/"))
            uriOrResourceId = $"ms-appx://{uriOrResourceId}";

        if (uriOrResourceId.Contains(":/"))
        {
            try
            {
                var uri = new Uri(uriOrResourceId);
                return element.Source(uri);
            }
            catch (Exception e)
            {
                Console.WriteLine($"ImageExtensions.Source: Cannot create Uri from string [{uriOrResourceId}].  Exception: [{e}]");
            }
        }
        else if (Utils.Uno.ImageSourceExtensions.GetImageSourceFromEmbeddedResource(uriOrResourceId, asm) is { } source)
        {
            element.Source(source);
            return element;
        }

        Console.WriteLine($"ImageExtensions.Source: Cannot find ImageSource from uriOrResourceId string [{uriOrResourceId}].");
        return element;
    }
    #endregion

}
