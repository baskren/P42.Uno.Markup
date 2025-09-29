using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace P42.Uno.Markup;

public static class RowDefinitionExtensions
{
    public static RowDefinition Auto(this RowDefinition row) 
    { row.Height = GridLength.Auto; return row; }

    public static RowDefinition Star(this RowDefinition row, double multiple = 1)
    { row.Height = new GridLength(multiple, GridUnitType.Star); return row; }

    public static RowDefinition Pixel(this RowDefinition row, double pixels)
    { row.Height = new GridLength(pixels); return row; }

}
