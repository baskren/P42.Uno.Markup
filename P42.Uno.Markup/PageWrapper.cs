using P42.Uno.Markup;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

namespace P42.Uno;

public partial class PageWrapper : Page, IWrappedPage
{
    private Grid _grid;
    private Button _backButton;
    private Page _wrappedPage;

    public PageWrapper()
    {
        var backButtonStyle = (Style)Resources["NavigationBackButtonNormalStyle"];

        Content = _grid = new Grid()
            .Stretch()
            .Rows(40, "*")
            .Children(
                new Button()
                    .Assign(out _backButton)
                    //.Content("<-- BACK JACK")
                    .Style(backButtonStyle)
                    .AddClickHandler(OnBackButtonClicked)
            );

#if HAS_UNO
        var platformOffset = global::Uno.UI.Toolkit.VisibleBoundsPadding.WindowPadding;
        Padding = platformOffset;
#endif
    }

    private void OnBackButtonClicked(object sender, RoutedEventArgs e)
        => Frame.GoBack();



    #region Navigation overrides
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        if (e.NavigationMode == NavigationMode.New)
        {
            _wrappedPage = e.Parameter as Page;
            _wrappedPage
                .Stretch()
                .RowCol(1, 0);
            if (_wrappedPage != null)   
                _grid.Children.Add(_wrappedPage);

        }

        base.OnNavigatedTo(e);

        if (_wrappedPage is IWrappedPage wrappedPage)
            wrappedPage.OnNavigatedTo(e);
    }

    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
        if (_wrappedPage is IWrappedPage wrappedPage)
            wrappedPage.OnNavigatedFrom(e);

        base.OnNavigatedFrom(e);
    }

    protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
    {
        if (_wrappedPage is IWrappedPage wrappedPage)
            wrappedPage.OnNavigatingFrom(e);

        base.OnNavigatingFrom(e);
    }
    #endregion


    #region IWrappedPage implementation
    void IWrappedPage.OnNavigatedFrom(NavigationEventArgs e) => OnNavigatedFrom(e);
    void IWrappedPage.OnNavigatedTo(NavigationEventArgs e) => OnNavigatedTo(e);
    void IWrappedPage.OnNavigatingFrom(NavigatingCancelEventArgs e) => OnNavigatingFrom(e);
    #endregion
}
