using Cledev.Core.Results;
using Microsoft.AspNetCore.Mvc;

namespace Cledev.Server.Extensions;

public static class ResultExtensions
{
    public static ActionResult ToActionResult(this Result result)
    {
        return result.Match(
            _ => new OkObjectResult(null),
            failure => failure.ToActionResult()
        );
    }

    public static ActionResult ToActionResult<TResult>(this Result<TResult> result)
    {
        return result.Match(
            success => new OkObjectResult(success),
            failure => failure.ToActionResult()
        );
    }
}