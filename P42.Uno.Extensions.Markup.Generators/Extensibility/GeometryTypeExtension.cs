using CodeGenHelpers;
using System;

#nullable enable
namespace P42.Uno.Extensions.Markup.Generators.Extensibility;

internal sealed class GeometryTypeExtension : ITypeExtension
{
    public bool CanExtend(string qualifiedTypeName)
    {
        return false;
        //return qualifiedTypeName == "global::Microsoft.UI.Xaml.Media.Geometry";
    }

    public void WriteAttachedPropertyBuilderExtensions(
      AttachedPropertyInfo prop,
      Func<MethodBuilder> createBuilder)
    {
        createBuilder().AddParameter<MethodBuilder>("string", "path").WithBody((Action<ICodeWriter>)(w =>
        {
            w.AppendLine("var geometry = (global::Microsoft.UI.Xaml.Media.Geometry)global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::Microsoft.UI.Xaml.Media.Geometry), path);");
            w.AppendLine($"return {prop.Name}(geometry);");
        }));
    }

    public void WriteDependencyPropertyExtensions(
      ClassBuilder builder,
      DependencyPropertyExtensionInfo info,
      Func<string,MethodBuilder> createBuilder)
    {
        createBuilder(info.PropertyName).AddParameter<MethodBuilder>("string", "path").WithBody((Action<ICodeWriter>)(w =>
        {
            w.AppendLine("var geometry = (global::Microsoft.UI.Xaml.Media.Geometry)global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::Microsoft.UI.Xaml.Media.Geometry), path);");
            w.AppendLine($"element.{info.PropertyName} = geometry;");
            w.AppendLine("return element;");
        }));
    }

    public void WriteStyleBuilderExtensions(
      ClassBuilder builder,
      StyleBuilderInfo info,
      Func<string,MethodBuilder> createBuilder)
    {
        builder.AddNamespaceImport("Microsoft.UI.Xaml.Media");
        createBuilder(info.PropertyName).AddParameter<MethodBuilder>("string", "path").WithBody((Action<ICodeWriter>)(w =>
        {
            w.AppendLine("var geometry = (global::Microsoft.UI.Xaml.Media.Geometry)global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::Microsoft.UI.Xaml.Media.Geometry), path);");
            w.AppendLine($"builder.{info.PropertyName}(geometry);");
            w.AppendLine("return builder;");
        }));
    }
}
