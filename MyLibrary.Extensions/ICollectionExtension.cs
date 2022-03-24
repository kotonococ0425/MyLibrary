namespace MyLibrary.Extensions;

public static class ICollectionExtension
{
    ///<summary>
    ///<paramref name="source"/> に要素が含まれているかどうかを判断します。
    ///</summary>
    ///<param name="source">要素が含まれているかどうかを判断される <see cref="List{TSource}" />。</param>
    ///<typeparam name="TSource"><paramref name = "source" /> の要素の型。</typeparam>
    ///<returns>
    ///<paramref name="source"/> に要素が含まれていない場合は <see langword="true"/>。それ以外の場合は <see langword="false"/>。
    ///</returns>
    public static bool IsEmpty<TSource>(this ICollection<TSource> source)
    {
        return !source.Any();
    }

    ///<summary>
    ///<paramref name="source"/> が <see langword="null"/> または要素が含まれているかどうかを判断します。
    ///</summary>
    ///<param name="source"><see langword="null"/> または要素が含まれているかどうかを判断される <see cref="IEnumerable{TSource}" />。</param>
    ///<typeparam name="TSource"><paramref name = "source" /> の要素の型。</typeparam>
    ///<returns>
    ///<paramref name="source"/> が <see langword="null"/> または要素が含まれていない場合は <see langword="true"/>。それ以外の場合は <see langword="false"/>。
    ///</returns>
    public static bool IsNullOrEmpty<TSource>(this ICollection<TSource> source)
    {
        return source is null || source.IsEmpty();
    }

    /// <summary>
    /// 指定した述語によって定義される条件に一致するすべての要素を削除します。
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source">削除する <see cref="IList{T}"/></param>
    /// <param name="match">削除する要素の条件を定義する <see cref="Predicate{T}"/> デリゲート。</param>
    /// <returns><paramref name="source"/> から削除される要素の数。</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static int RemoveAll<TSource>(this IList<TSource> source, Predicate<TSource> match)
    {
        if (match is null)
        {
            throw new ArgumentNullException(nameof(match));
        }

        var count = source.Count;
        for (var i = count - 1; i > -1; i--)
        {
            if (match(source[i]))
            {
                source.RemoveAt(i);
            }
        }

        return count - source.Count;
    }
}
