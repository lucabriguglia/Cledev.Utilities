using Cledev.Core.Extensions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Cledev.Server.Extensions;

public static class FluentValidationExtensions
{
    public static ActionResult ToActionResult(this ValidationResult validationResult)
    {
        return new BadRequestObjectResult(new ProblemDetails
        {
            Title = "Validation failed",
            Detail = validationResult.Errors.ToErrorMessage(),
            Status = 400
        });
    }
}
