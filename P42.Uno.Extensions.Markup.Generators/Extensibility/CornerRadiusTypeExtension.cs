using CodeGenHelpers;
using System;

#nullable enable
namespace P42.Uno.Extensions.Markup.Generators.Extensibility;

internal class CornerRadiusTypeExtension : ITypeExtension
{
    public bool CanExtend(string qualifiedTypeName)
    {
        return false;
        //return qualifiedTypeName == "global::Microsoft.UI.Xaml.CornerRadius";
    }

    public void WriteAttachedPropertyBuilderExtensions(
      AttachedPropertyInfo prop,
      Func<MethodBuilder> createBuilder)
    {
        createBuilder()
            .AddParameter("double", "topLeft")
            .AddParameter("double", "topRight")
            .AddParameter("double", "bottomRight")
            .AddParameter("double", "bottomLeft")
            .WithBody(w => w.AppendLine($"return {prop.Name}(new global::Microsoft.UI.Xaml.CornerRadius(topLeft, topRight, bottomRight, bottomLeft));"));
        createBuilder()
            .AddParameter("double", "uniformRadius")
            .WithBody(w => w.AppendLine($"return {prop.Name}(new global::Microsoft.UI.Xaml.CornerRadius(uniformRadius));"));
    }

    public void WriteDependencyPropertyExtensions(
      ClassBuilder builder,
      DependencyPropertyExtensionInfo info,
      Func<string,MethodBuilder> createBuilder)
    {
        createBuilder(info.PropertyName)
            .AddParameter("double", "topLeft")
            .AddParameter("double", "topRight")
            .AddParameter("double", "bottomRight")
            .AddParameter("double", "bottomLeft")
            .WithBody(w =>
        {
            w.AppendLine($"element.{info.PropertyName} = new global::Microsoft.UI.Xaml.CornerRadius(topLeft, topRight, bottomRight, bottomLeft);");
            w.AppendLine("return element;");
        });
        createBuilder(info.PropertyName)
            .AddParameter("double", "uniformRadius")
            .WithBody(w =>
        {
            w.AppendLine($"element.{info.PropertyName} = new global::Microsoft.UI.Xaml.CornerRadius(uniformRadius);");
            w.AppendLine("return element;");
        });
    }

    public void WriteStyleBuilderExtensions(
      ClassBuilder builder,
      StyleBuilderInfo info,
      Func<string, MethodBuilder> createBuilder)
    {
        createBuilder(info.PropertyName)
            .AddParameter("double", "topLeft")
            .AddParameter("double", "topRight")
            .AddParameter("double", "bottomRight")
            .AddParameter("double", "bottomLeft")
            .WithBody(w =>
        {
            w.AppendLine($"builder.{info.PropertyName}(new global::Microsoft.UI.Xaml.CornerRadius(topLeft, topRight, bottomRight, bottomLeft));");
            w.AppendLine("return builder;");
        });
        createBuilder(info.PropertyName)
            .AddParameter("double", "uniformRadius")
            .WithBody(w =>
        {
            w.AppendLine($"builder.{info.PropertyName}(new global::Microsoft.UI.Xaml.CornerRadius(uniformRadius));");
            w.AppendLine("return builder;");
        });
    }
}
