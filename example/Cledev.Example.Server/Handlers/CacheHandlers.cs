using Cledev.Core.Events;
using Cledev.Example.Shared;
using Cledev.Server.Caching;

namespace Cledev.Example.Server.Handlers;

public class CacheHandlers : 
    IEventHandler<ItemCreated>,
    IEventHandler<ItemDeleted>,
    IEventHandler<ItemUpdated>
{
    private readonly ICacheManager _cacheManager;

    public CacheHandlers(ICacheManager cacheManager)
    {
        _cacheManager = cacheManager;
    }

    public async Task Handle(ItemCreated @event) => 
        await ClearItemsCache();

    public async Task Handle(ItemDeleted @event) => 
        await ClearItemsCache();

    public async Task Handle(ItemUpdated @event) => 
        await ClearItemsCache();

    private async Task ClearItemsCache()
    {
        await Task.CompletedTask;
        _cacheManager.Remove("Items");
    }
}