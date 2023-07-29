using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Data;
using P42.Serilog.QuickLog;

namespace P42.Uno.Markup
{
	public class FuncConverter<TSource, TDest, TParam> : IValueConverter
	{
		readonly Func<TSource, TDest> convert;
		readonly Func<TDest, TSource> convertBack;

		readonly Func<TSource, TParam, TDest> convertWithParam;
		readonly Func<TDest, TParam, TSource> convertBackWithParam;

		readonly Func<TSource, TParam, string, TDest> convertWithParamAndLanguage;
		readonly Func<TDest, TParam, string, TSource> convertBackWithParamAndLanguage;

		readonly string FilePath;
		readonly int LineNumber;

		public FuncConverter(Func<TSource, TParam, string, TDest> convertWithParamAndLanguate = null, Func<TDest, TParam, string, TSource> convertBackWithParamAndCulture = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = -1)
		{ 
			this.convertWithParamAndLanguage = convertWithParamAndLanguate; 
			this.convertBackWithParamAndLanguage = convertBackWithParamAndCulture; 
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
				var msg = ($"Convert Exception: {FilePath}:{LineNumber}");
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
                var msg = ($"ConvertBack Exception: {FilePath}:{LineNumber}");
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
		static readonly Lazy<NotConverter> instance = new Lazy<NotConverter>(() => new NotConverter());
		public static NotConverter Instance => instance.Value;
		public NotConverter([CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = -1) : base(t => !t, t => !t, filePath, lineNumber) { }
	}
}
