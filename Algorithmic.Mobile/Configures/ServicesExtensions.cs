using Microsoft.Extensions.DependencyInjection.Extensions;

using ShareInvest.Infrastructure;
using ShareInvest.Mappers;
using ShareInvest.Services;

namespace ShareInvest.Configures;

public static class ServicesExtensions
{
    public static MauiAppBuilder ConfigureServices(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton(Connectivity.Current)
                        .AddSingleton<StockService>();

        builder.Services.TryAddTransient<IPropertyService, PropertyService>();
        builder.Services.TryAddTransient<IHubService, StockHubService>();

        return builder;
    }
    public static MauiAppBuilder UseMauiMaps(this MauiAppBuilder builder)
    {
        return builder;
    }
}