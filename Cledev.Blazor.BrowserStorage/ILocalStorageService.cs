namespace Cledev.Blazor.BrowserStorage;

public interface ILocalStorageService<T> : IBrowserStorageService<T> where T : IBrowserStorageItem
{
}