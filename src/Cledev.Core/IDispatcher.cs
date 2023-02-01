using Cledev.Core.Events;
using Cledev.Core.Requests;
using Cledev.Core.Results;

namespace Cledev.Core;

public interface IDispatcher
{
    Task<Result> Send<TCommand>(TCommand command) where TCommand : IRequest;
    Task<Result<TResult>> Get<TResult>(IRequest<TResult> request);
    Task<Result> Publish<TEvent>(TEvent @event) where TEvent : IEvent;
}
