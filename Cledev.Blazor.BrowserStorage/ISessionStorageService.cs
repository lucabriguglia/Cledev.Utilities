namespace Cledev.Blazor.BrowserStorage;

public interface ISessionStorageService<T> : IBrowserStorageService<T> where T : IBrowserStorageItem
{
}