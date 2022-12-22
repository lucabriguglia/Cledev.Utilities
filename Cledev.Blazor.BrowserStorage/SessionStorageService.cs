using Microsoft.JSInterop;

namespace Cledev.Blazor.BrowserStorage;

public class SessionStorageService<T> : BrowserStorageService<T>, ISessionStorageService<T> where T : IBrowserStorageItem
{
    public SessionStorageService(IJSRuntime jSRuntime) : base("sessionStorage", jSRuntime)
    {
    }
}