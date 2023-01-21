using Cledev.Core.Commands;
using Cledev.Core.Events;
using Cledev.Core.Queries;
using Cledev.Core.Results;

namespace Cledev.Core;

public interface IDispatcher
{
    Task<Result> Send<TCommand>(TCommand command) where TCommand : ICommand;
    Task<Result<TResult>> Get<TResult>(IQuery<TResult> query);
    Task<Result> Publish<TEvent>(TEvent @event) where TEvent : IEvent;
}
