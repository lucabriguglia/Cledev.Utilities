using Cledev.Core.Events;
using Cledev.Core.Queries;
using Cledev.Core.Results;
using Cledev.Example.Shared;

namespace Cledev.Example.Server.Handlers;

public class GetCreateItemHandler : IQueryHandler<GetCreateItem, CreateItem>
{
    public Task<Result<CreateItem>> Handle(GetCreateItem query)
    {
        throw new NotImplementedException();
    }
    
    public async Task<Result2<CreateItem>> Handle2T(GetCreateItem query)
    {
        await Task.CompletedTask;

        return Result2<CreateItem>.Ok(new CreateItem());
        return Result2<CreateItem>.Fail(ErrorCodes.NotFound, "Item", $"Item not found");

        return new CreateItem();
        return new Failure(ErrorCodes.NotFound, "Item", $"Item not found");
    }
    
    public async Task<Result3<CreateItem>> Handle3T(GetCreateItem query)
    {
        await Task.CompletedTask;

        return Result3<CreateItem>.Ok(new CreateItem());
        return Result3<CreateItem>.Fail(ErrorCodes.NotFound, "Item", $"Item not found");
        
        return new Success<CreateItem>(new CreateItem());
        return new Failure(ErrorCodes.NotFound, "Item", $"Item not found");

        return new CreateItem();
        return Array.Empty<IEvent>();
    }

    public async Task<Result3> Handle3(GetCreateItem query)
    {
        await Task.CompletedTask;

        return Result3.Ok();
        return Result3.Fail(ErrorCodes.NotFound, "Item", $"Item not found");

        return new Success();
        return new Failure(ErrorCodes.NotFound, "Item", $"Item not found");
        
        return Array.Empty<IEvent>();
    }
}