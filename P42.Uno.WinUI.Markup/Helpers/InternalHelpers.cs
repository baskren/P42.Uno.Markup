using System.Globalization;

namespace P42.Uno.WinUI.Markup;

internal static class InternalHelpers
{
    

    public static List<string>? GetExcepts(object? except)
    => except switch
        {
            null => null,
            string str => [str],
            IEnumerable<string> enumerable => [..enumerable],
            _ => throw new Exception("BindFont except: argument must be null, string, or IEnumerable<string>")
        };
    

}
