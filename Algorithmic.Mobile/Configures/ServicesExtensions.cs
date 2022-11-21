using ShareInvest.Services;

namespace ShareInvest.Configures;

public static class ServicesExtensions
{
    public static MauiAppBuilder ConfigureServices(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton(Connectivity.Current)
                        .AddSingleton<StockService>();

        return builder;
    }
}