using System.Reflection;
using AsyncAwaitBestPractices;
using P42.Utils;
using ElementType = Microsoft.UI.Xaml.Media.Imaging.SvgImageSource;


namespace P42.Uno.WinUI.Markup;

// ReSharper disable once UnusedType.Global
public static class SvgImageSourceExtensions
{
    [Obsolete("use P42.Utils.Uno.LocalData_ImageSource_Extensions")]
    public static TElement ResourceSource<TElement>(this TElement element, string value, Assembly? asm = null) where TElement : ElementType
    {
        var result = EmbeddedResourceExtensions.FindAssemblyResourceIdAndStream(value, asm);
        if (result?.DisposableStream is { } stream)
        {
            using var randomAccessStream = stream.AsRandomAccessStream();
            element.SetSourceAsync(randomAccessStream).AsTask().SafeFireAndForget();
            stream.Dispose();
            return element;
        }
        Console.WriteLine($"SvgImageExtensions.Source: Cannot find ImageSource from ResourceId string [{value}].");

        return element; 
    }


}
