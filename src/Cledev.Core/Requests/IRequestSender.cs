using Cledev.Core.Results;

namespace Cledev.Core.Requests;

public interface IRequestSender
{
    Task<Result> Send<TCommand>(TCommand command) where TCommand : IRequest;
    Task<Result<TResult>> Process<TResult>(IRequest<TResult> request);
}
