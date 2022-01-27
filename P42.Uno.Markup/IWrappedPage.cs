using System;
using Windows.UI.Xaml.Navigation;

namespace P42.Uno
{
    public interface IWrappedPage
    {
        void OnNavigatedFrom(NavigationEventArgs e);

        void OnNavigatedTo(NavigationEventArgs e);

        void OnNavigatingFrom(NavigatingCancelEventArgs e);
    }
}