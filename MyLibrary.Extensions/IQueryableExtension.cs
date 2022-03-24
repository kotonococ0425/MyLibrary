using System.Linq.Expressions;

namespace MyLibrary.Extensions;

public static class IQueryableExtension
{
    ///<summary>
    ///<paramref name="condition"/> が <see langword="true"/> の場合､ <paramref name="predicate"/> の条件で <paramref name="source"/> をフィルター処理します。
    ///</summary>
    ///<param name="source">フィルター処理される <see cref="IQueryable{TSource}" />。</param>
    ///<typeparam name="TSource"><paramref name = "source" /> の要素の型。</typeparam>
    ///<returns>
    ///<paramref name="condition"/> が <see langword="true"/> の場合､ <paramref name="predicate"/> の条件でフィルター処理された <paramref name="source"/>。それ以外の場合は <paramref name="source"/> をそのまま返す。
    ///</returns>
    public static IQueryable<TSource> WhereIf<TSource>(this IQueryable<TSource> source, bool condition, Expression<Func<TSource, bool>> predicate)
    {
        return condition ? source.Where(predicate) : source;
    }
}
