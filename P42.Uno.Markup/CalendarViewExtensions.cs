using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Foundation;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Windows.Media.Capture;
using Microsoft.UI.Xaml.Media;
using ElementType = Microsoft.UI.Xaml.Controls.CalendarView;
using Windows.UI;
using Windows.UI.Text;

namespace P42.Uno.Markup
{
    public static class CalendarViewExtensions
    {
        #region Properties

        #region BlackoutBackground
        public static TElement BlackoutBackground<TElement>(this TElement element, Brush value) where TElement : ElementType
        { element.BlackoutBackground = value; return element; }

        public static TElement BlackoutBackground<TElement>(this TElement element, Color color) where TElement : ElementType
        { element.BlackoutBackground = new SolidColorBrush(color); return element; }

        public static TElement BlackoutBackground<TElement>(this TElement element, string color) where TElement : ElementType
        { element.BlackoutBackground = new SolidColorBrush(ColorExtensions.ColorFromString(color)); return element; }

        public static TElement BlackoutBackground<TElement>(this TElement element, uint hex) where TElement : ElementType
        { element.BlackoutBackground = new SolidColorBrush(ColorExtensions.ColorFromUint(hex)); return element; }
        #endregion

        #region BlackoutForeground
        public static TElement BlackoutForeground<TElement>(this TElement element, Brush value) where TElement : ElementType
        { element.BlackoutForeground = value; return element; }

        public static TElement BlackoutForeground<TElement>(this TElement element, Color color) where TElement : ElementType
        { element.BlackoutForeground = new SolidColorBrush(color); return element; }

        public static TElement BlackoutForeground<TElement>(this TElement element, string color) where TElement : ElementType
        { element.BlackoutForeground = new SolidColorBrush(ColorExtensions.ColorFromString(color)); return element; }

        public static TElement BlackoutForeground<TElement>(this TElement element, uint hex) where TElement : ElementType
        { element.BlackoutForeground = new SolidColorBrush(ColorExtensions.ColorFromUint(hex)); return element; }
        #endregion

        #region BlackoutStrikethroughBrush
        public static TElement BlackoutStrikethroughBrush<TElement>(this TElement element, Brush value) where TElement : ElementType
        { element.BlackoutStrikethroughBrush = value; return element; }

        public static TElement BlackoutStrikethroughBrush<TElement>(this TElement element, Color color) where TElement : ElementType
        { element.BlackoutStrikethroughBrush = new SolidColorBrush(color); return element; }

        public static TElement BlackoutStrikethroughBrush<TElement>(this TElement element, string color) where TElement : ElementType
        { element.BlackoutStrikethroughBrush = new SolidColorBrush(ColorExtensions.ColorFromString(color)); return element; }

        public static TElement BlackoutStrikethroughBrush<TElement>(this TElement element, uint hex) where TElement : ElementType
        { element.BlackoutStrikethroughBrush = new SolidColorBrush(ColorExtensions.ColorFromUint(hex)); return element; }
        #endregion

        public static TElement CalendarIdentifier<TElement>(this TElement element, string value) where TElement : ElementType
        { element.CalendarIdentifier = value; return element; }

        #region CalendarItemBackground
        public static TElement CalendarItemBackground<TElement>(this TElement element, Brush value) where TElement : ElementType
        { element.CalendarItemBackground = value; return element; }

        public static TElement CalendarItemBackground<TElement>(this TElement element, Color color) where TElement : ElementType
        { element.CalendarItemBackground = new SolidColorBrush(color); return element; }

        public static TElement CalendarItemBackground<TElement>(this TElement element, string color) where TElement : ElementType
        { element.CalendarItemBackground = new SolidColorBrush(ColorExtensions.ColorFromString(color)); return element; }

        public static TElement CalendarItemBackground<TElement>(this TElement element, uint hex) where TElement : ElementType
        { element.CalendarItemBackground = new SolidColorBrush(ColorExtensions.ColorFromUint(hex)); return element; }
        #endregion

        #region CalendarItemBorderBrush
        public static TElement CalendarItemBorderBrush<TElement>(this TElement element, Brush value) where TElement : ElementType
        { element.CalendarItemBorderBrush = value; return element; }

        public static TElement CalendarItemBorderBrush<TElement>(this TElement element, Color color) where TElement : ElementType
        { element.CalendarItemBorderBrush = new SolidColorBrush(color); return element; }

        public static TElement CalendarItemBorderBrush<TElement>(this TElement element, string color) where TElement : ElementType
        { element.CalendarItemBorderBrush = new SolidColorBrush(ColorExtensions.ColorFromString(color)); return element; }

