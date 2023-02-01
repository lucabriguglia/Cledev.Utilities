using Cledev.Core.Results;

namespace Cledev.Core.Requests;

internal class RequestHandlerWrapper<TRequest, TResult> : RequestHandlerWrapperBase<TResult> where TRequest : IRequest<TResult>
{
    public override async Task<Result<TResult>> Handle(IRequest<TResult> request, IServiceProvider serviceProvider)
    {
        var handler = GetHandler<IRequestHandler<TRequest, TResult>>(serviceProvider);

        if (handler == null)
        {
            return Result<TResult>.Fail(ErrorCodes.Error, title: "Handler not found", description: $"Handler not found for request of type {typeof(TRequest)}");
        }

        return await handler.Handle((TRequest)request);
    }
}