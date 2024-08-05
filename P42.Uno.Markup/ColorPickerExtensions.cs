using Windows.Foundation;
using Microsoft.UI.Xaml.Controls;
using ElementType = Microsoft.UI.Xaml.Controls.ColorPicker;
using Windows.UI;

namespace P42.Uno.Markup
{
    public static class ColorPickerExtensions
    {
        #region Properties
        public static TElement Color<TElement>(this TElement element, Color value) where TElement : ElementType
        { element.Color = value; return element; }

        public static TElement ColorSpectrumComponents<TElement>(this TElement element, ColorSpectrumComponents value) where TElement : ElementType
        { element.ColorSpectrumComponents = value; return element; }

        public static TElement ColorSpectrumShape<TElement>(this TElement element, ColorSpectrumShape value) where TElement : ElementType
        { element.ColorSpectrumShape = value; return element; }

        public static TElement IsAlphaEnabled<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsAlphaEnabled = value; return element; }

        public static TElement IsAlphaSliderVisible<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsAlphaSliderVisible = value; return element; }

        public static TElement IsAlphaTextInputVisible<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsAlphaTextInputVisible = value; return element; }

        public static TElement IsColorChannelTextInputVisible<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsColorChannelTextInputVisible = value; return element; }

        public static TElement IsColorPreviewVisible<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsColorPreviewVisible = value; return element; }

        public static TElement IsColorSliderVisible<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsColorSliderVisible = value; return element; }

        public static TElement IsColorSpectrumVisible<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsColorSpectrumVisible = value; return element; }

        public static TElement IsHexInputVisible<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsHexInputVisible = value; return element; }

        public static TElement IsMoreButtonVisible<TElement>(this TElement element, bool value = true) where TElement : ElementType
        { element.IsMoreButtonVisible = value; return element; }

        public static TElement MaxHue<TElement>(this TElement element, int value) where TElement : ElementType
        { element.MaxHue = value; return element; }

        public static TElement MaxSaturation<TElement>(this TElement element, int value) where TElement : ElementType
        { element.MaxSaturation = value; return element; }

        public static TElement MaxValue<TElement>(this TElement element, int value) where TElement : ElementType
        { element.MaxValue = value; return element; }

        public static TElement MinHue<TElement>(this TElement element, int value) where TElement : ElementType
        { element.MinHue = value; return element; }

        public static TElement MinSaturation<TElement>(this TElement element, int value) where TElement : ElementType
        { element.MinSaturation = value; return element; }

        public static TElement MinValue<TElement>(this TElement element, int value) where TElement : ElementType
        { element.MinValue = value; return element; }

        public static TElement PreviousColor<TElement>(this TElement element, Color? value) where TElement : ElementType
        { element.PreviousColor = value; return element; }
        #endregion

        #region Events
        public static TElement ColorChanged<TElement>(this TElement element, TypedEventHandler<ColorPicker, ColorChangedEventArgs> handler) where TElement : ElementType
        { element.ColorChanged += handler; return element; }


        #endregion
    }
}
