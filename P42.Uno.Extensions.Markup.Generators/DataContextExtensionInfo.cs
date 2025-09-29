using System;
using System.Collections.Generic;
using System.Text;
using P42.Uno.Extensions.Markup.Generators;

namespace P42.Uno.Extensions.Markup.Generators;

internal partial record DataContextExtensionInfo(GenerationTypeInfo GenerationTypeInfo) : BaseModel(GenerationTypeInfo)
{
}
