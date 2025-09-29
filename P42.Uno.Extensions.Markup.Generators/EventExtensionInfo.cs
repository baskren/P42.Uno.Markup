using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.CodeAnalysis;
using P42.Uno.Extensions.Markup.Generators;
using P42.Uno.Extensions.Markup.Generators.Extensions;

namespace P42.Uno.Extensions.Markup.Generators;

internal partial record EventExtensionInfo(
        string EventTypeFullyQualified,
        string EventName,
        bool EventHasPublicAdder,
        Accessibility EventDeclaredAccessibility,
        bool IsNotSealedAndIsShadowing,
        GenerationTypeInfo GenerationTypeInfo
    ) : BaseModel(GenerationTypeInfo)
{
    public static EventExtensionInfo From(
            IEventSymbol eventSymbol,
            GenerationTypeInfo generationTypeInfo,
            bool isNotSealedAndIsShadowing)
    {
        var type = eventSymbol.Type;

        return new EventExtensionInfo(
                eventSymbol.Type.GetFullyQualifiedTypeIncludingGlobal(),
                eventSymbol.Name,
                eventSymbol.HasPublicAdder(),
                eventSymbol.DeclaredAccessibility,
                isNotSealedAndIsShadowing,
                generationTypeInfo
            );
    }

}
