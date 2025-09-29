using CodeGenHelpers;
using System;

#nullable enable
namespace P42.Uno.Extensions.Markup.Generators.Extensibility;

internal class VisibilityExtensions : ITypeExtension
{
    public bool CanExtend(string qualifiedTypeName)
    {
        return false;
        //return qualifiedTypeName == "global::Microsoft.UI.Xaml.Visibility";
    }

    public void WriteAttachedPropertyBuilderExtensions(
      AttachedPropertyInfo prop,
      Func<MethodBuilder> createBuilder)
    {
        createBuilder()
            .AddParameter("Func<bool>", "propertyBinding")
            .AddParameterWithNullValue("[CallerArgumentExpression(\"propertyBinding\")]string?", "propertyBindingExpression")
            .WithBody(w => w.AppendLine($"return {prop.Name}(propertyBinding, b => b ? global::Microsoft.UI.Xaml.Visibility.Visible : global::Microsoft.UI.Xaml.Visibility.Collapsed, propertyBindingExpression);"));
    }

    public void WriteDependencyPropertyExtensions(
      ClassBuilder builder,
      DependencyPropertyExtensionInfo info,
      Func<string, MethodBuilder> createBuilder)
    {
        createBuilder(info.PropertyName)
            .AddParameter("Func<bool>", "propertyBinding")
            .AddParameterWithNullValue("[CallerArgumentExpression(\"propertyBinding\")]string?", "propertyBindingExpression")
            .WithBody(w => w.AppendLine($"return {info.PropertyName}(element, propertyBinding, b => b ? global::Microsoft.UI.Xaml.Visibility.Visible : global::Microsoft.UI.Xaml.Visibility.Collapsed, propertyBindingExpression);"));
    }

    public void WriteStyleBuilderExtensions(
      ClassBuilder builder,
      StyleBuilderInfo info,
      Func<string, MethodBuilder> createBuilder)
    {
    }
}
