using CodeGenHelpers;
using System;

#nullable enable
namespace P42.Uno.Extensions.Markup.Generators.Extensibility;

internal class ThicknessTypeExtension : ITypeExtension
{
    public bool CanExtend(string qualifiedTypeName)
    {
        return false;
        //return qualifiedTypeName == "global::Microsoft.UI.Xaml.Thickness";
    }

    public void WriteAttachedPropertyBuilderExtensions(
      AttachedPropertyInfo prop,
      Func<MethodBuilder> createBuilder)
    {
        createBuilder()
            .AddParameter("double", "uniformLength")
            .WithBody(w => w.AppendLine($"return {prop.Name}(new Thickness(uniformLength));"));
        createBuilder()
            .AddParameter("double", "x")
            .AddParameter("double", "y")
            .WithBody(w => w.AppendLine($"return {prop.Name}(new Thickness(x, y, x, y));"));
        createBuilder()
            .AddParameter("double", "left")
            .AddParameter("double", "top")
            .AddParameter("double", "right")
            .AddParameter("double", "bottom")
            .WithBody(w => w.AppendLine($"return {prop.Name}(new Thickness(left, top, right, bottom));"));
    }

    public void WriteDependencyPropertyExtensions(
      ClassBuilder builder,
      DependencyPropertyExtensionInfo info,
      Func<string, MethodBuilder> createBuilder)
    {
        GenerationTypeInfo generationTypeInfo = info.GenerationTypeInfo;
        createBuilder(info.PropertyName)
            .AddParameter("double", "uniformLength")
            .WithBody(w =>
            {
                w.AppendLine($"element.{info.PropertyName} = new Thickness(uniformLength);");
                w.AppendLine("return element;");
            });
        createBuilder(info.PropertyName)
            .AddParameter("double", "x")
            .AddParameter("double", "y").WithBody(w =>
            {
                w.AppendLine($"element.{info.PropertyName} = new Thickness(x, y, x, y);");
                w.AppendLine("return element;");
            });
        createBuilder(info.PropertyName)
            .AddParameter("double", "left")
            .AddParameter("double", "top")
            .AddParameter("double", "right")
            .AddParameter("double", "bottom")
            .WithBody(w =>
            {
                w.AppendLine($"element.{info.PropertyName} = new Thickness(left, top, right, bottom);");
                w.AppendLine("return element;");
            });
    }

    public void WriteStyleBuilderExtensions(
      ClassBuilder builder,
      StyleBuilderInfo info,
      Func<string, MethodBuilder> createBuilder)
    {
        createBuilder(info.PropertyName)
            .AddParameter("double", "uniformLength")
            .WithBody(w =>
            {
                w.AppendLine($"builder.{info.PropertyName}(new Thickness(uniformLength));");
                w.AppendLine("return builder;");
            });
        createBuilder(info.PropertyName)
            .AddParameter("double", "x")
            .AddParameter("double", "y")
            .WithBody(w =>
            {
                w.AppendLine($"builder.{info.PropertyName}(new Thickness(x, y, x, y));");
                w.AppendLine("return builder;");
            });
        createBuilder(info.PropertyName)
            .AddParameter("double", "left")
            .AddParameter("double", "top")
            .AddParameter("double", "right").AddParameter("double", "bottom")
            .WithBody(w =>
            {
                w.AppendLine($"builder.{info.PropertyName}(new Thickness(left, top, right, bottom));");
                w.AppendLine("return builder;");
            });
    }
}
