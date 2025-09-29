using System;
using System.Drawing;
using CodeGenHelpers;

#nullable enable
namespace P42.Uno.Extensions.Markup.Generators.Extensibility;

internal class BrushTypeExtension : ITypeExtension
{
    public bool CanExtend(string qualifiedTypeName)
    {
        return qualifiedTypeName == "global::Microsoft.UI.Xaml.Media.Brush" || qualifiedTypeName == "global::Microsoft.UI.Xaml.Media.SolidColorBrush";
    }

    public void WriteAttachedPropertyBuilderExtensions(
      AttachedPropertyInfo prop,
      Func<MethodBuilder> createBuilder)
    {
        createBuilder()
            .AddParameter("global::Windows.UI.Color", "solidColor")
            .WithBody(w => w.AppendLine($"return {prop.Name}(new global::Microsoft.UI.Xaml.Media.SolidColorBrush(solidColor));"));
        createBuilder()
            .AddParameter("string", "hexString")
            .WithBody(w =>
            {
                w.AppendLine("var solidColor = (global::Windows.UI.Color)global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::Windows.UI.Color), hexString);");
                w.AppendLine($"return {prop.Name}(new global::Microsoft.UI.Xaml.Media.SolidColorBrush(solidColor));");
            });

    }

    public void WriteDependencyPropertyExtensions(
      ClassBuilder builder,
      DependencyPropertyExtensionInfo info,
      Func<string, MethodBuilder> createBuilder)
    {
        createBuilder(info.PropertyName)
            .AddParameter("global::Windows.UI.Color", "solidColor")
            .WithBody(w =>
            {
                w.AppendLine($"element.{info.PropertyName} = new global::Microsoft.UI.Xaml.Media.SolidColorBrush(solidColor);");
                w.AppendLine("return element;");
            });
        createBuilder(info.PropertyName)
            .AddParameter("string", "hexString")
            .WithBody(w =>
            {
                w.AppendLine("var solidColor = (global::Windows.UI.Color)global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::Windows.UI.Color), hexString);");
                w.AppendLine($"element.{info.PropertyName} = new global::Microsoft.UI.Xaml.Media.SolidColorBrush(solidColor);");
                w.AppendLine("return element;");
            });

    }

    public void WriteStyleBuilderExtensions(
      ClassBuilder builder,
      StyleBuilderInfo info,
      Func<string, MethodBuilder> createBuilder)
    {
        createBuilder(info.PropertyName)
            .AddParameter("global::Windows.UI.Color", "solidColor")
            .WithBody(w =>
            {
                w.AppendLine("var brush = new global::Microsoft.UI.Xaml.Media.SolidColorBrush(solidColor);");
                w.AppendLine($"return {info.PropertyName}(builder, brush);");
            });
        createBuilder(info.PropertyName)
            .AddParameter("string", "hexString")
            .WithBody(w =>
            {
                w.AppendLine("var solidColor = (global::Windows.UI.Color)global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::Windows.UI.Color), hexString);");
                w.AppendLine($"return {info.PropertyName}(builder, solidColor);");
            });

    }
}
