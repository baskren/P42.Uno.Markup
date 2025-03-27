using System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using System.Reflection;

namespace P42.Uno.Markup;

public static class ImageExtensions
{
    public static Image Stretch(this Image element, Stretch stretch) 
    { element.Stretch = stretch; return element; }

    #region Source
    public static Image Source(this Image element, ImageSource source)
    { element.Source = source; return element; }

    public static Image Source(this Image element, Uri uri)
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

    public static Image Source(this Image element, string uriOrResourceId, Assembly asm = null)
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

    #region NineGrid
    public static Image NineGrid(this Image element, Thickness t)
    { element.NineGrid = t; return element; }

    public static Image NineGrid(this Image element, double h, double v)
    { element.NineGrid = new Thickness(h, v, h, v); return element; }

    public static Image NineGrid(this Image element, double t)
    { element.NineGrid = new Thickness(t); return element; }
    #endregion


}
