using FluentValidation.Results;

namespace Cledev.Core.Extensions;

public static class FluentValidationExtensions
{
    public static string ToErrorMessage(this IEnumerable<ValidationFailure> validationFailures)
    {
        var errorMessages = validationFailures.Select(x => x.ErrorMessage).ToArray();
        return $"Errors: {string.Join("; ", errorMessages)}";
    }
}
