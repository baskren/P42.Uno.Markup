using Microsoft.UI;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using Windows.UI;

#nullable enable
namespace Uno.Extensions.Markup.Internals;

[Obsolete("This is obsolete. Be sure to use an updated")]
[EditorBrowsable(EditorBrowsableState.Never)]
public static class HexStringHelper
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static Color ToColor(string colorString)
    {
        if (string.IsNullOrEmpty(colorString))
            ThrowArgumentException();

        if (colorString[0] == '#')
        {
            switch (colorString.Length)
            {
                case 4:
                    int uint16_1 = Convert.ToUInt16(colorString[1..], 16 /*0x10*/);
                    byte num1 = (byte)(uint16_1 >> 8 & 15);
                    byte num2 = (byte)(uint16_1 >> 4 & 15);
                    byte num3 = (byte)(uint16_1 & 15);
                    return Color.FromArgb(byte.MaxValue, (byte)((uint)num1 << 4 | num1), (byte)((uint)num2 << 4 | num2), (byte)((uint)num3 << 4 | num3));
                case 5:
                    int uint16_2 = Convert.ToUInt16(colorString[1..], 16 /*0x10*/);
                    byte num4 = (byte)(uint16_2 >> 12);
                    byte num5 = (byte)(uint16_2 >> 8 & 15);
                    byte num6 = (byte)(uint16_2 >> 4 & 15);
                    byte num7 = (byte)(uint16_2 & 15);
                    return Color.FromArgb((byte)((uint)num4 << 4 | num4), (byte)((uint)num5 << 4 | num5), (byte)((uint)num6 << 4 | num6), (byte)((uint)num7 << 4 | num7));
                case 7:
                    int uint32_1 = (int)Convert.ToUInt32(colorString[1..], 16 /*0x10*/);
                    return Color.FromArgb(byte.MaxValue, (byte)(uint32_1 >>> 16 /*0x10*/ & byte.MaxValue), (byte)(uint32_1 >>> 8 & byte.MaxValue), (byte)(uint32_1 & byte.MaxValue));
                case 9:
                    int uint32_2 = (int)Convert.ToUInt32(colorString[1..], 16 /*0x10*/);
                    return Color.FromArgb((byte)(uint32_2 >>> 24), (byte)(uint32_2 >>> 16 /*0x10*/ & byte.MaxValue), (byte)(uint32_2 >>> 8 & byte.MaxValue), (byte)(uint32_2 & byte.MaxValue));
                default:
                    return ThrowFormatException();
            }
        }
        else
        {
            if (colorString.Length > 3 && colorString[0] == 's' && colorString[1] == 'c' && colorString[2] == '#')
            {
                string[] strArray = colorString.Split(',');
                return strArray.Length == 4 ? Color.FromArgb((byte)(double.Parse(strArray[0][3..], CultureInfo.InvariantCulture) * byte.MaxValue), (byte)(double.Parse(strArray[1], CultureInfo.InvariantCulture) * byte.MaxValue), (byte)(double.Parse(strArray[2], CultureInfo.InvariantCulture) * byte.MaxValue), (byte)(double.Parse(strArray[3], CultureInfo.InvariantCulture) * byte.MaxValue)) : (strArray.Length == 3 ? Color.FromArgb(byte.MaxValue, (byte)(double.Parse(strArray[0][3..], CultureInfo.InvariantCulture) * byte.MaxValue), (byte)(double.Parse(strArray[1], CultureInfo.InvariantCulture) * byte.MaxValue), (byte)(double.Parse(strArray[2], CultureInfo.InvariantCulture) * byte.MaxValue)) : ThrowFormatException());
            }
            if (typeof(Colors).GetTypeInfo().GetDeclaredProperty(colorString) is PropertyInfo declaredProperty)
            {
                if (declaredProperty.GetValue(null) is Color color)
                    return color;
            }
            return ThrowFormatException();
        }

        static void ThrowArgumentException()
        {
            throw new ArgumentException("The parameter \"colorString\" must not be null or empty.", nameof(colorString));
        }

        static Color ThrowFormatException()
        {
            throw new FormatException("The parameter \"colorString\" is not a recognized Color format.");
        }
    }
}