        public static TElement CalendarItemBorderBrush<TElement>(this TElement element, uint hex) where TElement : ElementType
        { element.CalendarItemBorderBrush = new SolidColorBrush(ColorExtensions.ColorFromUint(hex)); return element; }
        #endregion

        public static TElement CalendarItemBorderThickness<TElement>(this TElement element, Thickness value) where TElement : ElementType
        { element.CalendarItemBorderThickness = value; return element; }

        public static TElement CalendarItemCornerRadius<TElement>(this TElement element, CornerRadius value) where TElement : ElementType
        { element.CalendarItemCornerRadius = value; return element; }

        #region CalendarItemDisabledBackground
        public static TElement CalendarItemDisabledBackground<TElement>(this TElement element, Brush value) where TElement : ElementType
        { element.CalendarItemDisabledBackground = value; return element; }

        public static TElement CalendarItemDisabledBackground<TElement>(this TElement element, Color color) where TElement : ElementType
        { element.CalendarItemDisabledBackground = new SolidColorBrush(color); return element; }

        public static TElement CalendarItemDisabledBackground<TElement>(this TElement element, string color) where TElement : ElementType
        { element.CalendarItemDisabledBackground = new SolidColorBrush(ColorExtensions.ColorFromString(color)); return element; }

        public static TElement CalendarItemDisabledBackground<TElement>(this TElement element, uint hex) where TElement : ElementType
        { element.CalendarItemDisabledBackground = new SolidColorBrush(ColorExtensions.ColorFromUint(hex)); return element; }
        #endregion

        #region CalendarItemForeground
        public static TElement CalendarItemForeground<TElement>(this TElement element, Brush value) where TElement : ElementType
        { element.CalendarItemForeground = value; return element; }

        public static TElement CalendarItemForeground<TElement>(this TElement element, Color color) where TElement : ElementType
        { element.CalendarItemForeground = new SolidColorBrush(color); return element; }

        public static TElement CalendarItemForeground<TElement>(this TElement element, string color) where TElement : ElementType
        { element.CalendarItemForeground = new SolidColorBrush(ColorExtensions.ColorFromString(color)); return element; }

        public static TElement CalendarItemForeground<TElement>(this TElement element, uint hex) where TElement : ElementType
        { element.CalendarItemForeground = new SolidColorBrush(ColorExtensions.ColorFromUint(hex)); return element; }
        #endregion

        #region CalendarItemHoverBackground
        public static TElement CalendarItemHoverBackground<TElement>(this TElement element, Brush value) where TElement : ElementType
        { element.CalendarItemHoverBackground = value; return element; }

        public static TElement CalendarItemHoverBackground<TElement>(this TElement element, Color color) where TElement : ElementType
        { element.CalendarItemHoverBackground = new SolidColorBrush(color); return element; }

        public static TElement CalendarItemHoverBackground<TElement>(this TElement element, string color) where TElement : ElementType
        { element.CalendarItemHoverBackground = new SolidColorBrush(ColorExtensions.ColorFromString(color)); return element; }

        public static TElement CalendarItemHoverBackground<TElement>(this TElement element, uint hex) where TElement : ElementType
        { element.CalendarItemHoverBackground = new SolidColorBrush(ColorExtensions.ColorFromUint(hex)); return element; }
        #endregion

        #region CalendarItemPressedBackground
        public static TElement CalendarItemPressedBackground<TElement>(this TElement element, Brush value) where TElement : ElementType
        { element.CalendarItemPressedBackground = value; return element; }

        public static TElement CalendarItemPressedBackground<TElement>(this TElement element, Color color) where TElement : ElementType
        { element.CalendarItemPressedBackground = new SolidColorBrush(color); return element; }

        public static TElement CalendarItemPressedBackground<TElement>(this TElement element, string color) where TElement : ElementType
        { element.CalendarItemPressedBackground = new SolidColorBrush(ColorExtensions.ColorFromString(color)); return element; }

        public static TElement CalendarItemPressedBackground<TElement>(this TElement element, uint hex) where TElement : ElementType
        { element.CalendarItemPressedBackground = new SolidColorBrush(ColorExtensions.ColorFromUint(hex)); return element; }
        #endregion

        public static TElement CalendarViewDayItemStyle<TElement>(this TElement element, Style value) where TElement : ElementType
        { element.CalendarViewDayItemStyle = value; return element; }

        #region DayItemFontFamily
        public static TElement DayItemFontFamily<TElement>(this TElement element, Microsoft.UI.Xaml.Media.FontFamily family) where TElement : ElementType
        { element.DayItemFontFamily = family; return element; }

        public static TElement DayItemFontFamily<TElement>(this TElement element, string family) where TElement : ElementType
        { element.DayItemFontFamily = new FontFamily(family); return element; }
        #endregion

