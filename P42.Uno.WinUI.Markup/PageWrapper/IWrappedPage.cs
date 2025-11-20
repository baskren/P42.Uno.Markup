namespace P42.Uno.WinUI.Markup;

public interface IWrappedPage
{
    void OnNavigatedFrom(NavigationEventArgs e);

    void OnNavigatedTo(NavigationEventArgs e);

    void OnNavigatingFrom(NavigatingCancelEventArgs e);
}
