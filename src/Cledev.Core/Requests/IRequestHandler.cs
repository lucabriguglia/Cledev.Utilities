using Cledev.Core.Results;

namespace Cledev.Core.Requests;

public interface IRequestHandler<in TRequest> where TRequest : IRequest
{
    Task<Result> Handle(TRequest request);
}

public interface IRequestHandler<in TRequest, TResult> where TRequest : IRequest<TResult>
{
    Task<Result<TResult>> Handle(TRequest request);
}