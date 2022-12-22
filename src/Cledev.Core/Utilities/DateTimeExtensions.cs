namespace Cledev.Core.Utilities;

public static class DateTimeExtensions
{
    public static DateTime FromUtcToLocalTime(this DateTime utcDate)
    {
        utcDate = DateTime.SpecifyKind(utcDate, DateTimeKind.Utc);
        var result = utcDate.ToLocalTime();
        return result;
    }

    public static string ToLocalShortDate(this DateTime timeStamp)
    {
        var localDate = timeStamp.FromUtcToLocalTime();
        var result = localDate.ToShortDateString();
        return result;
    }

    public static string ToLocalShortDateAndTime(this DateTime timeStamp)
    {
        var localDate = timeStamp.FromUtcToLocalTime();
        var result = $"{localDate.ToShortDateString()} {localDate.ToShortTimeString()}";
        return result;
    }
}