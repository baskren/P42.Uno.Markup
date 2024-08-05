using Windows.UI;

namespace P42.Uno.Markup
{
    // XAML theme resources
    // The XAML color ramp and theme-dependent brushes
    // Light and Dark theme colors
    // https://docstaging.z5.web.core.windows.net/aleader/toolkit-7/design/controls-and-patterns/xaml-theme-resources.html#the-xaml-color-ramp-and-theme-dependent-brushes
    public static class SystemColors
    {
        #region Custom
        public static Color ListViewHeaderBackgroundColor
        {
            get
            {
                if (BaseHigh.R == 0)
                    return Color.FromArgb(0xFF, 0x99, 0x99, 0x99);
                return Color.FromArgb(0xFF, 0x66, 0x66, 0x66);
            }
        }

        public static Color ListViewCellBackgroundColor
            => AltHigh;

        public static Color PageBackgroundColor
            => AltHigh;
        #endregion


        #region ALT
        /// <summary>
        /// Light: FFFFFFFF  Dark: FF000000
        /// </summary>
        public static Color AltHigh
            => ColorExtensions.AppColor("SystemAltHighColor");
        /// <summary>
        /// Light: 33FFFFFF  Dark: 33000000
        /// </summary>
        public static Color AltLow
            => ColorExtensions.AppColor("SystemAltLowColor");
        /// <summary>
        /// Light: 99FFFFFF  Dark: 99000000
        /// </summary>
        public static Color AltMedium
            => ColorExtensions.AppColor("SystemAltMediumColor");
        /// <summary>
        /// Light: CCFFFFFF  Dark: CC000000
        /// </summary>
        public static Color AltMediumHigh
            => ColorExtensions.AppColor("SystemAltMediumHighColor");
        /// <summary>
        /// Light: 66FFFFFF  Dark: 66000000
        /// </summary>
        public static Color AltMediumLow 
            => ColorExtensions.AppColor("SystemAltMediumLowColor");
        #endregion


        #region BASE
        /// <summary>
        /// Light: FF000000  Dark FFFFFFFF
        /// </summary>
        public static Color BaseHigh 
            => ColorExtensions.AppColor("SystemBaseHighColor");
        /// <summary>
        /// Light: 33000000  Dark: 33FFFFFF
        /// </summary>
        public static Color BaseLow 
            => ColorExtensions.AppColor("SystemBaseLowColor");
        /// <summary>
        /// Light: 99000000  Dark: 99FFFFFF
        /// </summary>
        public static Color BaseMedium 
            => ColorExtensions.AppColor("SystemBaseMediumColor");
        /// <summary>
        /// Light: CC000000  Dark: CCFFFFFF
        /// </summary>
        public static Color BaseMediumHigh 
            => ColorExtensions.AppColor("SystemBaseMediumHighColor");
        /// <summary>
        /// Light: 66000000  Dark: 66FFFFFF
        /// </summary>
        public static Color BaseMediumLow 
            => ColorExtensions.AppColor("SystemBaseMediumLowColor");
        #endregion


        #region Chrome
        /// <summary>
        /// Light: FF171717  Dark: FFF2F2F2
        /// </summary>
        public static Color ChromeAltLow 
            => ColorExtensions.AppColor("SystemChromeAltLowColor");

        /// <summary>
        /// Light: FF000000  Dark: FF000000
        /// </summary>
        public static Color ChromeBlackHigh
            => ColorExtensions.AppColor("SystemChromeBlackHighColor");
        /// <summary>
        /// Light: CC000000  Dark: CC000000
        /// </summary>
        public static Color ChromeBlackMedium
            => ColorExtensions.AppColor("SystemChromeBlackMediumColor");
        /// <summary>
        /// Light: 66000000  Dark: 66000000
        /// </summary>
        public static Color ChromeBlackMediumLow
            => ColorExtensions.AppColor("SystemChromeBlackMediumLowColor");
        /// <summary>
        /// Light: 33000000  Dark: 33000000
        /// </summary>
        public static Color ChromeBlackLow 
            => ColorExtensions.AppColor("SystemChromeBlackLowColor");

        /// <summary>
        /// Light: FFCCCCCC  Dark: FF333333
        /// </summary>
        public static Color ChromeDisabledHigh
            => ColorExtensions.AppColor("SystemChromeDisabledHighColor");
        /// <summary>
        /// Light: FF7A7A7A  Dark: FF858585
        /// </summary>
        public static Color ChromeDisabledLow 
            => ColorExtensions.AppColor("SystemChromeDisabledLowColor");

        /// <summary>
        /// Light: FF767676  Dark: FF767676
        /// </summary>
        public static Color ChromeGray
            => ColorExtensions.AppColor("SystemChromeGrayColor");

