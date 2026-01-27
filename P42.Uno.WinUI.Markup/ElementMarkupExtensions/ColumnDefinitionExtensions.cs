namespace P42.Uno.WinUI.Markup;

// ReSharper disable once UnusedType.Global
public static class ColumnDefinitionExtensions
{
    // ReSharper disable once UnusedType.Global
    extension(ColumnDefinition column)
    {
        /// <summary>
        /// Fluent setter: Column width to AUTO
        /// </summary>
        /// <returns></returns>
        public ColumnDefinition Auto() 
        {
            column.Width = GridLength.Auto;
            return column;
        }

        /// <summary>
        /// Fluent setter: Column width as a portion of total width
        /// </summary>
        /// <param name="multiple"></param>
        /// <returns></returns>
        public ColumnDefinition Star(double multiple = 1)
        {
            column.Width = new GridLength(multiple, GridUnitType.Star);
            return column;
        }

        /// <summary>
        /// Fluent setter: Column width to a fixed number of pixels
        /// </summary>
        /// <param name="pixels"></param>
        /// <returns></returns>
        public ColumnDefinition Pixel(double pixels)
        {
            column.Width = new GridLength(pixels);
            return column;
        }
    }
}
