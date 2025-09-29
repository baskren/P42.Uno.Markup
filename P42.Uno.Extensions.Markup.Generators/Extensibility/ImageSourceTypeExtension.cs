using CodeGenHelpers;
using System;

#nullable enable
namespace P42.Uno.Extensions.Markup.Generators.Extensibility;

internal class ImageSourceTypeExtension : ITypeExtension
{
    public bool CanExtend(string qualifiedTypeName)
    {
        return false;
        //return qualifiedTypeName == "global::Microsoft.UI.Xaml.Media.ImageSource";
    }

    public void WriteAttachedPropertyBuilderExtensions(
      AttachedPropertyInfo prop,
      Func<MethodBuilder> createBuilder)
    {
        createBuilder()
            .AddParameter("string", "source")
            .WithBody(w =>
            {
                w.AppendLine("var assemblyName = global::System.Reflection.Assembly.GetCallingAssembly().GetName().Name ?? throw new global::System.NullReferenceException(\"Unable to determine the calling assembly. Please use a fully qualified uri.\");");
                w.AppendLine("var imageSource = MarkupImageSource.Load(source, assemblyName);");
                w.If("imageSource is not null").WithBody(x => x.AppendLine($"return {prop.Name}(imageSource);")).EndIf();
                w.AppendLine("return builder;");
            });
        createBuilder()
            .AddParameter("global::System.Uri", "uri")
            .WithBody(w =>
            {
                w.AppendLine("var assemblyName = global::System.Reflection.Assembly.GetCallingAssembly().GetName().Name ?? throw new global::System.NullReferenceException(\"Unable to determine the calling assembly. Please use a fully qualified uri.\");");
                w.AppendLine("var imageSource = MarkupImageSource.Load(uri, assemblyName);");
                w.If("imageSource is not null").WithBody(x => x.AppendLine($"return {prop.Name}(imageSource);")).EndIf();
                w.AppendLine("return builder;");
            });
    }

    public void WriteDependencyPropertyExtensions(
      ClassBuilder builder,
      DependencyPropertyExtensionInfo info,
      Func<string, MethodBuilder> createBuilder)
    {
        createBuilder(info.PropertyName)
            .AddParameter("string", "source")
            .WithBody(w =>
            {
                w.AppendLine("var assemblyName = global::System.Reflection.Assembly.GetCallingAssembly().GetName().Name ?? throw new global::System.NullReferenceException(\"Unable to determine the calling assembly. Please use a fully qualified uri.\");");
                w.AppendLine("var imageSource = MarkupImageSource.Load(source, assemblyName);");
                w.If("imageSource is not null").WithBody(x => x.AppendLine($"return element.{info.PropertyName}(imageSource);")).EndIf();
                w.AppendLine("return element;");
            });
        createBuilder(info.PropertyName)
            .AddParameter("global::System.Uri", "uri")
            .WithBody(w =>
            {
                w.AppendLine("var assemblyName = global::System.Reflection.Assembly.GetCallingAssembly().GetName().Name ?? throw new global::System.NullReferenceException(\"Unable to determine the calling assembly. Please use a fully qualified uri.\");");
                w.AppendLine("var imageSource = MarkupImageSource.Load(uri, assemblyName);");
                w.If("imageSource is not null").WithBody(x => x.AppendLine($"return element.{info.PropertyName}(imageSource);")).EndIf();
                w.AppendLine("return element;");
            });
    }

    public void WriteStyleBuilderExtensions(
      ClassBuilder builder,
      StyleBuilderInfo info,
      Func<string, MethodBuilder> createBuilder)
    {
        createBuilder(info.PropertyName)
            .AddParameter("string", "source")
            .WithBody(w =>
            {
                w.AppendLine("var assemblyName = global::System.Reflection.Assembly.GetCallingAssembly().GetName().Name ?? throw new global::System.NullReferenceException(\"Unable to determine the calling assembly. Please use a fully qualified uri.\");");
                w.AppendLine("var imageSource = MarkupImageSource.Load(source, assemblyName);");
                w.If("imageSource is not null").WithBody(x => x.AppendLine($"return builder.{info.PropertyName}(imageSource);")).EndIf();
                w.AppendLine("return builder;");
            });
        createBuilder(info.PropertyName)
            .AddParameter("global::System.Uri", "uri")
            .WithBody(w =>
            {
                w.AppendLine("var assemblyName = global::System.Reflection.Assembly.GetCallingAssembly().GetName().Name ?? throw new global::System.NullReferenceException(\"Unable to determine the calling assembly. Please use a fully qualified uri.\");");
                w.AppendLine("var imageSource = MarkupImageSource.Load(uri, assemblyName);");
                w.If("imageSource is not null").WithBody(x => x.AppendLine($"return builder.{info.PropertyName}(imageSource);")).EndIf();
                w.AppendLine("return builder;");
            });
    }
}
