using ShareInvest.ViewModels;

namespace ShareInvest.Pages;

public partial class StocksPage : ContentPage
{
    public StocksPage(StocksViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await ViewModel.InitializeAsync();
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