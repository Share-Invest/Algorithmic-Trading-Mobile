using ShareInvest.Models;
using ShareInvest.Pages;

namespace ShareInvest.ViewModels;

public class ShellViewModel
{
    public ShellViewModel()
    {
        unspecified = AppTheme.Dark > Application.Current.PlatformAppTheme;

        Create();
    }
    public ShellViewModel(bool unspecified)
    {
        this.unspecified = unspecified;

        Create();
    }
    public AppSection Account
    {
        get; set;
    }
    public AppSection Stock
    {
        get; set;
    }
    void Create()
    {
        Account = new AppSection
        {
            TargetType = typeof(AccountsPage),
            Title = Properties.Resources.Account,
            Icon = unspecified ? "clock_dark.svg" :
                                 "clock.svg"
        };
        Stock = new AppSection
        {
            TargetType = typeof(StocksPage),
            Title = Properties.Resources.Stock,
            Icon = unspecified ? "share_dark.svg" :
                                 "share.svg"
        };
    }
    readonly bool unspecified;
}