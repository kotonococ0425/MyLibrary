namespace MyLibrary.Extensions;

public static class TimeSpanExtension
{
    private const int SecondsPerMinute = 60;

    private const int SecondsPerHour = SecondsPerMinute * 60;

    private const int SecondsPerDay = SecondsPerHour * 24;

    private const int SecondsPerMonth = SecondsPerDay * 30;

    private const int SecondsPerYear = SecondsPerDay * 365;

    public static bool IsNegative(this TimeSpan source)
    {
        return source < TimeSpan.Zero;
    }

    public static string ToReadableString(this TimeSpan source)
    {
        var totalSeconds = source.TotalSeconds;
        return totalSeconds switch
        {
            < -SecondsPerYear => $"{Math.Floor(totalSeconds / -SecondsPerYear)}年前",
            < -SecondsPerMonth => $"{Math.Floor(totalSeconds / -SecondsPerMonth)}ヶ月前",
            < -SecondsPerDay => $"{Math.Floor(totalSeconds / -SecondsPerDay)}日前",
            < -SecondsPerHour => $"{Math.Floor(totalSeconds / -SecondsPerHour)}時間前",
            < -SecondsPerMinute => $"{Math.Floor(totalSeconds / -SecondsPerMinute)}分前",
            < 0 => $"{totalSeconds}秒前",
            < SecondsPerMinute => $"{totalSeconds}秒後", 
            < SecondsPerHour => $"{Math.Floor(totalSeconds / SecondsPerMinute)}分後",
            < SecondsPerDay => $"{Math.Floor(totalSeconds / SecondsPerHour)}時間後",
            < SecondsPerMonth => $"{Math.Floor(totalSeconds / SecondsPerDay)}日後",
            < SecondsPerYear => $"{Math.Floor(totalSeconds / SecondsPerMonth)}ヶ月後",
            _ => $"{Math.Floor(totalSeconds / SecondsPerYear)}年後",
        };
    }
}
