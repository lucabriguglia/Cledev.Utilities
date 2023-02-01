﻿using Cledev.Core.Requests;
using Cledev.Core.Results;
using Cledev.Example.Server.Data;
using Cledev.Example.Shared;
using Cledev.Server.Caching;
using Microsoft.EntityFrameworkCore;

namespace Cledev.Example.Server.Handlers;

public class GetItemHandler : IRequestHandler<GetItem, GetItemResponse>
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ICacheManager _cacheManager;

    public GetItemHandler(ApplicationDbContext dbContext, ICacheManager cacheManager)
    {
        _dbContext = dbContext;
        _cacheManager = cacheManager;
    }

    public async Task<Result<GetItemResponse>> Handle(GetItem query)
    {
        var item = await _dbContext.Items.SingleOrDefaultAsync(item => item.Id == query.Id);

        if (item is null)
        {
            return new Failure(ErrorCodes.NotFound, "Item", $"Item with id {query.Id} not found");
        }

        return new GetItemResponse(item.Id, item.Name, item.Description);
    }
}