using Cledev.Core.Events;

namespace Cledev.Core.Results;

public record Success
{
    public IEnumerable<IEvent> Events { get; init; } = new List<IEvent>();
    
    public Success()
    {
    }
    
    public Success(params IEvent[] events)
    {
        Events = events;
    }
}

public record Success<TResult>
{
    public TResult? Result { get; init; }
    public IEnumerable<IEvent> Events { get; init; } = new List<IEvent>();
    
    public Success()
    {
    }
    
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
        Result = result;
        Events = events;
    }
}
