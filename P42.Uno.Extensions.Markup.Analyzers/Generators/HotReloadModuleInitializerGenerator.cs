using CodeGenHelpers;
using Microsoft.CodeAnalysis;
using System;
using System.Threading;

#nullable enable
namespace P42.Uno.Extensions.Markup.Analyzers.Generators;

[Generator("C#", [])]
public sealed class HotReloadModuleInitializerGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var incrementalValueProvider1 = context.CompilationProvider.Select((compilation, _) => compilation.Assembly.Name);
        var incrementalValueProvider2 = context.CompilationProvider.Select((compilation, _) => compilation.GetTypeByMetadataName("Uno.Extensions.Markup.Internals.ModuleConfiguration") != null);
        
        context.RegisterSourceOutput(IncrementalValueProviderExtensions.Combine(incrementalValueProvider1, incrementalValueProvider2), (ctx, source) =>
        {
            if (!source.Right)
                return;
            var assembly = source.Left;
            var classBuilder = CodeBuilder
                .Create(assembly)
                .AddClass("__MarkupModuleInitializer")
                .AddAttribute("global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)")
                .MakeInternalClass()
                .MakeStaticClass();
            classBuilder
                .AddMethod(nameof(Initialize))
                .WithAccessModifier(Accessibility.Public)
                .AddAttribute("global::System.Runtime.CompilerServices.ModuleInitializer")
                .MakeStaticMethod()
                .WithBody(b => b.Append($"#if !IS_HOT_RELOAD_DISABLED && (DEBUG || IS_HOT_RELOAD_ENABLED)\r\n\tvar isHotReloadEnabled = true;\r\n#else\r\n\tvar isHotReloadEnabled = false;\r\n#endif\r\n\tglobal::Uno.Extensions.Markup.Internals.ModuleConfiguration.Configure(\"{assembly}\", isHotReloadEnabled);"));

            ctx.AddSource(assembly + ".MarkupModuleInitializer.g.cs", classBuilder.Build());
        });
    }
}
