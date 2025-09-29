using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace P42.Uno.Extensions.Markup.Generators.Extensibility;

internal static class ExtensibilityLocator
{
    public static ITypeExtension[] Extensions { get; } =
        [.. typeof(ExtensibilityLocator)
                .Assembly
                .GetTypes()
                .Where
                (x => 
                    typeof(P42.Uno.Extensions.Markup.Generators.Extensibility.ITypeExtension).IsAssignableFrom(x)
                    && !x.IsInterface 
                    && !x.IsAbstract
                )
                .Select(x => (ITypeExtension)Activator.CreateInstance(x))
        ];
}
