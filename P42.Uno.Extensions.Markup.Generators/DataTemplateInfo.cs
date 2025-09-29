using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

#nullable enable
namespace P42.Uno.Extensions.Markup.Generators;

//[GeneratedEquality]
internal partial record DataTemplateInfo(string PropertyTypeFullyQualifiedName,
      bool PropertyTypeIsControlTemplate,
      bool PropertyTypeIsDataTemplate,
      bool PropertyTypeIsDataTemplateSelector,
      bool PropertyTypeIsDataTemplateFromParent,
      string PropertyName,
      string PropertyTypeName,
      GenerationTypeInfo GenerationTypeInfo) : BaseModel(GenerationTypeInfo), IEquatable<DataTemplateInfo>
{

}
