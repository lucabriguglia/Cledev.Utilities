using Cledev.Core.Results;
using Microsoft.AspNetCore.Mvc;

namespace Cledev.Server.Extensions;

public static class FailureExtensions
{
    public static ActionResult ToActionResult(this Failure failure)
    {
        var (failureCode, title, description) = failure;

        var problemDetails = new ProblemDetails
        {
            Title = title ?? failureCode,
            Detail = description ?? failureCode,
            Status = failureCode.ToStatusCode()
        };

        return failureCode switch
        {
            FailureCodes.NotFound => new NotFoundObjectResult(problemDetails),
            FailureCodes.Unauthorized => new UnauthorizedObjectResult(problemDetails),
            _ => new UnprocessableEntityObjectResult(problemDetails)
        };
    }

    private static int ToStatusCode(this string failureCode)
    {
        return failureCode switch
        {
            FailureCodes.NotFound => 404,
            FailureCodes.Unauthorized => 401,
            FailureCodes.Error => 422,
            _ => 400
        };
    }
}