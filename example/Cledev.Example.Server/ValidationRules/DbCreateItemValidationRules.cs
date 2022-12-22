using Cledev.Example.Server.Data;
using Cledev.Example.Shared;
using Microsoft.EntityFrameworkCore;

namespace Cledev.Example.Server.ValidationRules;

public class DbCreateItemValidationRules : ICreateItemValidationRules
{
    private readonly ApplicationDbContext _dbContext;

    public DbCreateItemValidationRules(ApplicationDbContext dbContext) => 
        _dbContext = dbContext;

    public async Task<bool> IsItemNameUnique(string name) =>
        await _dbContext.Items.AnyAsync(item => item.Name == name) is false;
}