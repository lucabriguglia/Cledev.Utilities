using Cledev.Core.Commands;
using Cledev.Core.Events;

namespace Cledev.Example.Shared;

public class DeleteItem : CommandBase
{
    public Guid Id { get; }

    public DeleteItem(Guid id)
    {
        Id = id;
    }
}

public record ItemDeleted(Guid Id) : EventBase;