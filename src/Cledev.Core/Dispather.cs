using Cledev.Core.Events;
using Cledev.Core.Mapping;
using Cledev.Core.Requests;
using Cledev.Core.Results;

namespace Cledev.Core;

public class Dispatcher : IDispatcher
{
    private readonly IRequestSender _requestSender;
    private readonly IEventPublisher _eventPublisher;
    private readonly IObjectFactory _objectFactory;

    public Dispatcher(IRequestSender requestSender, IEventPublisher eventPublisher, IObjectFactory objectFactory)
    {
        _requestSender = requestSender;
        _eventPublisher = eventPublisher;
        _objectFactory = objectFactory;
    }

    public async Task<Result> Send<TRequest>(TRequest request) where TRequest : IRequest
    {
        var requestResult = await _requestSender.Send(request);

        return await requestResult.Match(HandleSuccess, HandleFailure);

        async Task<Result> HandleSuccess(Success success)
        {
            var events = success.Events.ToList();
            if (events.Any() is false)
            {
                return success;
            }

            var tasks = new List<Task<Result>>();

            foreach (var @event in events)
            {
                var concreteEvent = _objectFactory.CreateConcreteObject(@event);
                var task = _eventPublisher.Publish(concreteEvent);
                tasks.Add(task);
            }

            var results = await Task.WhenAll(tasks);
            if (results.Any(result => result.IsFailure))
            {
                // TODO: Handle event publisher failed results
            }

            return success;
        }

        async Task<Result> HandleFailure(Failure failure)
        {
            return await Task.FromResult(failure);
        }
    }

    public async Task<Result<TResult>> Send<TResult>(IRequest<TResult> request)
    {
        return await _requestSender.Send(request);
    }

    public async Task<Result> Publish<TEvent>(TEvent @event) where TEvent : IEvent
    {
        return await _eventPublisher.Publish(@event);
    }
}
