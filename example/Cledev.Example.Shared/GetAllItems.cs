using Cledev.Core.Requests;

namespace Cledev.Example.Shared;

public record GetAllItems : RequestBase<GetAllItemsResponse>;

public class GetAllItemsResponse
{
    public IList<Item> Items { get; set; } = new List<Item>();

    public record Item(Guid Id, string? Name, string? Description);
}