        /// <summary>
        /// Light: FFCCCCCC  Dark: FF767676
        /// </summary>
        public static Color ChromeHigh
            => ColorExtensions.AppColor("SystemChromeHighColor");
        /// <summary>
        /// Light: FFE6E6E6  Dark: FF1F1F1F
        /// </summary>
        public static Color ChromeMedium
            => ColorExtensions.AppColor("SystemChromeMediumColor");
        /// <summary>
        /// Light: FFF2F2F2  Dark: FF2B2B2B
        /// </summary>
        public static Color ChromeMediumLow
            => ColorExtensions.AppColor("SystemChromeMediumLowColor");
        /// <summary>
        /// Light: FFF2F2F2  Dark: FF171717
        /// </summary>
        public static Color ChromeLow 
            => ColorExtensions.AppColor("SystemChromeLowColor");

        /// <summary>
        /// Light: FFFFFFFF  Dark: FFFFFFFF
        /// </summary>
        public static Color ChromeWhite
            => ColorExtensions.AppColor("SystemChromeWhiteColor");

        #endregion


        #region List
        /// <summary>
        /// Light: 19000000  Dark: 19FFFFFF
        /// </summary>
        public static Color ListLow 
            => ColorExtensions.AppColor("SystemListLowColor");
        /// <summary>
        /// Light: 33000000  Dark: 33FFFFFF
        /// </summary>
        public static Color ListMedium 
            => ColorExtensions.AppColor("SystemListMediumColor");
        /// <summary>
        /// Light: 660078D4  Dark: 660078D4
        /// </summary>
        public static Color ListAccentLow
            => ColorExtensions.AppColor("SystemListAccentLowColor");
        /// <summary>
        /// Light: 990078D4  Dark: 990078D4
        /// </summary>
        public static Color ListAccentMedium
            => ColorExtensions.AppColor("SystemListAccentMediumColor");
        /// <summary>
        /// Light: B20078D4  Dark: B20078D4
        /// </summary>
        public static Color ListAccentHigh
            => ColorExtensions.AppColor("SystemListAccentHighColor");
        #endregion


        #region Button
        /// <summary>
        /// Light: FFF0F0F0  Dark: FFF0F0F0
        /// </summary>
        public static Color ButtonFace 
            => ColorExtensions.AppColor("SystemColorButtonFaceColor");
        /// <summary>
        /// Light: FF000000  Dark: FF000000
        /// </summary>
        public static Color ButtonText 
            => ColorExtensions.AppColor("SystemColorButtonTextColor");
        #endregion


        #region Text
        /// <summary>
        /// Light: FF6D6D6D  Dark: FF6D6D6D
        /// </summary>
        public static Color GrayText 
            => ColorExtensions.AppColor("SystemColorGrayTextColor");

        //public static Color ErrorText 
        //    => ColorExtensions.AppColor("ErrorText");
        #endregion


        #region HighLight
        /// <summary>
        /// Light: FF0078D7  Dark: FF0078D7
        /// </summary>
        public static Color Highlight 
            => ColorExtensions.AppColor("SystemColorHighlightColor");
        /// <summary>
        /// Light: FFFFFFFF  Dark: FFFFFFFF
        /// </summary>
        public static Color HighlightText 
            => ColorExtensions.AppColor("SystemColorHighlightTextColor");
        #endregion


        #region HotLight
        /// <summary>
        /// Light: FF0066CC  Dark: FF0066CC
        /// </summary>
        public static Color Hotlight 
            => ColorExtensions.AppColor("SystemColorHotlightColor");
        #endregion


        #region Window
        /// <summary>
        /// Light: FFFFFFFF  Dark: FFFFFFFF
        /// </summary>
        public static Color WindowColor 
            => ColorExtensions.AppColor("SystemColorWindowColor");
        /// <summary>
        /// Light: FF000000  Dark: FF000000
        /// </summary>
        public static Color WindowTextColor 
            => ColorExtensions.AppColor("SystemColorWindowTextColor");
        #endregion


        #region Accent
        /// <summary>
        /// Light: FF267244  Dark: FF267244
        /// </summary>
        public static Color Accent 
            => ColorExtensions.AppColor("SystemAccentColor");
        /// <summary>
        /// Light: FF99EBFF  Dark: FF99EBFF
        /// </summary>
        public static Color AccentLight3
            => ColorExtensions.AppColor("SystemAccentColorLight3");
        /// <summary>
        /// Light: FF4CC2FF  Dark: FF4CC2FF
        /// </summary>
        public static Color AccentLight2
            => ColorExtensions.AppColor("SystemAccentColorLight2");
        /// <summary>
        /// Light: FF0091F8  Dark: FF0091F8
        /// </summary>
        public static Color AccentLight1
            => ColorExtensions.AppColor("SystemAccentColorLight1");
        /// <summary>
        /// Light: FF0067C0  Dark: FF0067C0
        /// </summary>
        public static Color AccentDark1
            => ColorExtensions.AppColor("SystemAccentColorDark1");
        /// <summary>
        /// Light: FF003E92  Dark: FF003E92
        /// </summary>
        public static Color AccentDark2
            => ColorExtensions.AppColor("SystemAccentColorDark2");
        /// <summary>
        /// Light: FF001A68  Dark: FF001A68
        /// </summary>
        public static Color AccentDark3
            => ColorExtensions.AppColor("SystemAccentColorDark3");
        #endregion


        #region debug
        
