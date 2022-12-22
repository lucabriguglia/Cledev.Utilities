using Cledev.Core.Queries;

namespace Cledev.Example.Shared;

public record GetItem(Guid Id) : QueryBase<GetItemResponse>;

public record GetItemResponse(Guid Id, string? Name, string? Description);