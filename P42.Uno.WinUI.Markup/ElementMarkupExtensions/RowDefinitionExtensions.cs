// ReSharper disable once CheckNamespace
namespace P42.Uno.WinUI.Markup;

/// <summary>
/// RowDefinition extensions
/// </summary>
// ReSharper disable once UnusedType.Global
public static class RowDefinitionExtensions
{
    extension(RowDefinition row)
    {
        /// <summary>
        /// Auto row GridLength fluent setter
        /// </summary>
        /// <returns></returns>
        public RowDefinition Auto() 
        { row.Height = GridLength.Auto; return row; }

        /// <summary>
        /// Star row GridLength fluent setter
        /// </summary>
        /// <param name="multiple"></param>
        /// <returns></returns>
        public RowDefinition Star(double multiple = 1)
        { row.Height = new GridLength(multiple, GridUnitType.Star); return row; }

        /// <summary>
        /// Pixel row GridLength fluent setter
        /// </summary>
        /// <param name="pixels"></param>
        /// <returns></returns>
        public RowDefinition Pixel(double pixels)
        { row.Height = new GridLength(pixels); return row; }
    }
}
