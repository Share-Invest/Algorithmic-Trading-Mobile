using ShareInvest.Pages;

namespace ShareInvest.Configures;

public static class PagesExtensions
{
    public static MauiAppBuilder ConfigurePages(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<StocksPage>();

        return builder;
    }
}