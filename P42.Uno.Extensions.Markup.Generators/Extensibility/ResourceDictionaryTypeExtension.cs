using CodeGenHelpers;
using System;

#nullable enable
namespace P42.Uno.Extensions.Markup.Generators.Extensibility;

internal class ResourceDictionaryTypeExtension : ITypeExtension
{
    public bool CanExtend(string qualifiedTypeName)
    {
        return false;
        //return qualifiedTypeName == "global::Microsoft.UI.Xaml.ResourceDictionary";
    }

    public void WriteAttachedPropertyBuilderExtensions(
      AttachedPropertyInfo prop,
      Func<MethodBuilder> createBuilder)
    {
    }

    public void WriteDependencyPropertyExtensions(
      ClassBuilder builder,
      DependencyPropertyExtensionInfo info,
      Func<string,MethodBuilder> createBuilder)
    {
        createBuilder(info.PropertyName).AddParameter<MethodBuilder>("Action<ResourceDictionaryBuilder>", "configureResources").WithBody((Action<ICodeWriter>)(w =>
        {
            w.AppendLine($"element.{info.PropertyName} ??= new global::Microsoft.UI.Xaml.ResourceDictionary();");
            w.AppendLine($"configureResources(new ResourceDictionaryBuilder(element.{info.PropertyName}));");
            w.AppendLine("return element;");
        }));
    }

    public void WriteStyleBuilderExtensions(
      ClassBuilder builder,
      StyleBuilderInfo info,
      Func<string,MethodBuilder> createBuilder)
    {
    }
}
