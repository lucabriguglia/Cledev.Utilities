using Cledev.Core.Queries;
using Cledev.Core.Results;
using Cledev.Example.Server.Data;
using Cledev.Example.Shared;
using Microsoft.EntityFrameworkCore;

namespace Cledev.Example.Server.Handlers;

public class GetUpdateItemHandler : IQueryHandler<GetUpdateItem, UpdateItem>
{
    private readonly ApplicationDbContext _dbContext;

    public GetUpdateItemHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<UpdateItem>> Handle(GetUpdateItem query)
    {
        var item = await _dbContext.Items.SingleOrDefaultAsync(item => item.Id == query.Id);

        if (item is null)
        {
            return new Failure(FailureCodes.NotFound, "Item", $"Item with id {query.Id} not found");
        }

        return new UpdateItem
        {
            Id = item.Id,
            Name = item.Name,
            Description = item.Description
        };
    }
}