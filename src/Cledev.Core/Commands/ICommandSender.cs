using Cledev.Core.Results;

namespace Cledev.Core.Commands;

public interface ICommandSender
{
    Task<Result> Send<TCommand>(TCommand command) where TCommand : ICommand;
}
