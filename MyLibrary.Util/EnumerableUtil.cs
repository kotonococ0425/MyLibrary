namespace MyLibrary.Util;

public static class EnumerableUtil
{
    public static IEnumerable<TSource> Repeat<TSource>(Func<TSource> activator, int count)
    {
        for (var i = 0; i < count; i++)
        {
            yield return activator();
        }
    }
}
