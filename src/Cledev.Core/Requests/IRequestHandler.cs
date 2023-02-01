using Cledev.Core.Results;

namespace Cledev.Core.Requests;

public interface IRequestHandler<in TCommand> where TCommand : IRequest
{
    Task<Result> Handle(TCommand command);
}

public interface IRequestHandler<in TQuery, TResult> where TQuery : IRequest<TResult>
{
    Task<Result<TResult>> Handle(TQuery query);
}