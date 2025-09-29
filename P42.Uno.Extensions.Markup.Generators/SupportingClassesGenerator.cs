using System;
using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace P42.Uno.Extensions.Markup.Generators;

[Generator]
public class SupportingClassesGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var provider = context.SyntaxProvider.CreateSyntaxProvider
            (
                predicate: (c,_) => c is ClassDeclarationSyntax,
                transform: (n, _) => (ClassDeclarationSyntax)n.Node
            ).Where(m => m is not null);

        var compilation = context.CompilationProvider.Combine(provider.Collect());

        context.RegisterSourceOutput(compilation,
            (spc, source) => Execute(spc, source.Left, source.Right));
        
    }

    private void Execute(SourceProductionContext context, 
        Compilation compilation, 
        ImmutableArray<ClassDeclarationSyntax> typeList)
    {
        var asm = GetType().Assembly;
        var asmName = asm.GetName().Name;
        var resourcesRoot = asmName + ".Resources.";
        var resources = asm.GetManifestResourceNames();

        foreach (var resource in resources)
        {
            if (!resource.EndsWith(".cs"))
                continue;
            var name = resource.Substring(resourcesRoot.Length, resource.Length - 3 - resourcesRoot.Length);
            using var stream = asm.GetManifestResourceStream(resource);
            using var reader = new StreamReader(stream);
            var code = reader.ReadToEnd();
            context.AddSource($"{name}.g.cs", code);
        }

        /*
        var code = """
            namespace SampleSourceGenerator;

            public static class ClassNames
            {
                public static string Names = "Hello from Roslyn";
            }
            """;

        context.AddSource("ClassName.g.cs", code);
        */
    }
}
