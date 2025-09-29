using CodeGenHelpers;
using System;

#nullable enable
namespace P42.Uno.Extensions.Markup.Generators.Extensibility;

internal class FontFamilyTypeExtension : ITypeExtension
{
    public bool CanExtend(string qualifiedTypeName)
    {
        return false;
        //return qualifiedTypeName == "global::Microsoft.UI.Xaml.Media.FontFamily";
    }

    public void WriteAttachedPropertyBuilderExtensions(
      AttachedPropertyInfo prop,
      Func<MethodBuilder> createBuilder)
    {
        createBuilder().AddParameter<MethodBuilder>("string", "fontFamily").WithBody((Action<ICodeWriter>)(w => w.AppendLine($"return {prop.Name}(new global::Microsoft.UI.Xaml.Media.FontFamily(fontFamily));")));
    }

    public void WriteDependencyPropertyExtensions(
      ClassBuilder builder,
      DependencyPropertyExtensionInfo info,
      Func<string,MethodBuilder> createBuilder)
    {
        createBuilder(info.PropertyName).AddParameter<MethodBuilder>("string", "fontFamily").WithBody((Action<ICodeWriter>)(w =>
        {
            w.AppendLine($"element.{info.PropertyName} = new global::Microsoft.UI.Xaml.Media.FontFamily(fontFamily);");
            w.AppendLine("return element;");
        }));
    }

    public void WriteStyleBuilderExtensions(
      ClassBuilder builder,
      StyleBuilderInfo info,
      Func<string,MethodBuilder> createBuilder)
    {
        createBuilder(info.PropertyName).AddParameter<MethodBuilder>("string", "fontFamily").WithBody((Action<ICodeWriter>)(w =>
        {
            w.AppendLine("var font = new global::Microsoft.UI.Xaml.Media.FontFamily(fontFamily);");
            w.AppendLine($"return builder.{info.PropertyName}(font);");
        }));
    }
}
