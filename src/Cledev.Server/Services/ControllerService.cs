using Cledev.Core;
using Cledev.Core.Commands;
using Cledev.Core.Queries;
using Cledev.Server.Extensions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Cledev.Server.Services;

public interface IControllerService
{
    Task<ActionResult> ProcessCommand<TCommand>(TCommand command) where TCommand : ICommand;
    Task<ActionResult> ProcessQuery<TResult>(IQuery<TResult> query);
}

public class ControllerService : IControllerService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IDispatcher _dispatcher;

    public ControllerService(IServiceProvider serviceProvider, IDispatcher dispatcher)
    {
        _serviceProvider = serviceProvider;
        _dispatcher = dispatcher;
    }

    public async Task<ActionResult> ProcessCommand<TCommand>(TCommand command) where TCommand : ICommand
    {
        var validator = _serviceProvider.GetService<IValidator<TCommand>?>();
        if (validator is not null)
        {
            var validationResult = await validator.ValidateAsync(command);
            if (validationResult.IsValid is false)
            {
                return validationResult.ToActionResult();
            }
        }

        var commandResult = await _dispatcher.Send(command);

        return commandResult.ToActionResult();
    }

    public async Task<ActionResult> ProcessQuery<TResult>(IQuery<TResult> query)
    {
        var queryResult = await _dispatcher.Get(query);

        return queryResult.ToActionResult();
    }
}
