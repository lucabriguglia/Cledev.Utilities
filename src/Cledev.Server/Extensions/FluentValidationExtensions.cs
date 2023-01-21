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

    private static string ToErrorMessage(this IEnumerable<ValidationFailure> validationFailures)
    {
        var errorMessages = validationFailures.Select(x => x.ErrorMessage).ToArray();
        return $"Errors: {string.Join("; ", errorMessages)}";
    }
}
