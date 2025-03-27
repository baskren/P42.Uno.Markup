using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using Microsoft.UI.Xaml.Data;
using P42.Serilog.QuickLog;

namespace P42.Uno.Markup;

public class FuncConverter<TSource, TDest, TParam> : IValueConverter
{
    private readonly Func<TSource, TDest> convert;
    private readonly Func<TDest, TSource> convertBack;

    private readonly Func<TSource, TParam, TDest> convertWithParam;
    private readonly Func<TDest, TParam, TSource> convertBackWithParam;

    private readonly Func<TSource, TParam, string, TDest> convertWithParamAndLanguage;
    private readonly Func<TDest, TParam, string, TSource> convertBackWithParamAndLanguage;

    private readonly string FilePath;
    private readonly int LineNumber;

    public FuncConverter(Func<TSource, TParam, string, TDest> convertWithParamAndLanguate = null, Func<TDest, TParam, string, TSource> convertBackWithParamAndCulture = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = -1)
    { 
        convertWithParamAndLanguage = convertWithParamAndLanguate; 
        convertBackWithParamAndLanguage = convertBackWithParamAndCulture; 
        FilePath = filePath;
        LineNumber = lineNumber;
    }

    public FuncConverter(Func<TSource, TParam, TDest> convertWithParam = null, Func<TDest, TParam, TSource> convertBackWithParam = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = -1)
    { 
        this.convertWithParam = convertWithParam; 
        this.convertBackWithParam = convertBackWithParam;
        FilePath = filePath;
        LineNumber = lineNumber;
    }

    public FuncConverter(Func<TSource, TDest> convert = null, Func<TDest, TSource> convertBack = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = -1)
    { 
        this.convert = convert; 
        this.convertBack = convertBack;
        FilePath = filePath;
        LineNumber = lineNumber;
    }

    public object Convert(object value, Type targetType, object parameter, string language)
    {
        try
        {
            if (convert != null)
                return convert.Invoke(
                    value != null ? (TSource)value : default(TSource));

            if (convertWithParam != null)
                return convertWithParam.Invoke(
                    value != null ? (TSource)value : default(TSource),
                    parameter != null ? (TParam)parameter : default(TParam));

            if (convertWithParamAndLanguage != null)
                return convertWithParamAndLanguage.Invoke(
                    value != null ? (TSource)value : default(TSource),
                    parameter != null ? (TParam)parameter : default(TParam),
                    language);

        }
        catch (Exception ex)
        {
            var msg = $"Convert Exception: {FilePath}:{LineNumber}";
            Console.WriteLine(msg);
            Debug.WriteLine(msg);
            QLog.Error(ex, msg);
        }

        return default(TDest);
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        try
        {
            if (convertBack != null)
                return convertBack.Invoke(
                    value != null ? (TDest)value : default(TDest));

            if (convertBackWithParam != null)
                return convertBackWithParam.Invoke(
                    value != null ? (TDest)value : default(TDest),
                    parameter != null ? (TParam)parameter : default(TParam));

            if (convertBackWithParamAndLanguage != null)
                return convertBackWithParamAndLanguage.Invoke(
                    value != null ? (TDest)value : default(TDest),
                    parameter != null ? (TParam)parameter : default(TParam),
                    language);
        }
        catch (Exception ex)
        {
            var msg = $"ConvertBack Exception: {FilePath}:{LineNumber}";
            Console.WriteLine(msg);
            Debug.WriteLine(msg);
            QLog.Error(ex, msg);
        }

        return default(TSource);
    }
}



public class FuncConverter<TSource, TDest> : FuncConverter<TSource, TDest, object>
{
    public FuncConverter(Func<TSource, TDest> convert = null, Func<TDest, TSource> convertBack = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = -1)
        : base(convert, convertBack, filePath, lineNumber) { }
}

public class FuncConverter<TSource> : FuncConverter<TSource, object, object>
{
    public FuncConverter(Func<TSource, object> convert = null, Func<object, TSource> convertBack = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = -1)
        : base(convert, convertBack, filePath, lineNumber) { }
}

public class FuncConverter : FuncConverter<object, object, object>
{
    public FuncConverter(Func<object, object> convert = null, Func<object, object> convertBack = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = -1)
        : base(convert, convertBack, filePath, lineNumber) { }
}

public class ToStringConverter : FuncConverter<object, string>
{
    public ToStringConverter(string format = "{0}", [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = -1)
        : base(o => string.Format(CultureInfo.InvariantCulture, format, o), null, filePath, lineNumber) { }
}

public class NotConverter : FuncConverter<bool, bool>
{
    private static readonly Lazy<NotConverter> instance = new(() => new NotConverter());
    public static NotConverter Instance => instance.Value;
    public NotConverter([CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = -1) : base(t => !t, t => !t, filePath, lineNumber) { }
}
