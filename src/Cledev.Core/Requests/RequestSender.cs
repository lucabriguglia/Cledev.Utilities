using Cledev.Core.Results;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Concurrent;

namespace Cledev.Core.Requests;

public class RequestSender : IRequestSender
{
    private readonly IServiceProvider _serviceProvider;
    private static readonly ConcurrentDictionary<Type, object?> RequestHandlerWrappers = new();

    public RequestSender(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<Result> Send<TRequest>(TRequest? request) where TRequest : IRequest
    {
        if (request is null)
        {
            return Result.Fail(ErrorCodes.Error, title: "Null Argument", description: $"Request of type {typeof(TRequest)} is null");
        }

        var handler = _serviceProvider.GetService<IRequestHandler<TRequest>>();

        if (handler is null)
        {
            return Result.Fail(ErrorCodes.Error, title: "Handler not found", description: $"Handler not found for request of type {typeof(TRequest)}");
        }

        return await handler.Handle(request);
    }

    public async Task<Result<TResult>> Send<TResult>(IRequest<TResult>? request)
    {
        if (request is null)
        {
            return Result<TResult>.Fail(ErrorCodes.Error, title: "Null Argument", description: $"Request of type {typeof(IRequest<TResult>)} is null");
        }

        var requestType = request.GetType();

        var handler = (RequestHandlerWrapperBase<TResult>)RequestHandlerWrappers.GetOrAdd(requestType,
            t => Activator.CreateInstance(typeof(RequestHandlerWrapper<,>).MakeGenericType(requestType, typeof(TResult))))!;

        var result = await handler.Handle(request, _serviceProvider);

        return result;
    }
}
