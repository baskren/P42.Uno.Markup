using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace P42.Uno.Markup;

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