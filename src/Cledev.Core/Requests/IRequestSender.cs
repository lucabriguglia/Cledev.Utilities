using Cledev.Core.Results;

namespace Cledev.Core.Requests;

public interface IRequestSender
{
    Task<Result> Send<TRequest>(TRequest request) where TRequest : IRequest;
    Task<Result<TResult>> Send<TResult>(IRequest<TResult> request);
}
