﻿using Cledev.Core.Requests;
using Cledev.Core.Results;
using Cledev.Example.Server.Data;
using Cledev.Example.Server.Data.Entities;
using Cledev.Example.Shared;

namespace Cledev.Example.Server.Handlers;

public class CreateItemHandler : IRequestHandler<CreateItem>
{
    private readonly ApplicationDbContext _dbContext;

    public CreateItemHandler(ApplicationDbContext dbContext) => _dbContext = dbContext;

    public async Task<Result> Handle(CreateItem command)
    {
        var item = new Item(Guid.NewGuid(), command.Name!, command.Description!);

        _dbContext.Items.Add(item);

        await _dbContext.SaveChangesAsync();

        var itemCreated = new ItemCreated(item.Id, item.Name, item.Description);

        return new Success(itemCreated);
    }
}