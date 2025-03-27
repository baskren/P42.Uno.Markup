using System;
using System.Reflection;
using Microsoft.UI.Xaml.Data;

namespace eContainment4.Views;

public class EmbeddedResourceImageSourceConverter : IValueConverter
{
    private static EmbeddedResourceImageSourceConverter _instance;
    public static EmbeddedResourceImageSourceConverter Instance => _instance ??= new EmbeddedResourceImageSourceConverter();

    private EmbeddedResourceImageSourceConverter()
    {
    }

    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is not string resourceId)
            return null;

        var assembly = parameter as Assembly;

        try
        {
            return P42.Utils.Uno.ImageSourceExtensions.GetImageSourceFromEmbeddedResource(resourceId, assembly);
        }
        catch (Exception ex)
        {
            //QLog.Error(ex);
            Console.WriteLine($"EmbeddedResourceImageSourceConverter.Convert : EXCEPTION {ex}");
        }
        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
