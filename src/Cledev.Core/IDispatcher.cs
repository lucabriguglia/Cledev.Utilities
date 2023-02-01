using Cledev.Core.Events;
using Cledev.Core.Requests;
using Cledev.Core.Results;

namespace Cledev.Core;

public interface IDispatcher
{
    Task<Result> Send<TRequest>(TRequest request) where TRequest : IRequest;
    Task<Result<TResult>> Send<TResult>(IRequest<TResult> request);
    Task<Result> Publish<TEvent>(TEvent @event) where TEvent : IEvent;
}
