using Cledev.Core.Results;
using Microsoft.Extensions.DependencyInjection;

namespace Cledev.Core.Commands;

public class CommandSender : ICommandSender
{
    private readonly IServiceProvider _serviceProvider;

    public CommandSender(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<Result> Send<TCommand>(TCommand? command) where TCommand : ICommand
    {
        if (command is null)
        {
            return Result.Fail(ErrorCodes.Error, title: "Null Argument", description: "Command is null");
        }

        var handler = _serviceProvider.GetService<ICommandHandler<TCommand>>();

        if (handler is null)
        {
            return Result.Fail(ErrorCodes.Error, title: "Null Handler", description: "Command handler is null");
        }

        return await handler.Handle(command);
    }
}
