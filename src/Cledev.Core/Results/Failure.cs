namespace Cledev.Core.Results;

public record Failure(string FailureCode = FailureCodes.Error, string? Title = null, string? Description = null);

public static class FailureCodes
{
    public const string
        Error = "Error",
        NotFound = "NotFound",
        Unauthorized = "Unauthorized";
}