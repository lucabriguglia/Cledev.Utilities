namespace Cledev.Core.Results;

public record Failure(string ErrorCode = ErrorCodes.Error, string? Title = null, string? Description = null);

public static class ErrorCodes
{
    public const string
        Error = "Error",
        NotFound = "NotFound",
        Unauthorized = "Unauthorized";
}