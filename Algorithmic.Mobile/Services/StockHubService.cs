using Microsoft.AspNetCore.SignalR.Client;

using ShareInvest.Infrastructure;
using ShareInvest.Infrastructure.Socket;
using ShareInvest.Properties;

namespace ShareInvest.Services;

public class StockHubService : CoreSignalR,
                               IHubService
{
    public StockHubService() : base(string.Concat(Status.Address,
                                                  Resources.KIWOOM))
    {
        _ = On("");
    }
    public HubConnectionState State
    {
        get => Hub.State;
    }
    public async Task AddToGroupAsync(string code)
    {
        await Hub.SendAsync(nameof(AddToGroupAsync),
                            Hub.ConnectionId,
                            code);
    }
    public async Task RemoveFromGroupAsync(string code)
    {
        await Hub.SendAsync(nameof(RemoveFromGroupAsync),
                            Hub.ConnectionId,
                            code);
    }
    public async Task StartAsync()
    {
        await Hub.StartAsync();
    }
    public async Task StopAsync()
    {
        await Hub.StopAsync();
    }
}