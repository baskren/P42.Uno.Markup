using ElementType = Microsoft.UI.Xaml.FrameworkElement;

namespace P42.Uno.WinUI.Markup;

// ReSharper disable once UnusedType.Global
public static class FrameworkElementExtensions
{
    extension<TElement>(TElement element) where TElement :ElementType
    {
        public TElement Resources(params object[] objects)
        {
            var dict = element.Resources ?? new ResourceDictionary();
            object? key = null;
            foreach (var obj in objects)
            {
                switch (obj)
                {
                    case string text:
                        key = text;
                        break;
                    case Type type:
                        key = type;
                        break;
                    case IDictionary<object, object> mDict:
                        dict.MergedDictionaries.Add((ResourceDictionary)mDict);
                        key = null;
                        break;
                    case Style style:
                        if (key is not null)
                            element.AddStyle(key, style);
                        break;
                }
            }
            return element; 
        }

        public TElement AddStyle(Style style) => element.AddStyle(null, style);

        public TElement AddStyle(object? key, Style style)
        {
            var dict = element.Resources ?? new ResourceDictionary();
            key ??= style.TargetType;
        
            if (key is null)
                return element;
        
            if (style.BasedOn is null && dict.TryGetValue(key, out var xvalue))
            {
                if (xvalue is Style xStyle)
                    style.BasedOn(xStyle);
                else
                    dict.Add(key, style);
            }
            else
                dict.Add(key, style);
        
            return element;
        }

        public TElement AddStyle(string? key, Type targetType, Setter first, params Setter[] setters) => element.AddStyle(key, targetType, null, first, setters);

        public TElement AddStyle(Type targetType, Setter first, params Setter[] setters) => element.AddStyle(null, targetType, null, first, setters);

        public TElement AddStyle(Type targetType, Style? basedUpon, Setter first, params Setter[] setters) => element.AddStyle(null, targetType, basedUpon, first, setters);

        public TElement AddStyle(string? key, Type targetType, Style? basedUpon, Setter first, params Setter[]? setters)
        {
            var style = new Style(targetType);
            if (basedUpon is not null)
                style.BasedOn = basedUpon;
        
            style.Setters.Add(first);
            if (setters is { Length: > 0 })
            {
                foreach (var setter in setters)
                    style.Setters.Add(setter);
            }
        
            element.AddStyle((object?)key ?? targetType, style);
            return element;
        }

        public TElement AddStyle(string? key, Type targetType, Style? basedUpon, (DependencyProperty, object) first, params (DependencyProperty, object)[]? setters)
        {
            element.AddStyle(key, targetType, basedUpon, new Setter(first.Item1, first.Item2), setters?.Select(s => new Setter(s.Item1, s.Item2)).ToArray());
            return element;
        }

        public TElement AddStyle(Type targetType, Style? basedUpon, (DependencyProperty, object) first, params (DependencyProperty, object)[] setters) => element.AddStyle(null, targetType, basedUpon, first, setters);

        public TElement AddStyle(string? key, Type targetType, (DependencyProperty, object) first, params (DependencyProperty, object)[] setters) => element.AddStyle(key, targetType, null, first, setters);

        public TElement AddStyle(Type targetType, (DependencyProperty, object) first, params (DependencyProperty, object)[] setters) => element.AddStyle(null, targetType, null, first, setters);
    }


    #region Style
    extension<T>(T element) where T :ElementType
    {
        public T Style(Style<T> style)
        { element.Style = style.BaseStyle; return element; }

        public T Style(DependencyProperty property, object value)
        {
            element.Style = new Style<T>((property, value));
            return element;
        }

        public T Style(object resourceDictionaryEntry)
        {
            switch (resourceDictionaryEntry)
            {
                case Style style:
                    element.Style(style);
                    break;
                case Style<T> styleT:
                    element.Style(styleT);
                    break;
                default:
                    throw new InvalidCastException(
                        $"Dictionary entry is of type [{resourceDictionaryEntry.GetType()}], not Style");
            }

            return element;
        }
    }

    #endregion


    #region Size
    extension<TElement>(TElement element) where TElement :ElementType
    {
        public TElement Size(double widthRequest, double heightRequest) => element.Width(widthRequest).Height(heightRequest);
        public TElement Size(double sizeRequest) => element.Width(sizeRequest).Height(sizeRequest);
        public TElement MinSize(double widthRequest, double heightRequest) => element.MinWidth(widthRequest).MinHeight(heightRequest);
        public TElement MinSize(double sizeRequest) => element.MinWidth(sizeRequest).MinHeight(sizeRequest);
        public TElement MaxSize(double widthRequest, double heightRequest) => element.MaxWidth(widthRequest).MaxHeight(heightRequest);
        public TElement MaxSize(double sizeRequest) => element.MaxWidth(sizeRequest).MaxHeight(sizeRequest);
    }

    #endregion
    
}
