namespace P42.Uno.WinUI.Markup;

public partial class PageWrapper : Page, IWrappedPage
{
    private readonly Grid _grid;
    private readonly Button _backButton;
    private Page? _wrappedPage;

    public PageWrapper()
    {
        var backButtonStyle = (Style)Resources["NavigationBackButtonNormalStyle"];

        Content = _grid = new Grid()
            .Stretch()
            .RowsX(40, "*")
            .Children(
                new Button()
                    .Name(out _backButton)
                    //.Content("<-- BACK JACK")
                    .Style(backButtonStyle)
                    .AddClickHandler(OnBackButtonClicked)
            );

#if HAS_UNO
        var platformOffset = VisibleBoundsPadding.WindowPadding;
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
            if (_wrappedPage != null)
            {
                _wrappedPage
                    .Stretch()
                    .RowColX(1, 0);
                _grid.Children.Add(_wrappedPage);
            }
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
