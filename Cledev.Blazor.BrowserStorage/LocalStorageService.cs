using Microsoft.JSInterop;

namespace Cledev.Blazor.BrowserStorage;

public class LocalStorageService<T> : BrowserStorageService<T>, ILocalStorageService<T> where T : IBrowserStorageItem
{
    public LocalStorageService(IJSRuntime jSRuntime) : base("localStorage", jSRuntime)
    {
    }
}