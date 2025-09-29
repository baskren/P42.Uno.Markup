using System;

#nullable enable
namespace P42.Uno.Extensions.Markup.Generator;

[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
public sealed class GenerateMarkupForAssemblyAttribute : Attribute
{
    public GenerateMarkupForAssemblyAttribute(Type referenceType)
    {
    }
}
