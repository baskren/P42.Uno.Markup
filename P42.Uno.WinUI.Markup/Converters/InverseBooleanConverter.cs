using System.Runtime.CompilerServices;

namespace P42.Uno.WinUI.Markup;

// ReSharper disable once UnusedType.Global
public class InverseBooleanConverter : NotConverter;

// ReSharper disable once UnusedType.Global
public class NotConverter(
    [CallerFilePath] string filePath = "",
    [CallerLineNumber] int lineNumber = -1)
    : FuncConverter<bool, bool>(t => !t, t => !t, filePath, lineNumber)
{
    private static NotConverter? _instance;
    public static NotConverter Instance => _instance ??= new NotConverter();
}
