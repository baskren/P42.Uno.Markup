using P42.Utils;
using ElementType = Microsoft.UI.Xaml.UIElement;

namespace P42.Uno.WinUI.Markup;

// ReSharper disable once UnusedType.Global
public static class ElementInGridExtensions
{
    /// <summary>
    /// Element in Grid Attached Properties Fluent Extensions
    /// </summary>
    /// <param name="view"></param>
    /// <typeparam name="TView"></typeparam>
    extension<TView>(TView view) where TView :ElementType
    {
        /// <summary>
        /// Set row
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public TView Row(int row)
        {
            view.SetValue(Grid.RowProperty, row);
            return view;
        }

        /// <summary>
        /// Set Row and Span
        /// </summary>
        /// <param name="row"></param>
        /// <param name="span"></param>
        /// <returns></returns>
        public TView Row(int row, int span)
        {
            view.SetValue(Grid.RowProperty, row);
            view.SetValue(Grid.RowSpanProperty, span);
            return view;
        }

        /// <summary>
        /// Set RowSpan
        /// </summary>
        /// <param name="span"></param>
        /// <returns></returns>
        public TView RowSpan(int span)
        {
            view.SetValue(Grid.RowSpanProperty, span);
            VariableSizedWrapGrid.SetRowSpan(view, span); 
            return view;
        }

        /// <summary>
        /// Set Column
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public TView Column(int column)
        {
            view.SetValue(Grid.ColumnProperty, column);
            return view;
        }

        /// <summary>
        /// Set Column and Span
        /// </summary>
        /// <param name="column"></param>
        /// <param name="span"></param>
        /// <returns></returns>
        public TView Column(int column, int span)
        {
            view.SetValue(Grid.ColumnProperty, column);
            view.SetValue(Grid.ColumnSpanProperty, span);
            return view;
        }

        /// <summary>
        /// Set Column Span
        /// </summary>
        /// <param name="span"></param>
        /// <returns></returns>
        public TView ColumnSpan(int span)
        {
            view.SetValue(Grid.ColumnSpanProperty, span);
            VariableSizedWrapGrid.SetColumnSpan(view, span);
            return view;
        }

        /// <summary>
        /// Use an enum to set the row
        /// </summary>
        /// <param name="row"></param>
        /// <typeparam name="TRow"></typeparam>
        /// <returns></returns>
        public TView Row<TRow>(TRow row) where TRow : Enum
        {
            var rowIndex = row.ToInt();
            view.SetValue(Grid.RowProperty, rowIndex);
            return view;
        }

        /// <summary>
        /// Use enums values to set first and last row of element
        /// </summary>
        /// <param name="first"></param>
        /// <param name="last"></param>
        /// <typeparam name="TRow"></typeparam>
        /// <returns></returns>
        public TView Row<TRow>(TRow first, TRow last) where TRow : Enum
        {
            var rowIndex = first.ToInt();
            var span = last.ToInt() - rowIndex + 1;
            view.SetValue(Grid.RowProperty, rowIndex);
            view.SetValue(Grid.RowSpanProperty, span);
            return view;
        }

        /// <summary>
        /// Use enum to set Column
        /// </summary>
        /// <param name="column"></param>
        /// <typeparam name="TColumn"></typeparam>
        /// <returns></returns>
        public TView Column<TColumn>(TColumn column) where TColumn : Enum
        {
            var columnIndex = column.ToInt();
            view.SetValue(Grid.ColumnProperty, columnIndex);
            return view;
        }

        /// <summary>
        /// Use enum to set first and last column for element  
        /// </summary>
        /// <param name="first"></param>
        /// <param name="last"></param>
        /// <typeparam name="TColumn"></typeparam>
        /// <returns></returns>
        public TView Column<TColumn>(TColumn first, TColumn last) where TColumn : Enum
        {
            var columnIndex = first.ToInt();
            view.SetValue(Grid.ColumnProperty, columnIndex);

            var span = last.ToInt() + 1 - columnIndex;
            view.SetValue(Grid.ColumnSpanProperty, span);

            return view;
        }

        /// <summary>
        /// Set Row and Column
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public TView RowCol(int row, int column)
        {
            view.SetValue(Grid.RowProperty, row);
            view.SetValue(Grid.ColumnProperty, column);
            return view;
        }

        /// <summary>
        /// Set Row, Column, RowSpan, and ColumnSpan
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="rowSpan"></param>
        /// <param name="columnSpan"></param>
        /// <returns></returns>
        public TView RowCol(int row, int column, int rowSpan, int columnSpan)
        {
            view.SetValue(Grid.RowProperty, row);
            view.SetValue(Grid.ColumnProperty, column);
            view.SetValue(Grid.RowSpanProperty, rowSpan);
            view.SetValue(Grid.ColumnSpanProperty, columnSpan);
            return view;
            
        }
    }
}
