using CodeGenHelpers;
using System;

#nullable enable
namespace P42.Uno.Extensions.Markup.Generators.Extensibility;

internal class ColorTypeExtension : ITypeExtension
{
    public bool CanExtend(string qualifiedTypeName)
    {
        return false;
        //return qualifiedTypeName == "global::Windows.UI.Color";
    }

    public void WriteAttachedPropertyBuilderExtensions(
      AttachedPropertyInfo prop,
      Func<MethodBuilder> createBuilder)
    {
        createBuilder()
            .AddParameter("string", "hexString")
            .WithBody(w => w.AppendLine($"return {prop.Name}((global::Windows.UI.Color)global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::Windows.UI.Color), hexString));"));
    }

    public void WriteDependencyPropertyExtensions(
      ClassBuilder builder,
      DependencyPropertyExtensionInfo info,
      Func<string, MethodBuilder> createBuilder)
    {
        createBuilder(info.PropertyName)
            .AddParameter("string", "hexString")
            .WithBody(w => w.AppendLine($"return element.{info.PropertyName}((global::Windows.UI.Color)global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::Windows.UI.Color), hexString));"));
    }

    public void WriteStyleBuilderExtensions(
      ClassBuilder builder,
      StyleBuilderInfo info,
      Func<string, MethodBuilder> createBuilder)
    {
        createBuilder(info.PropertyName)
            .AddParameter("string", "hexString")
            .WithBody(w =>
            {
                w.AppendLine("var color = (global::Windows.UI.Color)global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::Windows.UI.Color), hexString);");
                w.AppendLine($"return builder.{info.PropertyName}(color);");
            });
    }
}
