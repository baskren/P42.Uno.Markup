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
		{ element.BorderBrush = new SolidColorBrush(P42.Utils.Uno.ColorExtensions.ColorFromString(hex)); return element; }
		#endregion

		public static TElement RowSpacing<TElement>(this TElement element, double value) where TElement : ElementType
        { element.RowSpacing = value; return element; }

        public static TElement ColumnSpacing<TElement>(this TElement element, double value) where TElement : ElementType
        { element.ColumnSpacing = value; return element; }

        public static TElement BackgroundSizing<TElement>(this TElement element, BackgroundSizing sizing) where TElement : ElementType
        { element.BackgroundSizing = sizing; return element; }


		#region Rows / Columns
		/*
		public static TElement Columns<TElement>(this TElement grid, params ColumnDefinition[] columnDefinitions) where TElement : ElementType
		{
			grid.ColumnDefinitions.Clear();
			foreach (var column in columnDefinitions)
				grid.ColumnDefinitions.Add(column);
			return grid;
		}

		public static TElement Columns<TElement>(this TElement grid, params GridLength[] lengths) where TElement : ElementType
		{
			grid.ColumnDefinitions.Clear();
			foreach (var length in lengths)
				grid.ColumnDefinitions.Add(new ColumnDefinition { Width = length });
			return grid;
		}
		*/
		public static TElement Columns<TElement>(this TElement grid, params object[] lengths) where TElement : ElementType
		{
			grid.ColumnDefinitions.Clear();
			foreach (var length in lengths)
			{
				if (length is ColumnDefinition columnDefinition)
					grid.ColumnDefinitions.Add(columnDefinition);
				else
					grid.ColumnDefinitions.Add(new ColumnDefinition { Width = ObjectToGridLength(length) });
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

		public static TElement Columns<TElement, TEnum>(this TElement grid, params (TEnum name, object length)[] columns) where TElement : ElementType where TEnum : Enum
		{
			grid.ColumnDefinitions.Clear();
			for (int i = 0; i < columns.Length; i++)
			{
				if (i != columns[i].name.ToInt())
					throw new ArgumentException(
						$"Value of column name { columns[i].name } is not { i }. " +
						"Columns must be defined with enum names whose values form the sequence 0,1,2,..."
					);
				if (!(columns[i].length is ColumnDefinition columnDefinition))
					columnDefinition = new ColumnDefinition { Width = ObjectToGridLength(columns[i].length) };
				grid.ColumnDefinitions.Add(columnDefinition);
			}
			return grid;
		}

		/*
		public static TElement Rows<TElement>(this TElement grid, params RowDefinition[] rows) where TElement : ElementType
        {
			grid.RowDefinitions.Clear();
			foreach (var row in rows)
				grid.RowDefinitions.Add(row);
			return grid;
        }
		public static TElement Rows<TElement>(this TElement grid, params GridLength[] lengths) where TElement : ElementType
		{
			grid.RowDefinitions.Clear();
			foreach (var length in lengths)
				grid.RowDefinitions.Add(new RowDefinition { Height = length });
			return grid;
		}
		*/

		public static TElement Rows<TElement>(this TElement grid, params object[] lengths) where TElement : ElementType
		{
			grid.RowDefinitions.Clear();
			foreach (var length in lengths)
            {
				if (length is RowDefinition rowDefinition)
					grid.RowDefinitions.Add(rowDefinition);
				else
					grid.RowDefinitions.Add(new RowDefinition { Height = ObjectToGridLength(length) });
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
		public static TElement Rows<TElement, TEnum>(this TElement grid, params (TEnum name, object length)[] rows) where TElement : ElementType where TEnum : Enum
		{
			grid.RowDefinitions.Clear();
			for (int i = 0; i < rows.Length; i++)
			{
				if (i != rows[i].name.ToInt())
					throw new ArgumentException(
						$"Value of row name { rows[i].name } is not { i }. " +
						"Rows must be defined with enum names whose values form the sequence 0,1,2,..."
					);
				if (!(rows[i].length is RowDefinition rowDefinition))
					rowDefinition = new RowDefinition { Height = ObjectToGridLength(rows[i].length) };
				grid.RowDefinitions.Add(rowDefinition);
			}
			return grid;
		}

		static GridLength ObjectToGridLength(object obj)
		{
			if (obj is double d)
				return new GridLength(d);
			if (obj is int i)
				return new GridLength(i);
			if (obj is string str)
			{
				str = str.Trim();
				if (str.EndsWith("*"))
				{
					str.TrimEnd('*');
					if (string.IsNullOrWhiteSpace(str) || str == "*")
						return new GridLength(1, GridUnitType.Star);
					if (double.TryParse(str, out double value))
						return new GridLength(value, GridUnitType.Star);
					throw new Exception("Cannot parse string [" + str + "] into a GridLength");
				}
				if (str.ToLower().StartsWith("a"))
					return GridLength.Auto;
				if (str.ToLower().StartsWith("s"))
					return new GridLength(1, GridUnitType.Star);
				if (double.TryParse(str, out double d1))
					return new GridLength(d1);
				throw new Exception("Cannot parse string [" + str + "] into a GridLength");
			}
			if (obj is GridLength length)
				return length;
			if (obj is RowDefinition rowDef)
				return rowDef.Height;
			if (obj is ColumnDefinition colDef)
				return colDef.Width;
			return new GridLength(Convert.ToDouble(obj));
		}


		#endregion

	}
}
