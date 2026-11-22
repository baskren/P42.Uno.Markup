using System;
using Microsoft.UI.Xaml.Controls;
using ElementType = Microsoft.UI.Xaml.UIElement;

namespace P42.Uno.Markup;

public static class ElementInGridExtensions
{
    public static TView Row<TView>(this TView view, int row) where TView :ElementType
    {
        view.SetValue(Grid.RowProperty, row);
        return view;
    }

    public static TView Row<TView>(this TView view, int row, int span) where TView :ElementType
    {
        view.SetValue(Grid.RowProperty, row);
        view.SetValue(Grid.RowSpanProperty, span);
        return view;
    }

    public static TView RowSpan<TView>(this TView view, int span) where TView :ElementType
    {
        view.SetValue(Grid.RowSpanProperty, span);
        VariableSizedWrapGrid.SetRowSpan(view, span); 
        return view;
    }

    public static TView Column<TView>(this TView view, int column) where TView :ElementType
    {
        view.SetValue(Grid.ColumnProperty, column);
        return view;
    }

    public static TView Column<TView>(this TView view, int column, int span) where TView :ElementType
    {
        view.SetValue(Grid.ColumnProperty, column);
        view.SetValue(Grid.ColumnSpanProperty, span);
        return view;
    }

    public static TView ColumnSpan<TView>(this TView view, int span) where TView :ElementType
    {
        view.SetValue(Grid.ColumnSpanProperty, span);
        VariableSizedWrapGrid.SetColumnSpan(view, span);
        return view;
    }

    public static TView Row<TView, TRow>(this TView view, TRow row) where TView :ElementType where TRow : Enum
    {
        var rowIndex = row.ToInt();
        view.SetValue(Grid.RowProperty, rowIndex);
        return view;
    }

    public static TView Row<TView, TRow>(this TView view, TRow first, TRow last) where TView :ElementType where TRow : Enum
    {
        var rowIndex = first.ToInt();
        var span = last.ToInt() - rowIndex + 1;
        view.SetValue(Grid.RowProperty, rowIndex);
        view.SetValue(Grid.RowSpanProperty, span);
        return view;
    }

    public static TView Column<TView, TColumn>(this TView view, TColumn column) where TView :ElementType where TColumn : Enum
    {
        var columnIndex = column.ToInt();
        view.SetValue(Grid.ColumnProperty, columnIndex);
        return view;
    }

    public static TView Column<TView, TColumn>(this TView view, TColumn first, TColumn last) where TView :ElementType where TColumn : Enum
    {
        var columnIndex = first.ToInt();
        view.SetValue(Grid.ColumnProperty, columnIndex);

        var span = last.ToInt() + 1 - columnIndex;
        view.SetValue(Grid.ColumnSpanProperty, span);

        return view;
    }

    public static TView RowCol<TView>(this TView view, int row, int column) where TView : ElementType
    {
        view.SetValue(Grid.RowProperty, row);
        view.SetValue(Grid.ColumnProperty, column);
        return view;
    }
}