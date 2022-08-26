using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Windows.Web.Syndication;

namespace P42.Uno.Markup
{
    public static class ColumnDefinitionExtensions
    {
        public static ColumnDefinition Auto(this ColumnDefinition column) 
        {
            column.Width = GridLength.Auto;
            return column;
        }

        public static ColumnDefinition Star(this ColumnDefinition column, double multiple = 1)
        {
            column.Width = new GridLength(multiple, GridUnitType.Star);
            return column;
        }

        public static ColumnDefinition Pixel(this ColumnDefinition column, double pixels)
        {
            column.Width = new GridLength(pixels);
            return column;
        }
    }
}