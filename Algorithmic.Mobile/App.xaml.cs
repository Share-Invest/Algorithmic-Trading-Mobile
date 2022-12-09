using ShareInvest.Pages;
using ShareInvest.Shells;

namespace ShareInvest;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

#if WINDOWS||MACCATALYST

#else
        MainPage = new MobileShell();
#endif
        Routing.RegisterRoute(nameof(StocksPage), typeof(StocksPage));
        Routing.RegisterRoute(nameof(AccountsPage), typeof(AccountsPage));
    }
}