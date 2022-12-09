using Microsoft.Extensions.DependencyInjection.Extensions;

using ShareInvest.ViewModels;

namespace ShareInvest.Configures;

public static class ViewModelsExtensions
{
    public static MauiAppBuilder ConfigureViewModels(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<AccountsViewModel>()
                        .AddSingleton<StocksViewModel>();

        builder.Services.TryAddTransient<BalancesViewModel>();

        return builder;
    }
}