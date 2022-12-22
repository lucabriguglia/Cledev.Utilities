namespace Cledev.Core.Events;

public interface IEvent
{
    //Guid Id { get; init; }
    DateTimeOffset TimeStamp { get; init; }

    //Guid TargetId { get; init; }
    //string TargetType { get; init; }

    //string? IdentityUserId { get; init; }
}
