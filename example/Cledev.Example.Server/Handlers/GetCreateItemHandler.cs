using Cledev.Core.Queries;
using Cledev.Core.Results;
using Cledev.Example.Shared;

namespace Cledev.Example.Server.Handlers;

public class GetCreateItemHandler : IQueryHandler<GetCreateItem, CreateItem>
{
    public async Task<Result<CreateItem>> Handle(GetCreateItem query)
    {
        await Task.CompletedTask;

        return new CreateItem();
    }
}