        public static void Debug()
        {

            System.Diagnostics.Debug.WriteLine($"Accent : {SystemColors.Accent}");

            #region Alt
            System.Diagnostics.Debug.WriteLine($"AltHigh  : {SystemColors.AltHigh}");
            System.Diagnostics.Debug.WriteLine($"AltLow  : {SystemColors.AltLow}");
            System.Diagnostics.Debug.WriteLine($"AltMedium  : {SystemColors.AltMedium}");
            System.Diagnostics.Debug.WriteLine($"AltMediumHigh  : {SystemColors.AltMediumHigh}");
            System.Diagnostics.Debug.WriteLine($"AltMediumLow  : {SystemColors.AltMediumLow}");
            #endregion

            #region Base
            System.Diagnostics.Debug.WriteLine($"BaseHigh  : {SystemColors.BaseHigh}");
            System.Diagnostics.Debug.WriteLine($"BaseLow  : {SystemColors.BaseLow}");
            System.Diagnostics.Debug.WriteLine($"BaseMedium  : {SystemColors.BaseMedium}");
            System.Diagnostics.Debug.WriteLine($"BaseMediumHigh  : {SystemColors.BaseMediumHigh}");
            System.Diagnostics.Debug.WriteLine($"BaseMediumLow  : {SystemColors.BaseMediumLow}");
            #endregion

            #region Chrome
            System.Diagnostics.Debug.WriteLine($"ChromeAltLow : {SystemColors.ChromeAltLow}");

            System.Diagnostics.Debug.WriteLine($"ChromeBlackHigh : {SystemColors.ChromeBlackHigh}");
            System.Diagnostics.Debug.WriteLine($"ChromeBlackMedium : {SystemColors.ChromeBlackMedium}");
            System.Diagnostics.Debug.WriteLine($"ChromeBlackMediumLow : {SystemColors.ChromeBlackMediumLow}");
            System.Diagnostics.Debug.WriteLine($"ChromeBlackLow : {SystemColors.ChromeBlackLow}");

            System.Diagnostics.Debug.WriteLine($"ChromeDisabledHigh : {SystemColors.ChromeDisabledHigh}");
            System.Diagnostics.Debug.WriteLine($"ChromeDisabled : {SystemColors.ChromeDisabledLow}");

            System.Diagnostics.Debug.WriteLine($"ChromeGray : {SystemColors.ChromeGray}");

            System.Diagnostics.Debug.WriteLine($"ChromeHigh : {SystemColors.ChromeHigh}");
            System.Diagnostics.Debug.WriteLine($"ChromeMedium : {SystemColors.ChromeMedium}");
            System.Diagnostics.Debug.WriteLine($"ChromeMediumLow : {SystemColors.ChromeMediumLow}");
            System.Diagnostics.Debug.WriteLine($"ChromeLow : {SystemColors.ChromeLow}");

            System.Diagnostics.Debug.WriteLine($"ChromeWhite : {SystemColors.ChromeWhite}");
            #endregion

            #region List
            System.Diagnostics.Debug.WriteLine($"ListLow : {SystemColors.ListLow}");
            System.Diagnostics.Debug.WriteLine($"ListMedium : {SystemColors.ListMedium}");
            System.Diagnostics.Debug.WriteLine($"ListAccentLow : {ListAccentLow}");
            System.Diagnostics.Debug.WriteLine($"ListAccentMedium : {ListAccentMedium}");
            System.Diagnostics.Debug.WriteLine($"ListAccentHigh : {ListAccentHigh}");
            #endregion

            #region Button
            System.Diagnostics.Debug.WriteLine($"ButtonFace : {ButtonFace}");
            System.Diagnostics.Debug.WriteLine($"ButtonText : {ButtonText}");
            #endregion

            #region Text
            System.Diagnostics.Debug.WriteLine($"GrayText : {GrayText}");
            //System.Diagnostics.Debug.WriteLine($"ErrorText : {SystemColors.ErrorText}");
            #endregion

            #region Highlight
            System.Diagnostics.Debug.WriteLine($"Highlight : {Highlight}");
            System.Diagnostics.Debug.WriteLine($"HighlightText : {HighlightText}");
            #endregion

            #region HotLight
            System.Diagnostics.Debug.WriteLine($"Hotlight : {Hotlight}");
            #endregion

            #region Window
            System.Diagnostics.Debug.WriteLine($"WindowColor : {WindowColor}");
            System.Diagnostics.Debug.WriteLine($"WindowTextColor : {WindowTextColor}");
            #endregion

            #region Accent
            System.Diagnostics.Debug.WriteLine($"Accent : {Accent}");
            System.Diagnostics.Debug.WriteLine($"AccentLight3 : {AccentLight3}");
            System.Diagnostics.Debug.WriteLine($"AccentLight2 : {AccentLight2}");
            System.Diagnostics.Debug.WriteLine($"AccentLight1 : {AccentLight1}");
            System.Diagnostics.Debug.WriteLine($"AccentDark1 : {AccentDark1}");
            System.Diagnostics.Debug.WriteLine($"AccentDark2 : {AccentDark2}");
            System.Diagnostics.Debug.WriteLine($"AccentDark3 : {AccentDark3}");
            #endregion
        }

        #endregion
    }
}
