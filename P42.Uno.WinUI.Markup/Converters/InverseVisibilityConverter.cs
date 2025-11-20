using P42.Utils.Uno;

namespace P42.Uno.WinUI.Markup;

// ReSharper disable once UnusedType.Global
public class InverseVisibilityConverter() : 
    FuncConverter<Visibility, Visibility>(source => source.Inverse(), dest => dest.Inverse());
