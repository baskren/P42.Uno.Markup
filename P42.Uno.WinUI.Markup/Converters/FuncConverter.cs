using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using P42.Serilog.QuickLog;

namespace P42.Uno.WinUI.Markup;

public class FuncConverter<TSource, TDest, TParam> : IValueConverter
{
    private readonly Func<TSource?, TDest?>? _convert;
    private readonly Func<TDest?, TSource?>? _convertBack;

    private readonly Func<TSource?, TParam?, TDest?>? _convertWithParam;
    private readonly Func<TDest?, TParam?, TSource?>? _convertBackWithParam;

    private readonly Func<TSource?, TParam?, string?, TDest?>? _convertWithParamAndLanguage;
    private readonly Func<TDest?, TParam?, string?, TSource?>? _convertBackWithParamAndLanguage;

    private readonly string _filePath;
    private readonly int _lineNumber;

    public FuncConverter(
        Func<TSource?, TParam?, string?, TDest?> convertWithParamAndLanguage, 
        Func<TDest?, TParam?, string?, TSource?>? convertBackWithParamAndCulture = null, 
        [CallerFilePath] string filePath = "", 
        [CallerLineNumber] int lineNumber = -1)
    { 
        _convertWithParamAndLanguage = convertWithParamAndLanguage; 
        _convertBackWithParamAndLanguage = convertBackWithParamAndCulture; 
        _filePath = filePath;
        _lineNumber = lineNumber;
    }

    public FuncConverter(
        Func<TSource?, TParam?, TDest?> convertWithParam, 
        Func<TDest?, TParam?, TSource?>? convertBackWithParam = null, 
        [CallerFilePath] string filePath = "", 
        [CallerLineNumber] int lineNumber = -1)
    { 
        _convertWithParam = convertWithParam; 
        _convertBackWithParam = convertBackWithParam;
        _filePath = filePath;
        _lineNumber = lineNumber;
    }

    // ReSharper disable once MemberCanBeProtected.Global
    public FuncConverter(
        Func<TSource?, TDest?> convert,
        Func<TDest?, TSource?>? convertBack = null, 
        [CallerFilePath] string filePath = "", 
        [CallerLineNumber] int lineNumber = -1)
    { 
        _convert = convert; 
        _convertBack = convertBack;
        _filePath = filePath;
        _lineNumber = lineNumber;
    }

    public object? Convert(object? value, Type? targetType, object? parameter, string? language)
    {
        try
        {
            if (_convert != null)
                return _convert.Invoke(
                    value != null ? (TSource)value : default);

            if (_convertWithParam != null)
                return _convertWithParam.Invoke(
                    value != null ? (TSource)value : default,
                    parameter != null ? (TParam)parameter : default);

            if (_convertWithParamAndLanguage != null)
                return _convertWithParamAndLanguage.Invoke(
                    value != null ? (TSource)value : default,
                    parameter != null ? (TParam)parameter : default,
                    language);

        }
        catch (Exception ex)
        {
            var msg = $"Convert Exception: {_filePath}:{_lineNumber}";
            Console.WriteLine(msg);
            Debug.WriteLine(msg);
            QLog.Error(ex, msg);
        }

        return default(TDest);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, string? language)
    {
        try
        {
            if (_convertBack != null)
                return _convertBack.Invoke(
                    value != null ? (TDest)value : default);

            if (_convertBackWithParam != null)
                return _convertBackWithParam.Invoke(
                    value != null ? (TDest)value : default,
                    parameter != null ? (TParam)parameter : default);

            if (_convertBackWithParamAndLanguage != null)
                return _convertBackWithParamAndLanguage.Invoke(
                    value != null ? (TDest)value : default,
                    parameter != null ? (TParam)parameter : default,
                    language);
        }
        catch (Exception ex)
        {
            var msg = $"ConvertBack Exception: {_filePath}:{_lineNumber}";
            Console.WriteLine(msg);
            Debug.WriteLine(msg);
            QLog.Error(ex, msg);
        }

        return default(TSource);
    }
}



public class FuncConverter<TSource, TDest>(
    Func<TSource?, TDest?> convert,
    Func<TDest?, TSource?>? convertBack = null,
    [CallerFilePath] string filePath = "",
    [CallerLineNumber] int lineNumber = -1)
    : FuncConverter<TSource, TDest, object>(convert, convertBack, filePath, lineNumber);

// ReSharper disable once UnusedType.Global
public class FuncConverter<TSource>(
    Func<TSource?, object?> convert,
    Func<object?, TSource?>? convertBack = null,
    [CallerFilePath] string filePath = "",
    [CallerLineNumber] int lineNumber = -1)
    : FuncConverter<TSource, object, object>(convert, convertBack, filePath, lineNumber);

// ReSharper disable once UnusedType.Global
public class FuncConverter(
    Func<object?, object?> convert,
    Func<object?, object?>? convertBack = null,
    [CallerFilePath] string filePath = "",
    [CallerLineNumber] int lineNumber = -1)
    : FuncConverter<object, object, object>(convert, convertBack, filePath, lineNumber);

// ReSharper disable once UnusedType.Global
public class ToStringConverter(
    string format = "{0}",
    [CallerFilePath] string filePath = "",
    [CallerLineNumber] int lineNumber = -1)
    : FuncConverter<object, string>(o => string.Format(CultureInfo.InvariantCulture, format, o), null, filePath,
        lineNumber);

