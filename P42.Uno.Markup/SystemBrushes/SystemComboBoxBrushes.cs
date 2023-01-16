using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Microsoft.UI.Xaml.Media;

namespace P42.Uno.Markup
{
    // Full list of system brushes found here: https://github.com/MicrosoftDocs/windows-uwp/issues/2072
    public static class SystemComboBoxBrushes
    {
        public static Brush ArrowDisabledForeground => ColorExtensions.AppBrush("ComboBoxArrowDisabledForegroundThemeBrush");
        public static Brush ArrowForeground => ColorExtensions.AppBrush("ComboBoxArrowForegroundThemeBrush");
        public static Brush ArrowPressedForeground => ColorExtensions.AppBrush("ComboBoxArrowPressedForegroundThemeBrush");
        //public static Brush Background => ColorExtensions.AppBrush("ComboBoxBackgroundThemeBrush");
        public static Brush Border => ColorExtensions.AppBrush("ComboBoxBorderThemeBrush");
        public static Brush DisabledBackground => ColorExtensions.AppBrush("ComboBoxDisabledBackgroundThemeBrush");
        public static Brush DisabledBorder => ColorExtensions.AppBrush("ComboBoxDisabledBorderThemeBrush");
        public static Brush DisabledForeground => ColorExtensions.AppBrush("ComboBoxDisabledForegroundThemeBrush");
        public static Brush FocusedBackground => ColorExtensions.AppBrush("ComboBoxFocusedBackgroundThemeBrush");
        public static Brush FocusedBorder => ColorExtensions.AppBrush("ComboBoxFocusedBorderThemeBrush");
        public static Brush FocusedForeground => ColorExtensions.AppBrush("ComboBoxFocusedForegroundThemeBrush");
        //public static Brush Foreground => ColorExtensions.AppBrush("ComboBoxForegroundThemeBrush");
        public static Brush HeaderForeground => ColorExtensions.AppBrush("ComboBoxHeaderForegroundThemeBrush");
        public static Brush ItemDisabledForeground => ColorExtensions.AppBrush("ComboBoxItemDisabledForegroundThemeBrush");
        public static Brush ItemPointerOverBackground => ColorExtensions.AppBrush("ComboBoxItemPointerOverBackgroundThemeBrush");
        public static Brush ItemPointerOverForeground => ColorExtensions.AppBrush("ComboBoxItemPointerOverForegroundThemeBrush");
        public static Brush ItemPressedBackground => ColorExtensions.AppBrush("ComboBoxItemPressedBackgroundThemeBrush");
        public static Brush ItemPressedForeground => ColorExtensions.AppBrush("ComboBoxItemPressedForegroundThemeBrush");
        public static Brush ItemSelectedBackground => ColorExtensions.AppBrush("ComboBoxItemSelectedBackgroundThemeBrush");
        public static Brush ItemSelectedDisabledBackground => ColorExtensions.AppBrush("ComboBoxItemSelectedDisabledBackgroundThemeBrush");
        public static Brush ItemSelectedDisabledForeground => ColorExtensions.AppBrush("ComboBoxItemSelectedDisabledForegroundThemeBrush");
        public static Brush ItemSelectedForeground => ColorExtensions.AppBrush("ComboBoxItemSelectedForegroundThemeBrush");
        public static Brush ItemSelectedPointerOverBackground => ColorExtensions.AppBrush("ComboBoxItemSelectedPointerOverBackgroundThemeBrush");
        public static Brush PlaceholderTextForeground => ColorExtensions.AppBrush("ComboBoxPlaceholderTextForegroundThemeBrush");
        public static Brush PointerOverBackground => ColorExtensions.AppBrush("ComboBoxPointerOverBackgroundThemeBrush");
        public static Brush PointerOverBorder => ColorExtensions.AppBrush("ComboBoxPointerOverBorderThemeBrush");
        public static Brush PopupBackground => ColorExtensions.AppBrush("ComboBoxPopupBackgroundThemeBrush");
        public static Brush PopupBorder => ColorExtensions.AppBrush("ComboBoxPopupBorderThemeBrush");
        public static Brush PopupForeground => ColorExtensions.AppBrush("ComboBoxPopupForegroundThemeBrush");
        public static Brush PressedBackground => ColorExtensions.AppBrush("ComboBoxPressedBackgroundThemeBrush");
        public static Brush PressedBorder => ColorExtensions.AppBrush("ComboBoxPressedBorderThemeBrush");
        public static Brush PressedHighlight => ColorExtensions.AppBrush("ComboBoxPressedHighlightThemeBrush");
        public static Brush PressedForeground => ColorExtensions.AppBrush("ComboBoxPressedForegroundThemeBrush");
        public static Brush SelectedBackground => ColorExtensions.AppBrush("ComboBoxSelectedBackgroundThemeBrush");
        public static Brush SelectedPointerOverBackground => ColorExtensions.AppBrush("ComboBoxSelectedPointerOverBackgroundThemeBrush");

