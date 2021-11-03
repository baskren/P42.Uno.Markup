using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace P42.Uno.Markup
{
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
                System.Console.WriteLine($"ImageExtensions.Source: Cannot create BitmapImage from Uri [{uri}].  Exception: [{e}]");
            }
            return element;
        }

        public static Image Source(this Image element, string sourceUri)
        {
            try
            {
                var uri = new Uri(sourceUri);
                return element.Source(uri);
            }
            catch (Exception e)
            {
                System.Console.WriteLine($"ImageExtensions.Source: Cannot create Uri from string [{sourceUri}].  Exception: [{e}]");
            }
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
}
