namespace Cledev.Core.Results;

public record Failure(string ErrorCode = ErrorCodes.Error, string? Title = null, string? Description = null);

public static class ErrorCodes
{
    public const string Error = "Error";
    public const string NotFound = "NotFound";
    public const string Unauthorized = "Unauthorized";
}

//public static class FailureExtensions
//{
//    public static Failure WithTitle(this Failure failure, string title) => failure with { Title = title };
//    public static Failure WithDescription(this Failure failure, string description) => failure with { Description = description };
//    public static Failure WithDescription(this Failure failure, string description, IEnumerable<string> items) => failure with { Description = $"{description}: {string.Join(", ", items)}" };
//    public static Failure WithValidationResult(this Failure failure, ValidationResult validationResult) => failure with { ValidationResult = validationResult };
//}