        public static Brush ItemForeground => ColorExtensions.AppBrush("ComboBoxItemForeground");
        public static Brush ItemForegroundPressed => ColorExtensions.AppBrush("ComboBoxItemForegroundPressed");
        public static Brush ItemForegroundPointerOver => ColorExtensions.AppBrush("ComboBoxItemForegroundPointerOver");
        public static Brush ItemForegroundDisabled => ColorExtensions.AppBrush("ComboBoxItemForegroundDisabled");
        public static Brush ItemForegroundSelected => ColorExtensions.AppBrush("ComboBoxItemForegroundSelected");
        public static Brush ItemForegroundSelectedUnfocused => ColorExtensions.AppBrush("ComboBoxItemForegroundSelectedUnfocused");
        public static Brush ItemForegroundSelectedPressed => ColorExtensions.AppBrush("ComboBoxItemForegroundSelectedPressed");
        public static Brush ItemForegroundSelectedPointerOver => ColorExtensions.AppBrush("ComboBoxItemForegroundSelectedPointerOver");
        public static Brush ItemForegroundSelectedDisabled => ColorExtensions.AppBrush("ComboBoxItemForegroundSelectedDisabled");
        public static Brush ItemBackground => ColorExtensions.AppBrush("ComboBoxItemBackground");
        public static Brush ItemBackgroundPressed => ColorExtensions.AppBrush("ComboBoxItemBackgroundPressed");
        public static Brush ItemBackgroundPointerOver => ColorExtensions.AppBrush("ComboBoxItemBackgroundPointerOver");
        public static Brush ItemBackgroundDisabled => ColorExtensions.AppBrush("ComboBoxItemBackgroundDisabled");
        public static Brush ItemBackgroundSelected => ColorExtensions.AppBrush("ComboBoxItemBackgroundSelected");
        public static Brush ItemBackgroundSelectedUnfocused => ColorExtensions.AppBrush("ComboBoxItemBackgroundSelectedUnfocused");
        public static Brush ItemBackgroundSelectedPressed => ColorExtensions.AppBrush("ComboBoxItemBackgroundSelectedPressed");
        public static Brush ItemBackgroundSelectedPointerOver => ColorExtensions.AppBrush("ComboBoxItemBackgroundSelectedPointerOver");
        public static Brush ItemBackgroundSelectedDisabled => ColorExtensions.AppBrush("ComboBoxItemBackgroundSelectedDisabled");
        public static Brush ItemBorderBrush => ColorExtensions.AppBrush("ComboBoxItemBorderBrush");
        public static Brush ItemBorderBrushPressed => ColorExtensions.AppBrush("ComboBoxItemBorderBrushPressed");
        public static Brush ItemBorderBrushPointerOver => ColorExtensions.AppBrush("ComboBoxItemBorderBrushPointerOver");
        public static Brush ItemBorderBrushDisabled => ColorExtensions.AppBrush("ComboBoxItemBorderBrushDisabled");
        public static Brush ItemBorderBrushSelected => ColorExtensions.AppBrush("ComboBoxItemBorderBrushSelected");
        public static Brush ItemBorderBrushSelectedUnfocused => ColorExtensions.AppBrush("ComboBoxItemBorderBrushSelectedUnfocused");
        public static Brush ItemBorderBrushSelectedPressed => ColorExtensions.AppBrush("ComboBoxItemBorderBrushSelectedPressed");
        public static Brush ItemBorderBrushSelectedPointerOver => ColorExtensions.AppBrush("ComboBoxItemBorderBrushSelectedPointerOver");
        public static Brush ItemBorderBrushSelectedDisabled => ColorExtensions.AppBrush("ComboBoxItemBorderBrushSelectedDisabled");
        public static Brush Background => ColorExtensions.AppBrush("ComboBoxBackground");
        public static Brush BackgroundPointerOver => ColorExtensions.AppBrush("ComboBoxBackgroundPointerOver");
        public static Brush BackgroundPressed => ColorExtensions.AppBrush("ComboBoxBackgroundPressed");
        public static Brush BackgroundDisabled => ColorExtensions.AppBrush("ComboBoxBackgroundDisabled");
        public static Brush BackgroundUnfocused => ColorExtensions.AppBrush("ComboBoxBackgroundUnfocused");
        public static Brush BackgroundBorderBrushFocused => ColorExtensions.AppBrush("ComboBoxBackgroundBorderBrushFocused");
        public static Brush BackgroundBorderBrushUnfocused => ColorExtensions.AppBrush("ComboBoxBackgroundBorderBrushUnfocused");
        public static Brush Foreground => ColorExtensions.AppBrush("ComboBoxForeground");
        public static Brush ForegroundDisabled => ColorExtensions.AppBrush("ComboBoxForegroundDisabled");
        public static Brush ForegroundFocused => ColorExtensions.AppBrush("ComboBoxForegroundFocused");
        public static Brush ForegroundFocusedPressed => ColorExtensions.AppBrush("ComboBoxForegroundFocusedPressed");
        public static Brush PlaceHolderForeground => ColorExtensions.AppBrush("ComboBoxPlaceHolderForeground");
        public static Brush PlaceHolderForegroundFocusedPressed => ColorExtensions.AppBrush("ComboBoxPlaceHolderForegroundFocusedPressed");
        public static Brush BorderBrush => ColorExtensions.AppBrush("ComboBoxBorderBrush");
        public static Brush BorderBrushPointerOver => ColorExtensions.AppBrush("ComboBoxBorderBrushPointerOver");
        public static Brush BorderBrushPressed => ColorExtensions.AppBrush("ComboBoxBorderBrushPressed");
        public static Brush BorderBrushDisabled => ColorExtensions.AppBrush("ComboBoxBorderBrushDisabled");
        public static Brush DropDownBackgroundPointerOver => ColorExtensions.AppBrush("ComboBoxDropDownBackgroundPointerOver");
        public static Brush DropDownBackgroundPointerPressed => ColorExtensions.AppBrush("ComboBoxDropDownBackgroundPointerPressed");
        public static Brush FocusedDropDownBackgroundPointerOver => ColorExtensions.AppBrush("ComboBoxFocusedDropDownBackgroundPointerOver");
        public static Brush FocusedDropDownBackgroundPointerPressed => ColorExtensions.AppBrush("ComboBoxFocusedDropDownBackgroundPointerPressed");
        public static Brush DropDownGlyphForeground => ColorExtensions.AppBrush("ComboBoxDropDownGlyphForeground");
        public static Brush EditableDropDownGlyphForeground => ColorExtensions.AppBrush("ComboBoxEditableDropDownGlyphForeground");
        public static Brush DropDownGlyphForegroundDisabled => ColorExtensions.AppBrush("ComboBoxDropDownGlyphForegroundDisabled");
        public static Brush DropDownGlyphForegroundFocused => ColorExtensions.AppBrush("ComboBoxDropDownGlyphForegroundFocused");
        public static Brush DropDownGlyphForegroundFocusedPressed => ColorExtensions.AppBrush("ComboBoxDropDownGlyphForegroundFocusedPressed");
        public static Brush DropDownBackground => ColorExtensions.AppBrush("ComboBoxDropDownBackground");
        public static Brush DropDownForeground => ColorExtensions.AppBrush("ComboBoxDropDownForeground");
        public static Brush DropDownBorderBrush => ColorExtensions.AppBrush("ComboBoxDropDownBorderBrush");
    }
}