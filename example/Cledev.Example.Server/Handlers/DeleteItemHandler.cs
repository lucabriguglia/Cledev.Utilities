using Cledev.Core.Requests;
using Cledev.Core.Results;
using Cledev.Example.Server.Data;
using Cledev.Example.Shared;
using Microsoft.EntityFrameworkCore;

namespace Cledev.Example.Server.Handlers;

public class DeleteItemHandler : IRequestHandler<DeleteItem>
{
    private readonly ApplicationDbContext _dbContext;

    public DeleteItemHandler(ApplicationDbContext dbContext) => _dbContext = dbContext;

    public async Task<Result> Handle(DeleteItem command)
    {
        var item = await _dbContext.Items.SingleOrDefaultAsync(item => item.Id == command.Id);

        if (item is null)
        {
            return new Failure(ErrorCodes.NotFound, "Item", $"Item with id {command.Id} not found");
        }

        _dbContext.Items.Remove(item);

        await _dbContext.SaveChangesAsync();

        var itemDeleted = new ItemDeleted(item.Id);

        return new Success(itemDeleted);
    }
}