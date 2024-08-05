using Microsoft.UI.Xaml.Media;
using ElementType = Microsoft.UI.Xaml.Controls.PersonPicture;

namespace P42.Uno.Markup;
public static class PersonPictureExtensions
{

    public static TElement BadgeGlyph<TElement>(this TElement element, string value) where TElement : ElementType
    { element.BadgeGlyph = value; return element; }

    public static TElement BadgeImageSource<TElement>(this TElement element, ImageSource value) where TElement : ElementType
    { element.BadgeImageSource = value; return element; }

    public static TElement BadgeNumber<TElement>(this TElement element, int value) where TElement : ElementType
    { element.BadgeNumber = value; return element; }

    public static TElement BadgeText<TElement>(this TElement element, string value) where TElement : ElementType
    { element.BadgeText = value; return element; }

    public static TElement Contact<TElement>(this TElement element, Windows.ApplicationModel.Contacts.Contact value) where TElement : ElementType
    { element.Contact = value; return element; }

    public static TElement DisplayName<TElement>(this TElement element, string value) where TElement : ElementType
    { element.DisplayName = value; return element; }

    public static TElement Initials<TElement>(this TElement element, string value) where TElement : ElementType
    { element.Initials = value; return element; }

    public static TElement IsGroup<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.IsGroup = value; return element; }

    public static TElement PreferSmallImage<TElement>(this TElement element, bool value = true) where TElement : ElementType
    { element.PreferSmallImage = value; return element; }

    public static TElement ProfilePicture<TElement>(this TElement element, ImageSource value) where TElement : ElementType
    { element.ProfilePicture = value; return element; }

}
