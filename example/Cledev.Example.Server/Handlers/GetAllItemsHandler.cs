using Cledev.Core.Requests;
using Cledev.Core.Results;
using Cledev.Example.Server.Data;
using Cledev.Example.Shared;
using Cledev.Server.Caching;
using Microsoft.EntityFrameworkCore;

namespace Cledev.Example.Server.Handlers;

public class GetAllItemsHandler : IRequestHandler<GetAllItems, GetAllItemsResponse>
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ICacheManager _cacheManager;

    public GetAllItemsHandler(ApplicationDbContext dbContext, ICacheManager cacheManager)
    {
        _dbContext = dbContext;
        _cacheManager = cacheManager;
    }

    public async Task<Result<GetAllItemsResponse>> Handle(GetAllItems query)
    {
        async Task<GetAllItemsResponse?> AcquireAsync()
        {
            var items = await _dbContext.Items.ToListAsync();

            return new GetAllItemsResponse
            {
                Items = items.Select(item => new GetAllItemsResponse.Item(item.Id, item.Name, item.Description)).ToList()
            };
        }

        return (await _cacheManager.GetOrSetAsync("Items", AcquireAsync))!;
    }
}