using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;

namespace P42.Uno.Markup;
public static class ScrollContentPresenterExtensions
{
    public static ScrollContentPresenter CanContentRenderOutsideBounds(this ScrollContentPresenter element, bool value = true) 
    {  element.CanContentRenderOutsideBounds = value; return element; }

    public static ScrollContentPresenter CanHorizontallyScroll(this ScrollContentPresenter element, bool value = true)
    { element.CanHorizontallyScroll = value; return element; }

    public static ScrollContentPresenter CanVerticallyScroll(this ScrollContentPresenter element, bool value = true)
    { element.CanVerticallyScroll = value; return element; }

    public static ScrollContentPresenter ScrollOwner(this ScrollContentPresenter element, object value)
    { element.ScrollOwner = value; return element; }

    public static ScrollContentPresenter SizesContentToTemplatedParent(this ScrollContentPresenter element, bool value = true)
    { element.SizesContentToTemplatedParent = value; return element; }

}
