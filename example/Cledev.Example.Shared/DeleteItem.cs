using Cledev.Core.Events;
using Cledev.Core.Requests;

namespace Cledev.Example.Shared;

public class DeleteItem : RequestBase
{
    public Guid Id { get; }

    public DeleteItem(Guid id)
    {
        Id = id;
    }
}

public record ItemDeleted(Guid Id) : EventBase;