using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using P42.Utils.Uno;

namespace P42.Uno.WinUI.Markup;

// ReSharper disable once UnusedType.Global
public class EmbeddedResourceImageSourceConverter : TypeConverter, IValueConverter
{
    private static EmbeddedResourceImageSourceConverter? _instance;
    public static EmbeddedResourceImageSourceConverter Instance => _instance ??= new EmbeddedResourceImageSourceConverter();

    private EmbeddedResourceImageSourceConverter()
    {
    }

    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
    => sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);


    public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
    {
        try
        {
            return value is string str
                ? Convert(str, null, null, null)
                : base.ConvertFrom(context, culture, value);

        }
        catch (Exception)
        {
            return null;
        }
    }

    public object? Convert(object? value, Type? targetType, object? parameter, string? language)
    {
        if (value is not string resourceId)
            return null;

        var assembly = parameter as Assembly;

        try
        {
            var item = Utils.LocalData.ResourceItem.For(resourceId, null, assembly);
            return item.AssureExistsImageSource();
        }
        catch (Exception ex)
        {
            //QLog.Error(ex);
            Console.WriteLine($"EmbeddedResourceImageSourceConverter.Convert : EXCEPTION {ex}");
        }
        return null;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, string? language)
    {
        throw new NotImplementedException();
    }
}
