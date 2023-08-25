namespace MarketApp.Client.Service;

using Microsoft.JSInterop;
using System.Threading.Tasks;

public class AlertService
{
    private readonly IJSRuntime _jsRuntime;

    public AlertService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task ShowAlertAsync(string message)
    {
        await _jsRuntime.InvokeVoidAsync("alert", message);
    }
}
