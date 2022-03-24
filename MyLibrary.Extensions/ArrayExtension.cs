namespace MyLibrary.Extensions;

public static class ArrayExtension
{
    ///<summary>
    ///<paramref name="source"/> に要素が含まれているかどうかを判断します。
    ///</summary>
    ///<param name="source">要素が含まれているかどうかを判断される <see cref="List{TSource}" />。</param>
    ///<typeparam name="TSource"><paramref name = "source" /> の要素の型。</typeparam>
    ///<returns>
    ///<paramref name="source"/> に要素が含まれていない場合は <see langword="true"/>。それ以外の場合は <see langword="false"/>。
    ///</returns>
    public static bool IsEmpty<TSource>(this TSource[] source)
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
    public static bool IsNullOrEmpty<TSource>(this TSource[] source)
    {
        return source is null || source.IsEmpty();
    }
}
