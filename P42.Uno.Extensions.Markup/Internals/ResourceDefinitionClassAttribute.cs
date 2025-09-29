using System;

#nullable enable
namespace P42.Uno.Extensions.Markup.Internals;

[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
public sealed class ResourceDefinitionClassAttribute : Attribute
{
    public ResourceDefinitionClassAttribute(Type type) => this.Type = type;

    public Type Type { get; }
}
