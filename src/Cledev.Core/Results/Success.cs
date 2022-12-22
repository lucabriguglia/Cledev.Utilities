using Cledev.Core.Events;

namespace Cledev.Core.Results;

public record Success
{
    public Success(params IEvent[] events)
    {
        Events = events;
    }

    public Success()
    {
    }

    public IEnumerable<IEvent> Events { get; init; } = new List<IEvent>();
}

public record Success<TResult>
{
    public Success(TResult result)
    {
        Result = result;
    }

    public Success(params IEvent[] events)
    {
        Events = events;
    }

    public Success(TResult result, params IEvent[] events)
    {
        Events = events;
        Result = result;
    }

    public Success()
    {
    }

    public IEnumerable<IEvent> Events { get; init; } = new List<IEvent>();
    public TResult? Result { get; init; }
}
