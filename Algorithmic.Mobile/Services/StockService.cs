using ShareInvest.Infrastructure.Http;
using ShareInvest.Models;
using ShareInvest.Models.OpenAPI.Response;

namespace ShareInvest.Services;

public class StockService
{
    public async Task<ObservableStock[]> GetAsync(string order, bool asc = false)
    {
        var res = await client.TryGetAsync<Stock[]>(string.Concat(nameof(OPTKWFID),
                                                                  '?',
                                                                  nameof(order),
                                                                  '=',
                                                                  order,
                                                                  '&',
                                                                  nameof(asc),
                                                                  '=',
                                                                  asc));
        return res.Select(o => new ObservableStock(o.Code,
                                                   o.Name,
                                                   o.Current,
                                                   o.Rate,
                                                   o.CompareToPreviousDay,
                                                   o.CompareToPreviousSign,
                                                   o.Volume,
                                                   o.TransactionAmount,
                                                   o.State))
                  .ToArray();
    }
    public StockService()
    {
        client = new CoreHttpClient(Status.Address);
    }
    readonly CoreHttpClient client;
}