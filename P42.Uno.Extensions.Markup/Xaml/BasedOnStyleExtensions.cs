using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Markup;
using System.Collections.Generic;
using System.ComponentModel;

#nullable enable
namespace P42.Uno.Extensions.Markup.Xaml;

[EditorBrowsable(EditorBrowsableState.Never)]
[ContentProperty(Name = "Id")]
[MarkupExtensionReturnType(ReturnType = typeof(Style))]
public class BasedOnStyleExtension : MarkupExtension
{
    private static Dictionary<string, Style> _styles = new Dictionary<string, Style>();

    public string Id { get; set; } = string.Empty;

    protected virtual object ProvideValue()
    {
        Style style;
        if (BasedOnStyleExtension._styles.TryGetValue(this.Id, out style))
            return (object)style;
        throw new MarkupException($"Style with id {this.Id} not found");
    }

    public static string Register(Style style, string filePath, string name, int lineNumber)
    {
        string key = $"{filePath}.{name}.{lineNumber}.{style.TargetType.Name}";
        BasedOnStyleExtension._styles[key] = style;
        return key;
    }
}
