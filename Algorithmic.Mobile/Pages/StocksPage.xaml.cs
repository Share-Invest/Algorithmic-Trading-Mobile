using ShareInvest.ViewModels;

using System.Diagnostics;

namespace ShareInvest.Pages;

public partial class StocksPage : ContentPage
{
    public StocksPage(StocksViewModel vm)
    {
        InitializeComponent();
#if ANDROID
        Platform.CurrentActivity.Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
#endif
        BindingContext = vm;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
#if DEBUG
        Debug.WriteLine(nameof(OnAppearing));
#endif
        await ViewModel.InitializeAsync();
    }
    protected override async void OnDisappearing()
    {
        base.OnDisappearing();
#if DEBUG
        Debug.WriteLine(nameof(OnDisappearing));
#endif
        await ViewModel.DisposeAsync();
    }
    void RemainingItemsThresholdReached(object sender,
                                        EventArgs e)
    {
        if (ViewModel.IsNotBusy)
            ViewModel.LoadStocks();
    }
    StocksViewModel ViewModel
    {
        get => BindingContext as StocksViewModel;
    }
}