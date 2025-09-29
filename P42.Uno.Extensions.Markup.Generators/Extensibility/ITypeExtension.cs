using CodeGenHelpers;
using System;

#nullable enable
namespace P42.Uno.Extensions.Markup.Generators.Extensibility;

internal interface ITypeExtension
{
    bool CanExtend(string qualifiedTypeName);

    void WriteAttachedPropertyBuilderExtensions(
      AttachedPropertyInfo prop,
      Func<MethodBuilder> createBuilder);

    void WriteDependencyPropertyExtensions(
      ClassBuilder builder,
      DependencyPropertyExtensionInfo info,
      Func<string,MethodBuilder> createBuilder);

    void WriteStyleBuilderExtensions(
      ClassBuilder builder,
      StyleBuilderInfo info,
      Func<string, MethodBuilder> createBuilder);
}