        public static TElement DayItemFontSize<TElement>(this TElement element, double value) where TElement : ElementType
        { element.DayItemFontSize = value; return element; }

        public static TElement DayItemFontStyle<TElement>(this TElement element, FontStyle value) where TElement : ElementType
        { element.DayItemFontStyle = value; return element; }

        public static TElement DayItemFontWeight<TElement>(this TElement element, FontWeight value) where TElement : ElementType
        { element.DayItemFontWeight = value; return element; }

        public static TElement DayItemMargin<TElement>(this TElement element, Thickness value) where TElement : ElementType
        { element.DayItemMargin = value; return element; }

        public static TElement DayOfWeekFormat<TElement>(this TElement element, string value) where TElement : ElementType
        { element.DayOfWeekFormat = value; return element; }

        #region DisabledForeground
        public static TElement DisabledForeground<TElement>(this TElement element, Brush value) where TElement : ElementType
        { element.DisabledForeground = value; return element; }

        public static TElement DisabledForeground<TElement>(this TElement element, Color color) where TElement : ElementType
        { element.DisabledForeground = new SolidColorBrush(color); return element; }

        public static TElement DisabledForeground<TElement>(this TElement element, string color) where TElement : ElementType
        { element.DisabledForeground = new SolidColorBrush(ColorExtensions.ColorFromString(color)); return element; }

        public static TElement DisabledForeground<TElement>(this TElement element, uint hex) where TElement : ElementType
        { element.DisabledForeground = new SolidColorBrush(ColorExtensions.ColorFromUint(hex)); return element; }
        #endregion

        public static TElement DisplayMode<TElement>(this TElement element, CalendarViewDisplayMode value) where TElement : ElementType
        { element.DisplayMode = value; return element; }

        public static TElement FirstDayOfWeek<TElement>(this TElement element, Windows.Globalization.DayOfWeek value) where TElement : ElementType
        { element.FirstDayOfWeek = value; return element; }

        #region FirstOfMonthLabelFontFamily
        public static TElement FirstOfMonthLabelFontFamily<TElement>(this TElement element, Microsoft.UI.Xaml.Media.FontFamily family) where TElement : ElementType
        { element.FirstOfMonthLabelFontFamily = family; return element; }

        public static TElement FirstOfMonthLabelFontFamily<TElement>(this TElement element, string family) where TElement : ElementType
        { element.FirstOfMonthLabelFontFamily = new FontFamily(family); return element; }
        #endregion

        public static TElement FirstOfMonthLabelFontSize<TElement>(this TElement element, double value) where TElement : ElementType
        { element.FirstOfMonthLabelFontSize = value; return element; }

        public static TElement FirstOfMonthLabelFontStyle<TElement>(this TElement element, FontStyle value) where TElement : ElementType
        { element.FirstOfMonthLabelFontStyle = value; return element; }

        public static TElement FirstOfMonthLabelFontWeight<TElement>(this TElement element, FontWeight value) where TElement : ElementType
        { element.FirstOfMonthLabelFontWeight = value; return element; }

        public static TElement FirstOfMonthLabelMargin<TElement>(this TElement element, Thickness value) where TElement : ElementType
        { element.FirstOfMonthLabelMargin = value; return element; }

        #region FirstOfYearDecadeLabelFontFamily
        public static TElement FirstOfYearDecadeLabelFontFamily<TElement>(this TElement element, Microsoft.UI.Xaml.Media.FontFamily family) where TElement : ElementType
        { element.FirstOfYearDecadeLabelFontFamily = family; return element; }

        public static TElement FirstOfYearDecadeLabelFontFamily<TElement>(this TElement element, string family) where TElement : ElementType
        { element.FirstOfYearDecadeLabelFontFamily = new FontFamily(family); return element; }
        #endregion

        public static TElement FirstOfYearDecadeLabelFontSize<TElement>(this TElement element, double value) where TElement : ElementType
        { element.FirstOfYearDecadeLabelFontSize = value; return element; }

        public static TElement FirstOfYearDecadeLabelFontStyle<TElement>(this TElement element, FontStyle value) where TElement : ElementType
        { element.FirstOfYearDecadeLabelFontStyle = value; return element; }

        public static TElement FirstOfYearDecadeLabelFontWeight<TElement>(this TElement element, FontWeight value) where TElement : ElementType
        { element.FirstOfYearDecadeLabelFontWeight = value; return element; }

        public static TElement FirstOfYearDecadeLabelMargin<TElement>(this TElement element, Thickness value) where TElement : ElementType
        { element.FirstOfYearDecadeLabelMargin = value; return element; }

