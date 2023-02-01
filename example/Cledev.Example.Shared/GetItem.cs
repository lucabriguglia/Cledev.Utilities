using Cledev.Core.Requests;

namespace Cledev.Example.Shared;

public record GetItem(Guid Id) : RequestBase<GetItemResponse>;

public record GetItemResponse(Guid Id, string? Name, string? Description);