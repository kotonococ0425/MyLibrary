namespace MyLibrary.Extensions.UseCase.Parse;

public static class Parse
{
    public static int ParseToInt(this string source)
    {
        return int.Parse(source);
    }

    public static int ParseToInt<TSource>(this TSource? source)
    {
        return int.Parse(Convert.ToString(source)!);
    }

    public static int ParseToIntOrDefault(this string? source, int defaultValue = default)
    {
        return int.TryParse(source, out var result) ? result : defaultValue;
    }

    public static int ParseToIntOrDefault<TSource>(this TSource? source, int defaultValue = default)
    {
        return int.TryParse(Convert.ToString(source), out var result) ? result : defaultValue;
    }
}