        #region FocusBorderBrush
        public static TElement FocusBorderBrush<TElement>(this TElement element, Brush value) where TElement : ElementType
        { element.FocusBorderBrush = value; return element; }

        public static TElement FocusBorderBrush<TElement>(this TElement element, Color color) where TElement : ElementType
        { element.FocusBorderBrush = new SolidColorBrush(color); return element; }

        public static TElement FocusBorderBrush<TElement>(this TElement element, string color) where TElement : ElementType
        { element.FocusBorderBrush = new SolidColorBrush(ColorExtensions.ColorFromString(color)); return element; }

        public static TElement FocusBorderBrush<TElement>(this TElement element, uint hex) where TElement : ElementType
        { element.FocusBorderBrush = new SolidColorBrush(ColorExtensions.ColorFromUint(hex)); return element; }
        #endregion

        public static TElement HorizontalDayItemAlignment<TElement>(this TElement element, HorizontalAlignment value) where TElement : ElementType
        { element.HorizontalDayItemAlignment = value; return element; }

        public static TElement HorizontalFirstOfMonthLabelAlignment<TElement>(this TElement element, HorizontalAlignment value) where TElement : ElementType
        { element.HorizontalFirstOfMonthLabelAlignment = value; return element; }

        #region HoverBorderBrush
        public static TElement HoverBorderBrush<TElement>(this TElement element, Brush value) where TElement : ElementType
        { element.HoverBorderBrush = value; return element; }

        public static TElement HoverBorderBrush<TElement>(this TElement element, Color color) where TElement : ElementType
        { element.HoverBorderBrush = new SolidColorBrush(color); return element; }

        public static TElement HoverBorderBrush<TElement>(this TElement element, string color) where TElement : ElementType
        { element.HoverBorderBrush = new SolidColorBrush(ColorExtensions.ColorFromString(color)); return element; }

        public static TElement HoverBorderBrush<TElement>(this TElement element, uint hex) where TElement : ElementType
        { element.HoverBorderBrush = new SolidColorBrush(ColorExtensions.ColorFromUint(hex)); return element; }
        #endregion

        public static TElement IsGroupLabelVisible<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsGroupLabelVisible = value; return element; }

