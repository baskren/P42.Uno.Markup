using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using P42.Uno.Extensions.Markup.Generators.Extensions;

#nullable enable
namespace P42.Uno.Extensions.Markup.Generators;

//[GeneratedEquality]
internal partial record StyleBuilderInfo(
    string PropertyContainingTypeFullyQualified, 
    string PropertyTypeFullyQualified, 
    string PropertyTypeName, 
    string PropertyName, 
    bool PropertyTypeIsOrDerivesFromFrameworkTemplate, 
    bool PropertyTypeIsOrDerivesFromDataTemplate, 
    bool IsNullableValueType, 
    GenerationTypeInfo GenerationTypeInfo) : BaseModel(GenerationTypeInfo)
{
    public static StyleBuilderInfo From(IPropertySymbol propertySymbol, GenerationTypeInfo typeInfo)
    {
        var propertyTypeIsOrDerivesFromFrameworkTemplate = false;
        var propertyTypeIsOrDerivesFromDataTemplate = false;
        var type = propertySymbol.Type;
        var val = type;

        while (val != null)
        {
            if (val.Name != "DataTemplate")
            {
                val = val.BaseType;
                continue;
            }
            var fullyQualifiedTypeExcludingGlobal = val.GetFullyQualifiedTypeExcludingGlobal();
            if (fullyQualifiedTypeExcludingGlobal == "Microsoft.UI.Xaml.DataTemplate")
            {
                propertyTypeIsOrDerivesFromDataTemplate = true;
                propertyTypeIsOrDerivesFromFrameworkTemplate = true;
                break;
            }
            if (fullyQualifiedTypeExcludingGlobal == "Microsoft.UI.Xaml.FrameworkTemplate")
            {
                propertyTypeIsOrDerivesFromFrameworkTemplate = true;
                break;
            }
            val = val.BaseType;
        }

        return new StyleBuilderInfo(
            propertySymbol.ContainingType.GetFullyQualifiedTypeIncludingGlobal(), 
            type.GetFullyQualifiedTypeIncludingGlobal(), 
            type.Name, 
            propertySymbol.Name, 
            propertyTypeIsOrDerivesFromFrameworkTemplate, 
            propertyTypeIsOrDerivesFromDataTemplate, 
            type.OriginalDefinition.SpecialType == SpecialType.System_Nullable_T /*0x20*/, 
            typeInfo
            );
    }
}
