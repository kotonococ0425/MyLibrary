namespace MyLibrary.Extensions;

public static class GenericExtension
{
    ///<summary>
    ///<paramref name="source"/> を引数として <paramref name="action"/> を実行し、 <paramref name="source"/> を返します。
    ///</summary>
    public static TSource Tap<TSource>(this TSource source, Action<TSource> action)
    {
        action(source);
        return source;
    }

    /// <summary>
    /// <paramref name="source"/> が <paramref name="min"/> と <paramref name="max"/> の範囲内にあるかを判断します。
    /// </summary>
    /// <param name="source">比較される値</param>
    /// <param name="min">範囲の下端を表すオブジェクトを指定します。</param>
    /// <param name="max">範囲の上端を表すオブジェクトを指定します。</param>
    /// <param name="inclusive">境界値を含むなら <see langword="true"/>、含まないなら <see langword="false"/></param>
    /// <returns>範囲内であれば <see langword="true"/></returns>
    public static bool IsBetween<TSource>(this TSource source, TSource min, TSource max, bool inclusive = true) where TSource : IComparable
    {
        if (min.CompareTo(max) > 0)
        {
            (min, max) = (max, min);
        }

        return inclusive ? (min.CompareTo(source) <= 0 && source.CompareTo(max) <= 0) : (min.CompareTo(source) < 0 && source.CompareTo(max) < 0);
    }
}
