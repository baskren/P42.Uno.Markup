using CodeGenHelpers;
using Microsoft.CodeAnalysis;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

#nullable enable
namespace P42.Uno.Extensions.Markup.Generators;

[Generator("C#", [])]
public class CallerArgumentExpressionAttributeGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context1)
    {
        var incrementalValueProvider = IncrementalValueProviderExtensions.Select(context1.CompilationProvider, (compilation, _) => ShouldGenerate(compilation));

        context1.RegisterSourceOutput(incrementalValueProvider, (context2, shouldGenerate) =>
        {
            if (!shouldGenerate)
                return;

            var onlyAutoProp = CodeBuilder
                .Create("System.Runtime.CompilerServices")
                .AddNamespaceImport("System")
                .AddClass("CallerArgumentExpressionAttribute")
                .SetBaseClass("Attribute")
                .WithAccessModifier(Accessibility.Internal)
                .Sealed()
                .AddAttribute("AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)")
                .AddConstructor(new Accessibility?(Accessibility.Public))
                .AddParameter("string", "parameterName")
                .WithBody(w => w.AppendLine("ParameterName = parameterName;"))
                .Class
                .AddProperty(
                    "ParameterName", 
                    new Accessibility?(Accessibility.Public))
                .SetType("string")
                .UseGetOnlyAutoProp();

            context2.AddSource(onlyAutoProp.FullyQualifiedName, onlyAutoProp.Build());
        });
    }

    private static bool ShouldGenerate(Compilation compilation) 
        => !ImmutableArrayExtensions.Any
            (
                compilation.GetTypesByMetadataName(QualifiedTypeName.CallerArgumentExpressionAttribute), 
                x => x.DeclaredAccessibility == Accessibility.Public || x.ContainingAssembly.Equals(compilation.Assembly, SymbolEqualityComparer.Default)
            );
}
