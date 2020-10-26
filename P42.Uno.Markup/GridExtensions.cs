using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using ElementType = Windows.UI.Xaml.Controls.Grid;

namespace P42.Uno.Markup
{
    public static class GridExtensions
    {
        #region Padding
        public static TElement Padding<TElement>(this TElement element, double value) where TElement : ElementType
        { element.Padding = new Thickness(value); return element; }

        public static TElement Padding<TElement>(this TElement element, double horizontal, double vertical) where TElement : ElementType
        { element.Padding = new Thickness(horizontal, vertical, horizontal, vertical); return element; }

        public static TElement Padding<TElement>(this TElement element, double left, double top, double right, double bottom) where TElement : ElementType
        { element.Padding = new Thickness(left, top, right, bottom); return element; }

        public static TElement Padding<TElement>(this TElement element, Thickness padding) where TElement : ElementType
        { element.Padding = padding; return element; }
        #endregion


        #region CornerRadius
        public static TElement CornerRadius<TElement>(this TElement element, double value) where TElement : ElementType
        { element.CornerRadius = new CornerRadius(value); return element; }

        public static TElement CornerRadius<TElement>(this TElement element, double topLeft, double topRight, double bottomRight, double bottomLeft) where TElement : ElementType
        { element.CornerRadius = new CornerRadius(topLeft, topRight, bottomRight, bottomLeft); return element; }

        public static TElement CornerRadius<TElement>(this TElement element, CornerRadius padding) where TElement : ElementType
        { element.CornerRadius = padding; return element; }
        #endregion


        #region Border Thickness
        public static TElement BorderThickness<TElement>(this TElement element, double value) where TElement : ElementType
        { element.BorderThickness = new Thickness(value); return element; }

        public static TElement BorderThickness<TElement>(this TElement element, double horizontal, double vertical) where TElement : ElementType
        { element.BorderThickness = new Thickness(horizontal, vertical, horizontal, vertical); return element; }

        public static TElement BorderThickness<TElement>(this TElement element, double left, double top, double right, double bottom) where TElement : ElementType
        { element.BorderThickness = new Thickness(left, top, right, bottom); return element; }

        public static TElement BorderThickness<TElement>(this TElement element, Thickness padding) where TElement : ElementType
        { element.BorderThickness = padding; return element; }
        #endregion


        #region BorderBrush
        public static TElement BorderBrush<TElement>(this TElement element, Brush value) where TElement : ElementType
        { element.BorderBrush = value; return element; }

        public static TElement BorderBrush<TElement>(this TElement element, Color value) where TElement : ElementType
        { element.BorderBrush = new SolidColorBrush(value); return element; }

		public static TElement BorderBrush<TElement>(this TElement element, string hex) where TElement : ElementType
		{ element.BorderBrush = new SolidColorBrush(P42.Utils.Uno.ColorExtensions.ColorFromHex(hex)); return element; }
		#endregion

		public static TElement RowSpacing<TElement>(this TElement element, double value) where TElement : ElementType
        { element.RowSpacing = value; return element; }

        public static TElement ColumnSpacing<TElement>(this TElement element, double value) where TElement : ElementType
        { element.ColumnSpacing = value; return element; }

        public static TElement BackgroundSizing<TElement>(this TElement element, BackgroundSizing sizing) where TElement : ElementType
        { element.BackgroundSizing = sizing; return element; }


        #region Rows / Columns
        public static TElement Columns<TElement>(this TElement grid, params GridLength[] lengths) where TElement : ElementType
		{
			grid.ColumnDefinitions.Clear();
			foreach (var length in lengths)
			{
				var columnDefinition = new ColumnDefinition { Width = length };
				grid.ColumnDefinitions.Add(columnDefinition);
			}
			return grid;
		}

		public static TElement Columns<TElement, TEnum>(this TElement grid, params (TEnum name, GridLength length)[] columns) where TElement : ElementType where TEnum : Enum
		{
			grid.ColumnDefinitions.Clear();
			for (int i = 0; i < columns.Length; i++)
			{
				if (i != columns[i].name.ToInt())
					throw new ArgumentException(
						$"Value of column name { columns[i].name } is not { i }. " +
						"Columns must be defined with enum names whose values form the sequence 0,1,2,..."
					);
				var columnDefinition = new ColumnDefinition { Width = columns[i].length };
				grid.ColumnDefinitions.Add(columnDefinition);
			}
			return grid;
		}

		public static TElement Rows<TElement>(this TElement grid, params GridLength[] lengths) where TElement : ElementType
		{
			grid.RowDefinitions.Clear();
			foreach (var length in lengths)
			{
				var rowDefinition = new RowDefinition { Height = length };
				grid.RowDefinitions.Add(rowDefinition);
			}
			return grid;
		}

		public static TElement Rows<TElement, TEnum>(this TElement grid, params (TEnum name, GridLength length)[] rows) where TElement : ElementType where TEnum : Enum
		{
			grid.RowDefinitions.Clear();
			for (int i = 0; i < rows.Length; i++)
			{
				if (i != rows[i].name.ToInt())
					throw new ArgumentException(
						$"Value of row name { rows[i].name } is not { i }. " +
						"Rows must be defined with enum names whose values form the sequence 0,1,2,..."
					);
				var rowDefinition = new RowDefinition { Height = rows[i].length };
				grid.RowDefinitions.Add(rowDefinition);
			}
			return grid;
		}
        #endregion

    }
}
