using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cledev.Blazor.BrowserStorage;

public interface IBrowserStorageService<T> where T : IBrowserStorageItem
{
    Task<List<T>> GetList();
    Task AddToList(T request);
    Task RemoveFromList(T request);
    Task Delete();
}