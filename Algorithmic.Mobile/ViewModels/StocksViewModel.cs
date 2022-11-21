using ShareInvest.Models;
using ShareInvest.Properties;
using ShareInvest.Services;

using System.Collections.ObjectModel;

namespace ShareInvest.ViewModels;

public class StocksViewModel : ViewModelBase
{
    public ObservableCollection<ObservableStock> StockCollection
    {
        get;
    }
    public override async Task InitializeAsync()
    {
        if (IsNotBusy)
            try
            {
                if (NetworkAccess.Internet == connectivity.NetworkAccess)
                {
                    IsBusy = true;
#if ANDROID
                    Platform.CurrentActivity.Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
#endif
                    Stocks = await service.GetAsync(Title);

                    LoadStocks();
                }
                else
                {
                    Title = nameof(connectivity.NetworkAccess);

                    await DisplayAlert(Resources.NETWORKACCESS);
                }
            }
            catch (Exception ex)
            {
                Title = nameof(Exception);

                await DisplayAlert(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
    }
    public void LoadStocks()
    {
        IsBusy = true;

        var length = (ChunkCount + 1) * chunkSize;

        for (int i = StockCollection.Count; i < length; i++)
        {
            if (i < Stocks.Length)
            {
                StockCollection.Add(Stocks[i]);

                continue;
            }
            break;
        }
        ChunkCount++;

        IsBusy = false;
    }
    public StocksViewModel(StockService service,
                           IConnectivity connectivity)
    {
        chunkSize = 0x10;
        this.service = service;
        this.connectivity = connectivity;

        Title = nameof(Models.OpenAPI.Response.OPTKWFID.MarketCap);

        StockCollection = new ObservableCollection<ObservableStock>();
    }
    ObservableStock[] Stocks
    {
        get; set;
    }
    uint ChunkCount
    {
        get; set;
    }
    readonly uint chunkSize;
    readonly StockService service;
    readonly IConnectivity connectivity;
}