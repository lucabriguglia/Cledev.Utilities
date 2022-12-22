namespace Cledev.Core.Events;

public abstract record EventBase : IEvent
{
    public DateTimeOffset TimeStamp { get; init; } = DateTimeOffset.UtcNow;
}

//public abstract record EventBase(Guid TargetId, string TargetType, string? IdentityUserId, DateTimeOffset TimeStamp) : IEvent
//{
//    public Guid Id { get; init; } = Guid.NewGuid();

//    public static bool ShouldSerializeId() => false;
//    public static bool ShouldSerializeTargetId() => false;
//    public static bool ShouldSerializeTargetType() => false;
//    public static bool ShouldSerializeIdentityUserId() => false;
//    public static bool ShouldSerializeTimeStamp() => false;
//}
