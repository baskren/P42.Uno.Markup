using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.Web.Syndication;
using ElementType = Windows.UI.Xaml.Controls.RowDefinition;

namespace P42.Uno.Markup
{
    public static class RowDefinitionExtensions
    {
        public static RowDefinition Auto(this RowDefinition row) 
        {
            row.Height = GridLength.Auto;
            return row;
        }

        public static RowDefinition Star(this RowDefinition row, double multiple = 1)
        {
            row.Height = new GridLength(multiple, GridUnitType.Star);
            return row;
        }

        public static RowDefinition Pixel(this RowDefinition row, double pixels)
        {
            row.Height = new GridLength(pixels);
            return row;
        }
    }
}