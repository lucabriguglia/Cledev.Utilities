namespace Cledev.Core.Utilities;

public interface IDateTimeProvider
{
    public DateTimeOffset UtcNow { get; }
}

public class DateTimeProvider : IDateTimeProvider
{
    public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
}