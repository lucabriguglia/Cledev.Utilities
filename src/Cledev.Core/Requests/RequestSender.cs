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

    public async Task<Result> Send<TCommand>(TCommand? command) where TCommand : IRequest
    {
        if (command is null)
        {
            return Result.Fail(ErrorCodes.Error, title: "Null Argument", description: $"Command of type {typeof(TCommand)} is null");
        }

        var handler = _serviceProvider.GetService<IRequestHandler<TCommand>>();

        if (handler is null)
        {
            return Result.Fail(ErrorCodes.Error, title: "Handler not found", description: $"Handler not found for command of type {typeof(TCommand)}");
        }

        return await handler.Handle(command);
    }

    public async Task<Result<TResult>> Process<TResult>(IRequest<TResult> request)
    {
        if (request is null)
        {
            return Result<TResult>.Fail(ErrorCodes.Error, title: "Null Argument", description: $"Query of type {typeof(IRequest<TResult>)} is null");
        }

        var queryType = request.GetType();

        var handler = (RequestHandlerWrapperBase<TResult>)RequestHandlerWrappers.GetOrAdd(queryType,
            t => Activator.CreateInstance(typeof(RequestHandlerWrapper<,>).MakeGenericType(queryType, typeof(TResult))))!;

        var result = await handler.Handle(request, _serviceProvider);

        return result;
    }
}
