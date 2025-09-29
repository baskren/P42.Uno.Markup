using System;

#nullable enable
namespace P42.Uno.Extensions.Markup.Internals;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public sealed class ResourceKeyDefinitionAttribute : Attribute
{
    public ResourceKeyDefinitionAttribute(Type propertyType, string key)
    {
        Key = key;
        PropertyType = propertyType;
    }

    public string Key { get; }

    public Type PropertyType { get; }

    public Type? TargetType { get; set; }
}