        public static TElement IsOutOfScopeEnabled<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsOutOfScopeEnabled = value; return element; }

        public static TElement IsTodayHighlighted<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsTodayHighlighted = value; return element; }

        public static TElement MaxDate<TElement>(this TElement element, DateTimeOffset value) where TElement : ElementType
        { element.MaxDate = value; return element; }

        public static TElement MinDate<TElement>(this TElement element, DateTimeOffset value) where TElement : ElementType
        { element.MinDate = value; return element; }

        #region MonthYearItemFontFamily
        public static TElement MonthYearItemFontFamily<TElement>(this TElement element, Microsoft.UI.Xaml.Media.FontFamily family) where TElement : ElementType
        { element.MonthYearItemFontFamily = family; return element; }

        public static TElement MonthYearItemFontFamily<TElement>(this TElement element, string family) where TElement : ElementType
        { element.MonthYearItemFontFamily = new FontFamily(family); return element; }
        #endregion

        public static TElement MonthYearItemFontSize<TElement>(this TElement element, double value) where TElement : ElementType
        { element.MonthYearItemFontSize = value; return element; }

        public static TElement MonthYearItemFontStyle<TElement>(this TElement element, FontStyle value) where TElement : ElementType
        { element.MonthYearItemFontStyle = value; return element; }

        public static TElement MonthYearItemFontWeight<TElement>(this TElement element, FontWeight value) where TElement : ElementType
        { element.MonthYearItemFontWeight = value; return element; }

        public static TElement MonthYearItemMargin<TElement>(this TElement element, Thickness value) where TElement : ElementType
        { element.MonthYearItemMargin = value; return element; }

        public static TElement NumberOfWeeksInView<TElement>(this TElement element, int value) where TElement : ElementType
        { element.NumberOfWeeksInView = value; return element; }

        #region OutOfScopeBackground
        public static TElement OutOfScopeBackground<TElement>(this TElement element, Brush value) where TElement : ElementType
        { element.OutOfScopeBackground = value; return element; }

        public static TElement OutOfScopeBackground<TElement>(this TElement element, Color color) where TElement : ElementType
        { element.OutOfScopeBackground = new SolidColorBrush(color); return element; }

        public static TElement OutOfScopeBackground<TElement>(this TElement element, string color) where TElement : ElementType
        { element.OutOfScopeBackground = new SolidColorBrush(ColorExtensions.ColorFromString(color)); return element; }

        public static TElement OutOfScopeBackground<TElement>(this TElement element, uint hex) where TElement : ElementType
        { element.OutOfScopeBackground = new SolidColorBrush(ColorExtensions.ColorFromUint(hex)); return element; }
        #endregion

        #region OutOfScopeForeground
        public static TElement OutOfScopeForeground<TElement>(this TElement element, Brush value) where TElement : ElementType
        { element.OutOfScopeForeground = value; return element; }

        public static TElement OutOfScopeForeground<TElement>(this TElement element, Color color) where TElement : ElementType
        { element.OutOfScopeForeground = new SolidColorBrush(color); return element; }

        public static TElement OutOfScopeForeground<TElement>(this TElement element, string color) where TElement : ElementType
        { element.OutOfScopeForeground = new SolidColorBrush(ColorExtensions.ColorFromString(color)); return element; }

        public static TElement OutOfScopeForeground<TElement>(this TElement element, uint hex) where TElement : ElementType
        { element.OutOfScopeForeground = new SolidColorBrush(ColorExtensions.ColorFromUint(hex)); return element; }
        #endregion

        #region OutOfScopeHoverForeground
        public static TElement OutOfScopeHoverForeground<TElement>(this TElement element, Brush value) where TElement : ElementType
        { element.OutOfScopeHoverForeground = value; return element; }

        public static TElement OutOfScopeHoverForeground<TElement>(this TElement element, Color color) where TElement : ElementType
        { element.OutOfScopeHoverForeground = new SolidColorBrush(color); return element; }

        public static TElement OutOfScopeHoverForeground<TElement>(this TElement element, string color) where TElement : ElementType
        { element.OutOfScopeHoverForeground = new SolidColorBrush(ColorExtensions.ColorFromString(color)); return element; }

        public static TElement OutOfScopeHoverForeground<TElement>(this TElement element, uint hex) where TElement : ElementType
        { element.OutOfScopeHoverForeground = new SolidColorBrush(ColorExtensions.ColorFromUint(hex)); return element; }
        #endregion

        #region OutOfScopePressedForeground
        public static TElement OutOfScopePressedForeground<TElement>(this TElement element, Brush value) where TElement : ElementType
        { element.OutOfScopePressedForeground = value; return element; }

        public static TElement OutOfScopePressedForeground<TElement>(this TElement element, Color color) where TElement : ElementType
        { element.OutOfScopePressedForeground = new SolidColorBrush(color); return element; }

        public static TElement OutOfScopePressedForeground<TElement>(this TElement element, string color) where TElement : ElementType
        { element.OutOfScopePressedForeground = new SolidColorBrush(ColorExtensions.ColorFromString(color)); return element; }

        public static TElement OutOfScopePressedForeground<TElement>(this TElement element, uint hex) where TElement : ElementType
        { element.OutOfScopePressedForeground = new SolidColorBrush(ColorExtensions.ColorFromUint(hex)); return element; }
        #endregion

        #region PressedBorderBrush
        public static TElement PressedBorderBrush<TElement>(this TElement element, Brush value) where TElement : ElementType
        { element.PressedBorderBrush = value; return element; }

        public static TElement PressedBorderBrush<TElement>(this TElement element, Color color) where TElement : ElementType
        { element.PressedBorderBrush = new SolidColorBrush(color); return element; }

        public static TElement PressedBorderBrush<TElement>(this TElement element, string color) where TElement : ElementType
        { element.PressedBorderBrush = new SolidColorBrush(ColorExtensions.ColorFromString(color)); return element; }

        public static TElement PressedBorderBrush<TElement>(this TElement element, uint hex) where TElement : ElementType
        { element.PressedBorderBrush = new SolidColorBrush(ColorExtensions.ColorFromUint(hex)); return element; }
        #endregion

        #region SelectedBorderBrush
        public static TElement SelectedBorderBrush<TElement>(this TElement element, Brush value) where TElement : ElementType
        { element.SelectedBorderBrush = value; return element; }

        public static TElement SelectedBorderBrush<TElement>(this TElement element, Color color) where TElement : ElementType
        { element.SelectedBorderBrush = new SolidColorBrush(color); return element; }

        public static TElement SelectedBorderBrush<TElement>(this TElement element, string color) where TElement : ElementType
        { element.SelectedBorderBrush = new SolidColorBrush(ColorExtensions.ColorFromString(color)); return element; }

        public static TElement SelectedBorderBrush<TElement>(this TElement element, uint hex) where TElement : ElementType
        { element.SelectedBorderBrush = new SolidColorBrush(ColorExtensions.ColorFromUint(hex)); return element; }
        #endregion

        #region SelectedDisabledBorderBrush
        public static TElement SelectedDisabledBorderBrush<TElement>(this TElement element, Brush value) where TElement : ElementType
        { element.SelectedDisabledBorderBrush = value; return element; }

        public static TElement SelectedDisabledBorderBrush<TElement>(this TElement element, Color color) where TElement : ElementType
        { element.SelectedDisabledBorderBrush = new SolidColorBrush(color); return element; }

        public static TElement SelectedDisabledBorderBrush<TElement>(this TElement element, string color) where TElement : ElementType
        { element.SelectedDisabledBorderBrush = new SolidColorBrush(ColorExtensions.ColorFromString(color)); return element; }

        public static TElement SelectedDisabledBorderBrush<TElement>(this TElement element, uint hex) where TElement : ElementType
        { element.SelectedDisabledBorderBrush = new SolidColorBrush(ColorExtensions.ColorFromUint(hex)); return element; }
        #endregion

        #region SelectedDisabledForeground
        public static TElement SelectedDisabledForeground<TElement>(this TElement element, Brush value) where TElement : ElementType
        { element.SelectedDisabledForeground = value; return element; }

        public static TElement SelectedDisabledForeground<TElement>(this TElement element, Color color) where TElement : ElementType
        { element.SelectedDisabledForeground = new SolidColorBrush(color); return element; }

        public static TElement SelectedDisabledForeground<TElement>(this TElement element, string color) where TElement : ElementType
        { element.SelectedDisabledForeground = new SolidColorBrush(ColorExtensions.ColorFromString(color)); return element; }

        public static TElement SelectedDisabledForeground<TElement>(this TElement element, uint hex) where TElement : ElementType
        { element.SelectedDisabledForeground = new SolidColorBrush(ColorExtensions.ColorFromUint(hex)); return element; }
        #endregion

        #region SelectedForeground
        public static TElement SelectedForeground<TElement>(this TElement element, Brush value) where TElement : ElementType
        { element.SelectedForeground = value; return element; }

        public static TElement SelectedForeground<TElement>(this TElement element, Color color) where TElement : ElementType
        { element.SelectedForeground = new SolidColorBrush(color); return element; }

        public static TElement SelectedForeground<TElement>(this TElement element, string color) where TElement : ElementType
        { element.SelectedForeground = new SolidColorBrush(ColorExtensions.ColorFromString(color)); return element; }

        public static TElement SelectedForeground<TElement>(this TElement element, uint hex) where TElement : ElementType
        { element.SelectedForeground = new SolidColorBrush(ColorExtensions.ColorFromUint(hex)); return element; }
        #endregion

        #region SelectedHoverBorderBrush
        public static TElement SelectedHoverBorderBrush<TElement>(this TElement element, Brush value) where TElement : ElementType
        { element.SelectedHoverBorderBrush = value; return element; }

        public static TElement SelectedHoverBorderBrush<TElement>(this TElement element, Color color) where TElement : ElementType
        { element.SelectedHoverBorderBrush = new SolidColorBrush(color); return element; }

        public static TElement SelectedHoverBorderBrush<TElement>(this TElement element, string color) where TElement : ElementType
        { element.SelectedHoverBorderBrush = new SolidColorBrush(ColorExtensions.ColorFromString(color)); return element; }

        public static TElement SelectedHoverBorderBrush<TElement>(this TElement element, uint hex) where TElement : ElementType
        { element.SelectedHoverBorderBrush = new SolidColorBrush(ColorExtensions.ColorFromUint(hex)); return element; }
        #endregion

        #region SelectedHoverForeground
        public static TElement SelectedHoverForeground<TElement>(this TElement element, Brush value) where TElement : ElementType
        { element.SelectedHoverForeground = value; return element; }

        public static TElement SelectedHoverForeground<TElement>(this TElement element, Color color) where TElement : ElementType
        { element.SelectedHoverForeground = new SolidColorBrush(color); return element; }

        public static TElement SelectedHoverForeground<TElement>(this TElement element, string color) where TElement : ElementType
        { element.SelectedHoverForeground = new SolidColorBrush(ColorExtensions.ColorFromString(color)); return element; }

        public static TElement SelectedHoverForeground<TElement>(this TElement element, uint hex) where TElement : ElementType
        { element.SelectedHoverForeground = new SolidColorBrush(ColorExtensions.ColorFromUint(hex)); return element; }
        #endregion

        #region SelectedPressedBorderBrush
        public static TElement SelectedPressedBorderBrush<TElement>(this TElement element, Brush value) where TElement : ElementType
        { element.SelectedPressedBorderBrush = value; return element; }

        public static TElement SelectedPressedBorderBrush<TElement>(this TElement element, Color color) where TElement : ElementType
        { element.SelectedPressedBorderBrush = new SolidColorBrush(color); return element; }

        public static TElement SelectedPressedBorderBrush<TElement>(this TElement element, string color) where TElement : ElementType
        { element.SelectedPressedBorderBrush = new SolidColorBrush(ColorExtensions.ColorFromString(color)); return element; }

        public static TElement SelectedPressedBorderBrush<TElement>(this TElement element, uint hex) where TElement : ElementType
        { element.SelectedPressedBorderBrush = new SolidColorBrush(ColorExtensions.ColorFromUint(hex)); return element; }
        #endregion

        #region SelectedPressedForeground
        public static TElement SelectedPressedForeground<TElement>(this TElement element, Brush value) where TElement : ElementType
        { element.SelectedPressedForeground = value; return element; }

        public static TElement SelectedPressedForeground<TElement>(this TElement element, Color color) where TElement : ElementType
        { element.SelectedPressedForeground = new SolidColorBrush(color); return element; }

        public static TElement SelectedPressedForeground<TElement>(this TElement element, string color) where TElement : ElementType
        { element.SelectedPressedForeground = new SolidColorBrush(ColorExtensions.ColorFromString(color)); return element; }

        public static TElement SelectedPressedForeground<TElement>(this TElement element, uint hex) where TElement : ElementType
        { element.SelectedPressedForeground = new SolidColorBrush(ColorExtensions.ColorFromUint(hex)); return element; }
        #endregion

        public static TElement SelectionMode<TElement>(this TElement element, CalendarViewSelectionMode value) where TElement : ElementType
        { element.SelectionMode = value; return element; }

        #region TodayBackground
        public static TElement TodayBackground<TElement>(this TElement element, Brush value) where TElement : ElementType
        { element.TodayBackground = value; return element; }

        public static TElement TodayBackground<TElement>(this TElement element, Color color) where TElement : ElementType
        { element.TodayBackground = new SolidColorBrush(color); return element; }

        public static TElement TodayBackground<TElement>(this TElement element, string color) where TElement : ElementType
        { element.TodayBackground = new SolidColorBrush(ColorExtensions.ColorFromString(color)); return element; }

        public static TElement TodayBackground<TElement>(this TElement element, uint hex) where TElement : ElementType
        { element.TodayBackground = new SolidColorBrush(ColorExtensions.ColorFromUint(hex)); return element; }
        #endregion

        #region TodayBlackoutBackground
        public static TElement TodayBlackoutBackground<TElement>(this TElement element, Brush value) where TElement : ElementType
        { element.TodayBlackoutBackground = value; return element; }

        public static TElement TodayBlackoutBackground<TElement>(this TElement element, Color color) where TElement : ElementType
        { element.TodayBlackoutBackground = new SolidColorBrush(color); return element; }

        public static TElement TodayBlackoutBackground<TElement>(this TElement element, string color) where TElement : ElementType
        { element.TodayBlackoutBackground = new SolidColorBrush(ColorExtensions.ColorFromString(color)); return element; }

        public static TElement TodayBlackoutBackground<TElement>(this TElement element, uint hex) where TElement : ElementType
        { element.TodayBlackoutBackground = new SolidColorBrush(ColorExtensions.ColorFromUint(hex)); return element; }
        #endregion

        #region TodayBlackoutForeground
        public static TElement TodayBlackoutForeground<TElement>(this TElement element, Brush value) where TElement : ElementType
        { element.TodayBlackoutForeground = value; return element; }

        public static TElement TodayBlackoutForeground<TElement>(this TElement element, Color color) where TElement : ElementType
        { element.TodayBlackoutForeground = new SolidColorBrush(color); return element; }

        public static TElement TodayBlackoutForeground<TElement>(this TElement element, string color) where TElement : ElementType
        { element.TodayBlackoutForeground = new SolidColorBrush(ColorExtensions.ColorFromString(color)); return element; }

        public static TElement TodayBlackoutForeground<TElement>(this TElement element, uint hex) where TElement : ElementType
        { element.TodayBlackoutForeground = new SolidColorBrush(ColorExtensions.ColorFromUint(hex)); return element; }
        #endregion

        #region TodayDisabledBackground
        public static TElement TodayDisabledBackground<TElement>(this TElement element, Brush value) where TElement : ElementType
        { element.TodayDisabledBackground = value; return element; }

        public static TElement TodayDisabledBackground<TElement>(this TElement element, Color color) where TElement : ElementType
        { element.TodayDisabledBackground = new SolidColorBrush(color); return element; }

        public static TElement TodayDisabledBackground<TElement>(this TElement element, string color) where TElement : ElementType
        { element.TodayDisabledBackground = new SolidColorBrush(ColorExtensions.ColorFromString(color)); return element; }

        public static TElement TodayDisabledBackground<TElement>(this TElement element, uint hex) where TElement : ElementType
        { element.TodayDisabledBackground = new SolidColorBrush(ColorExtensions.ColorFromUint(hex)); return element; }
        #endregion

        public static TElement TodayFontWeight<TElement>(this TElement element, FontWeight value) where TElement : ElementType
        { element.TodayFontWeight = value; return element; }

        #region TodayForeground
        public static TElement TodayForeground<TElement>(this TElement element, Brush value) where TElement : ElementType
        { element.TodayForeground = value; return element; }

        public static TElement TodayForeground<TElement>(this TElement element, Color color) where TElement : ElementType
        { element.TodayForeground = new SolidColorBrush(color); return element; }

        public static TElement TodayForeground<TElement>(this TElement element, string color) where TElement : ElementType
        { element.TodayForeground = new SolidColorBrush(ColorExtensions.ColorFromString(color)); return element; }

        public static TElement TodayForeground<TElement>(this TElement element, uint hex) where TElement : ElementType
        { element.TodayForeground = new SolidColorBrush(ColorExtensions.ColorFromUint(hex)); return element; }
        #endregion

        #region TodayHoverBackground
        public static TElement TodayHoverBackground<TElement>(this TElement element, Brush value) where TElement : ElementType
        { element.TodayHoverBackground = value; return element; }

        public static TElement TodayHoverBackground<TElement>(this TElement element, Color color) where TElement : ElementType
        { element.TodayHoverBackground = new SolidColorBrush(color); return element; }

        public static TElement TodayHoverBackground<TElement>(this TElement element, string color) where TElement : ElementType
        { element.TodayHoverBackground = new SolidColorBrush(ColorExtensions.ColorFromString(color)); return element; }

        public static TElement TodayHoverBackground<TElement>(this TElement element, uint hex) where TElement : ElementType
        { element.TodayHoverBackground = new SolidColorBrush(ColorExtensions.ColorFromUint(hex)); return element; }
        #endregion

        #region TodayPressedBackground
        public static TElement TodayPressedBackground<TElement>(this TElement element, Brush value) where TElement : ElementType
        { element.TodayPressedBackground = value; return element; }

        public static TElement TodayPressedBackground<TElement>(this TElement element, Color color) where TElement : ElementType
        { element.TodayPressedBackground = new SolidColorBrush(color); return element; }

        public static TElement TodayPressedBackground<TElement>(this TElement element, string color) where TElement : ElementType
        { element.TodayPressedBackground = new SolidColorBrush(ColorExtensions.ColorFromString(color)); return element; }

        public static TElement TodayPressedBackground<TElement>(this TElement element, uint hex) where TElement : ElementType
        { element.TodayPressedBackground = new SolidColorBrush(ColorExtensions.ColorFromUint(hex)); return element; }
        #endregion

        #region TodaySelectedInnerBorderBrush
        public static TElement TodaySelectedInnerBorderBrush<TElement>(this TElement element, Brush value) where TElement : ElementType
        { element.TodaySelectedInnerBorderBrush = value; return element; }

        public static TElement TodaySelectedInnerBorderBrush<TElement>(this TElement element, Color color) where TElement : ElementType
        { element.TodaySelectedInnerBorderBrush = new SolidColorBrush(color); return element; }

        public static TElement TodaySelectedInnerBorderBrush<TElement>(this TElement element, string color) where TElement : ElementType
        { element.TodaySelectedInnerBorderBrush = new SolidColorBrush(ColorExtensions.ColorFromString(color)); return element; }

        public static TElement TodaySelectedInnerBorderBrush<TElement>(this TElement element, uint hex) where TElement : ElementType
        { element.TodaySelectedInnerBorderBrush = new SolidColorBrush(ColorExtensions.ColorFromUint(hex)); return element; }
        #endregion

        public static TElement VerticalDayItemAlignment<TElement>(this TElement element, VerticalAlignment value) where TElement : ElementType
        { element.VerticalDayItemAlignment = value; return element; }

        public static TElement VerticalFirstOfMonthLabelAlignment<TElement>(this TElement element, VerticalAlignment value) where TElement : ElementType
        { element.VerticalFirstOfMonthLabelAlignment = value; return element; }

        #endregion


        #region Events
        public static TElement AddCalendarViewDayItemChangingHandler<TElement>(this TElement element, TypedEventHandler<CalendarView, CalendarViewDayItemChangingEventArgs> handler) where TElement : ElementType
        { element.CalendarViewDayItemChanging += handler; return element; }

        public static TElement AddSelectedDatesChangedHandler<TElement>(this TElement element, TypedEventHandler<CalendarView, CalendarViewSelectedDatesChangedEventArgs> handler) where TElement : ElementType
        { element.SelectedDatesChanged += handler; return element; }

        #endregion
    }
}
