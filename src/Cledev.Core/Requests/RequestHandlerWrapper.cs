using Cledev.Core.Results;

namespace Cledev.Core.Requests;

internal class RequestHandlerWrapper<TQuery, TResult> : RequestHandlerWrapperBase<TResult> where TQuery : IRequest<TResult>
{
    public override async Task<Result<TResult>> Handle(IRequest<TResult> request, IServiceProvider serviceProvider)
    {
        var handler = GetHandler<IRequestHandler<TQuery, TResult>>(serviceProvider);

        if (handler == null)
        {
            return Result<TResult>.Fail(ErrorCodes.Error, title: "Handler not found", description: $"Handler not found for request of type {typeof(TQuery)}");
        }

        return await handler.Handle((TQuery)request);
    }
}