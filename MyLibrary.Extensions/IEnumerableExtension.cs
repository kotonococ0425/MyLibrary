using System.Collections.ObjectModel;

namespace MyLibrary.Extensions;

public static class IEnumerableExtension
{
    #region Void

    ///<summary>
    ///<see cref="IEnumerable{TSource}"/> の各要素に対して、指定された処理を実行します。
    ///</summary>
    ///<param name="source">各要素に対して、指定された処理を実行される <see cref="IEnumerable{TSource}" />。</param>
    ///<param name="action"><see cref="IEnumerable{TSource}"/>の各要素に対して実行する <see cref="Action{TSource}"/> デリゲート。</param>
    ///<typeparam name="TSource"><paramref name = "source" /> の要素の型。</typeparam>
    public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (action is null)
        {
            throw new ArgumentNullException(nameof(action));
        }

        foreach (var item in source)
        {
            action(item);
        }
    }

    ///<summary>
    ///<see cref="IEnumerable{TSource, int}"/> の各要素に対して、指定された処理を実行します。
    ///</summary>
    ///<param name="source">各要素に対して、指定された処理を実行される <see cref="IEnumerable{TSource}" />。</param>
    ///<param name="action"><see cref="IEnumerable{TSource}"/>の各要素に対して実行する <see cref="Action{TSource}"/> デリゲート。</param>
    ///<typeparam name="TSource"><paramref name = "source" /> の要素の型。</typeparam>
    public static void ForEach<TSource>(this IEnumerable<(TSource, int)> source, Action<TSource, int> action)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (action is null)
        {
            throw new ArgumentNullException(nameof(action));
        }

        foreach ((var item, var index) in source)
        {
            action(item, index);
        }
    }

    ///<summary>
    ///<see cref="IEnumerable{TSource}"/> の各要素に対して、インデックスを取得しながら指定された処理を実行します。
    ///</summary>
    ///<param name="source">各要素に対して、指定された処理を実行される <see cref="IEnumerable{TSource}" />。</param>
    ///<param name="action"><see cref="IEnumerable{TSource}"/>の各要素に対して実行する <see cref="Action{TSource, int}"/> デリゲート。</param>
    ///<typeparam name="TSource"><paramref name = "source" /> の要素の型。</typeparam>
    public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource, int> action) where TSource : class
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (action is null)
        {
            throw new ArgumentNullException(nameof(action));
        }

        var index = 0;
        foreach (var item in source)
        {
            action(item, index++);
        }
    }

    ///<summary>
    ///<see cref="IEnumerable{TSource}"/> の各要素に対して、インデックスを取得しながら指定された処理を実行します。
    ///インデックスは <paramref name="offset"/> から始まります。
    ///</summary>
    ///<param name="source">各要素に対して、指定された処理を実行される <see cref="IEnumerable{TSource}" />。</param>
    ///<param name="action"><see cref="IEnumerable{TSource}"/>の各要素に対して実行する <see cref="Action{TSource, int}"/> デリゲート。</param>
    ///<param name="offset">開始インデックス。</param>
    ///<typeparam name="TSource"><paramref name = "source" /> の要素の型。</typeparam>
    public static void ForEach<TSource>(this IEnumerable<TSource> source, int offset, Action<TSource, int> action)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (action is null)
        {
            throw new ArgumentNullException(nameof(action));
        }

        var index = 0 + offset;
        foreach (var item in source)
        {
            action(item, index++);
        }
    }
    #endregion

    #region IEnumerable
    ///<summary>
    ///<paramref name="source"/> の要素にインデックスを添えて返します。
    ///インデックスは <paramref name="offset"/> から始まります。
    ///</summary>
    ///<param name="source">インデックスを添える要素を含んだ <see cref="IEnumerable{TSource}" />。</param>
    ///<param name="offset">開始インデックス。</param>
    ///<typeparam name="TSource"><paramref name = "source" /> の要素の型。</typeparam>
    ///<returns>
    ///<paramref name="source"/> の要素とインデックスをタプル型とした<see cref="IEnumerable{(TSource item, int index)}"/>
    ///</returns>
    public static IEnumerable<(TSource item, int index)> WithIndex<TSource>(this IEnumerable<TSource> source, int offset = 0)
    {
        return source is null ? throw new ArgumentNullException(nameof(source)) : source.Select((item, index) => (item, index + offset));
    }

    ///<summary>
    ///<paramref name="source"/> が <see langword="null"/> なら空の <see cref="IEnumerable{TSource}"/> を返し、それ以外の場合は <paramref name="source"/> を返します。
    ///</summary>
    ///<param name="source"><see langword="null"/> か確認する <see cref="IEnumerable{TSource}" />。</param>
    ///<typeparam name="TSource"><paramref name = "source" /> の要素の型。</typeparam>
    ///<returns>
    ///<paramref name="source"/> が <see langword="null"/> なら空の <see cref="IEnumerable{TSource}"/>。それ以外の場合は <paramref name="source"/>
    ///</returns>
    public static IEnumerable<TSource> EmptyIfNull<TSource>(this IEnumerable<TSource> source)
    {
        return source ?? Enumerable.Empty<TSource>();
    }

    ///<summary>
    ///<paramref name="source"/> の要素から <see langword="null"/> を取り除いた <see cref="IEnumerable{TSource}" /> を返します。
    ///</summary>
    ///<param name="source">要素から<see langword="null"/> を取り除く <see cref="IEnumerable{TSource}" />。</param>
    ///<typeparam name="TSource"><paramref name = "source" /> の要素の型。</typeparam>
    ///<returns>
    ///要素から <see langword="null"/> を取り除いた <see cref="IEnumerable{TSource}" />
    ///</returns>
    public static IEnumerable<TSource> Compact<TSource>(this IEnumerable<TSource> source)
    {
        return source is null ? throw new ArgumentNullException(nameof(source)) : source.Where(item => item is not null);
    }

    ///<summary>
    ///<paramref name="source"/> の要素を無限回繰り返します。
    ///</summary>
    ///<param name="source">繰り返す要素。</param>
    ///<typeparam name="TSource"><paramref name = "source" /> の要素の型。</typeparam>
    ///<returns>
    ///無限回繰り返された要素。
    ///</returns>
    public static IEnumerable<T> Cycle<T>(this IEnumerable<T> source)
    {
        return source is null ? throw new ArgumentNullException(nameof(source)) : Cycle();
        IEnumerable<T> Cycle()
        {
            if (source.IsEmpty())
            {
                yield break;
            }

            while (true)
            {
                foreach (var item in source)
                {
                    yield return item;
                }
            }
        }
    }

    ///<summary>
    ///<paramref name="source"/> の要素を <paramref name="times"/> 回繰り返します。
    ///</summary>
    ///<param name="source">繰り返す要素。</param>
    ///<param name="times">繰り返し回数。</param>
    ///<typeparam name="TSource"><paramref name = "source" /> の要素の型。</typeparam>
    ///<returns>
    ///<paramref name="times"/> 回繰り返された要素。
    ///</returns>
    public static IEnumerable<T> Cycle<T>(this IEnumerable<T> source, int times)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (times < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(times));
        }

        return Cycle();

        IEnumerable<T> Cycle()
        {
            if (source.IsEmpty())
            {
                yield break;
            }

            for (var j = 0; j < times; j++)
            {
                foreach (var item in source)
                {
                    yield return item;
                }
            }
        }
    }

    ///<summary>
    ///※即時実行
    ///<paramref name="source"/> と <paramref name="args"/> のそれぞれから要素を一個ずつ取り、それらすべての <see cref="List{TSource}"/> を要素とする <see cref="List{List{TSource}}"/> を返します。
    /// 返される <see cref="List{List{TSource}}"/> の要素数は、 <paramref name="source"/> と <paramref name="args"/> で与えられた <see cref="List{TSource}"/> の要素数のすべての積になります。
    ///</summary>
    ///<param name="source"><see cref="IEnumerable{TSource}" /></param>
    ///<param name="args"><see cref="IEnumerable{TSource}" /></param>
    ///<typeparam name="TSource"><paramref name = "source" /> の要素の型。</typeparam>
    ///<returns>
    ///<paramref name="source"/> と <paramref name="args"/> で与えられた <see cref="List{TSource}"/> の要素のすべての組み合わせである <see cref="List{List{TSource}}"/>。
    ///</returns>
    public static IEnumerable<IEnumerable<TSource>> Product<TSource>(this IEnumerable<TSource> source, params IEnumerable<TSource>[] args)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (args is null)
        {
            throw new ArgumentNullException(nameof(args));
        }

        return Product();

        IEnumerable<IEnumerable<TSource>> Product()
        {
            var result = args.Prepend(source).Where(arg => !arg.IsNullOrEmpty()).Aggregate(new List<List<TSource>>(), (result, arr) => Product2(result, arr));
            foreach (var item in result)
            {
                yield return item;
            }
        }

        List<List<TSource>> Product2(List<List<TSource>> arr1, IEnumerable<TSource> arr2)
        {
            return arr2.Aggregate(new List<List<TSource>>(), (result, v2) =>
            {
                if (arr1.IsEmpty())
                {
                    return arr2.Select(v => new List<TSource>() { v }).ToList();
                }

                arr1.ForEach(v1 => result.Add(v1.Append(v2).ToList()));
                return result;
            });
        }
    }

    ///<summary>
    ///<paramref name="condition"/> が <see langword="true"/> の場合､ <paramref name="predicate"/> の条件で <paramref name="source"/> をフィルター処理します。
    ///</summary>
    ///<param name="source">フィルター処理される <see cref="IEnumerable{TSource}" />。</param>
    ///<typeparam name="TSource"><paramref name = "source" /> の要素の型。</typeparam>
    ///<returns>
    ///<paramref name="condition"/> が <see langword="true"/> の場合､ <paramref name="predicate"/> の条件でフィルター処理された <paramref name="source"/>。それ以外の場合は <paramref name="source"/> をそのまま返す。
    ///</returns>
    public static IEnumerable<TSource> WhereIf<TSource>(this IEnumerable<TSource> source, bool condition, Func<TSource, bool> predicate)
    {
        return condition ? source.Where(predicate) : source;
    }
    #endregion

    #region TSource
    ///<summary>
    ///<paramref name="source"/> の二番目の要素を返します。
    ///</summary>
    ///<param name="source">対象の <see cref="IEnumerable{TSource}" />。</param>
    ///<typeparam name="TSource"><paramref name = "source" /> の要素の型。</typeparam>
    ///<returns>
    ///<paramref name="source"/> の二番目の要素。
    ///</returns>
    public static TSource Second<TSource>(this IEnumerable<TSource> source)
    {
        return source is null ? throw new ArgumentNullException(nameof(source)) : source.ElementAt(1);
    }

    ///<summary>
    ///<paramref name="source"/> の二番目の要素を返します。このような要素が見つからない場合は既定値を返します。
    ///</summary>
    ///<param name="source">対象の <see cref="IEnumerable{TSource}" />。</param>
    ///<typeparam name="TSource"><paramref name = "source" /> の要素の型。</typeparam>
    ///<returns>
    ///二番目の要素が <paramref name="source"/> の範囲外の場合は <see langword="defalut"/> (<typeparamref name="TSource"/>)。それ以外の場合は、二番目の要素。
    ///</returns>
    public static TSource? SecondOrDefault<TSource>(this IEnumerable<TSource> source)
    {
        return source is null ? throw new ArgumentNullException(nameof(source)) : source.ElementAtOrDefault(1);
    }

    ///<summary>
    ///<paramref name="source"/> の三番目の要素を返します。
    ///</summary>
    ///<param name="source">対象の <see cref="IEnumerable{TSource}" />。</param>
    ///<typeparam name="TSource"><paramref name = "source" /> の要素の型。</typeparam>
    ///<returns>
    ///<paramref name="source"/> の三番目の要素。
    ///</returns>
    public static TSource Third<TSource>(this IEnumerable<TSource> source)
    {
        return source is null ? throw new ArgumentNullException(nameof(source)) : source.ElementAt(2);
    }

    ///<summary>
    ///<paramref name="source"/> の三番目の要素を返します。このような要素が見つからない場合は既定値を返します。
    ///</summary>
    ///<param name="source">対象の <see cref="IEnumerable{TSource}" />。</param>
    ///<typeparam name="TSource"><paramref name = "source" /> の要素の型。</typeparam>
    ///<returns>
    ///三番目の要素が <paramref name="source"/> の範囲外の場合は <see langword="defalut"/> (<typeparamref name="TSource"/>)。それ以外の場合は、三番目の要素。
    ///</returns>
    public static TSource? ThirdOrDefault<TSource>(this IEnumerable<TSource> source)
    {
        return source is null ? throw new ArgumentNullException(nameof(source)) : source.ElementAtOrDefault(2);
    }

    ///<summary>
    ///<paramref name="source"/> の四番目の要素を返します。
    ///</summary>
    ///<param name="source">対象の <see cref="IEnumerable{TSource}" />。</param>
    ///<typeparam name="TSource"><paramref name = "source" /> の要素の型。</typeparam>
    ///<returns>
    ///<paramref name="source"/> の四番目の要素。
    ///</returns>
    public static TSource Fourth<TSource>(this IEnumerable<TSource> source)
    {
        return source is null ? throw new ArgumentNullException(nameof(source)) : source.ElementAt(3);
    }

    ///<summary>
    ///<paramref name="source"/> の四番目の要素を返します。このような要素が見つからない場合は既定値を返します。
    ///</summary>
    ///<param name="source">対象の <see cref="IEnumerable{TSource}" />。</param>
    ///<typeparam name="TSource"><paramref name = "source" /> の要素の型。</typeparam>
    ///<returns>
    ///四番目の要素が <paramref name="source"/> の範囲外の場合は <see langword="defalut"/> (<typeparamref name="TSource"/>)。それ以外の場合は、四番目の要素。
    ///</returns>
    public static TSource? FourthOrDefault<TSource>(this IEnumerable<TSource> source)
    {
        return source is null ? throw new ArgumentNullException(nameof(source)) : source.ElementAtOrDefault(3);
    }

    ///<summary>
    ///<paramref name="source"/> の五番目の要素を返します。
    ///</summary>
    ///<param name="source">対象の <see cref="IEnumerable{TSource}" />。</param>
    ///<typeparam name="TSource"><paramref name = "source" /> の要素の型。</typeparam>
    ///<returns>
    ///<paramref name="source"/> の五番目の要素。
    ///</returns>
    public static TSource Fifth<TSource>(this IEnumerable<TSource> source)
    {
        return source is null ? throw new ArgumentNullException(nameof(source)) : source.ElementAt(4);
    }

    ///<summary>
    ///<paramref name="source"/> の五番目の要素を返します。このような要素が見つからない場合は既定値を返します。
    ///</summary>
    ///<param name="source">対象の <see cref="IEnumerable{TSource}" />。</param>
    ///<typeparam name="TSource"><paramref name = "source" /> の要素の型。</typeparam>
    ///<returns>
    ///五番目の要素が <paramref name="source"/> の範囲外の場合は <see langword="defalut"/> (<typeparamref name="TSource"/>)。それ以外の場合は、五番目の要素。
    ///</returns>
    public static TSource? FifthOrDefault<TSource>(this IEnumerable<TSource> source)
    {
        return source is null ? throw new ArgumentNullException(nameof(source)) : source.ElementAtOrDefault(4);
    }

    /// <summary>
    /// 「次」のオブジェクトを返します。
    /// 現在までの列挙状態に応じて「次」のオブジェクトを返し、列挙状態を1つ分進めます。<br/>
    /// 列挙が既に最後へ到達している場合は、<see langword="default"/> を返します。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <returns></returns>
    public static TSource? Next<TSource>(this IEnumerable<TSource> source)
    {
        using var enumerator = source.GetEnumerator();
        return enumerator.MoveNext() ? enumerator.Current : default;
    }
    #endregion

    #region string
    /// <summary>
    /// <paramref name="source"/> の要素を文字列 <paramref name="separator"/> を間に挟んで連結した文字列を返します。
    /// </summary>
    /// <typeparam name="TSource"><paramref name = "source" /> の要素の型。</typeparam>
    /// <param name="source">対象の <see cref="IEnumerable{TSource}" />。</param>
    /// <param name="separator">間に挟む文字列</param>
    /// <returns></returns>
    public static string StringJoin<TSource>(this IEnumerable<TSource> source, string separator = "")
    {
        return source.IsNullOrEmpty() ? "" : string.Join(separator, source);
    }
    #endregion

    #region Int
    /// <summary>
    /// 歯抜け番号の最小値を取得する
    /// </summary>
    /// <param name="source"></param>
    /// <param name="minValueIfEmpty"><paramref name="source"/> が空の時に返す数値</param>
    /// <returns></returns>
    public static int MinOfToothless(this IEnumerable<int> source, int minValueIfEmpty = 0)
    {
        if (source.IsEmpty())
        {
            return minValueIfEmpty;
        }

        return source.Where(i => !source.Contains(i + 1)).Select(i => i + 1).Min();
    }
    #endregion

    #region bool
    ///<summary>
    ///<paramref name="source"/> に要素が含まれているかどうかを判断します。
    ///</summary>
    ///<param name="source">要素が含まれているかどうかを判断される <see cref="IEnumerable{TSource}" />。</param>
    ///<typeparam name="TSource"><paramref name = "source" /> の要素の型。</typeparam>
    ///<returns>
    ///<paramref name="source"/> に要素が含まれていない場合は <see langword="true"/>。それ以外の場合は <see langword="false"/>。
    ///</returns>
    public static bool IsEmpty<TSource>(this IEnumerable<TSource> source)
    {
        return source is null ? throw new ArgumentNullException(nameof(source)) : !source.Any();
    }

    ///<summary>
    ///<paramref name="source"/> が <see langword="null"/> または要素が含まれているかどうかを判断します。
    ///</summary>
    ///<param name="source"><see langword="null"/> または要素が含まれているかどうかを判断される <see cref="IEnumerable{TSource}" />。</param>
    ///<typeparam name="TSource"><paramref name = "source" /> の要素の型。</typeparam>
    ///<returns>
    ///<paramref name="source"/> が <see langword="null"/> または要素が含まれていない場合は <see langword="true"/>。それ以外の場合は <see langword="false"/>。
    ///</returns>
    public static bool IsNullOrEmpty<TSource>(this IEnumerable<TSource> source)
    {
        return source is null || source.IsEmpty();
    }
    #endregion

    #region Dictionary
    /// <summary>
    /// <paramref name="source"/> に含まれる要素を数え上げた結果を <see cref="Dictionary{T, int}"/> で返します。<br/>
    /// <see cref="Dictionary{T, int}"/> のキーは <paramref name="source"/> に含まれる要素で、<see cref="Dictionary{T, int}"/> の値は対応する要素が出現する回数です。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <returns></returns>
    public static Dictionary<TSource, int> Tally<TSource>(this IEnumerable<TSource> source) where TSource : notnull
    {
        return source.GroupBy(item => item).ToDictionary(group => group.Key, group => group.Count());
    }

    /// <summary>
    /// <paramref name="source"/> に含まれる要素を数え上げた結果を <see cref="Dictionary{T, int}"/> で返します。<br/>
    /// <see cref="Dictionary{T, int}"/> のキーは <paramref name="source"/> に含まれる要素で、<see cref="Dictionary{T, int}"/> の値は対応する要素が出現する回数です。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="keySelector">キーセレクター関数</param>
    /// <returns></returns>
    public static Dictionary<TKey, int> Tally<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector) where TSource : notnull where TKey : notnull
    {
        return source.GroupBy(item => keySelector(item)).ToDictionary(group => group.Key, group => group.Count());
    }
    #endregion

    #region Tuple
    ///<summary>
    ///<paramref name="source"/> の各要素を <paramref name="func"/> の条件を満たす要素と満たさない要素に分割します。
    ///各要素に対して <paramref name="func"/> を評価して、その値が <see langword="true"/> であった要素の <see cref="List{TSource}"/> と、 <see langword="false"/> であった要素の <see cref="List{TSource}"/> のペアを返すような <see cref="Tuple{List{TSource}, List{TSource}}"/> を返します。
    ///</summary>
    ///<param name="source">要素を分割する <see cref="IEnumerable{TSource}" />。</param>
    ///<typeparam name="TSource"><paramref name = "source" /> の要素の型。</typeparam>
    ///<returns>
    ///要素が分割された <see cref="Tuple{List{TSource}, List{TSource}}"/>。T1には <paramref name="func"/> の値が <see langword="true"/> であった要素、T2には <see langword="false"/> であった要素が入ります。
    ///</returns>
    public static (List<TSource> trueList, List<TSource> falseList) Partition<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (predicate is null)
        {
            throw new ArgumentNullException(nameof(predicate));
        }

        var trueList = new List<TSource>();
        var falseList = new List<TSource>();
        foreach (var item in source)
        {
            if (predicate(item))
            {
                trueList.Add(item);
            }
            else
            {
                falseList.Add(item);
            }
        }

        return (trueList, falseList);
    }
    #endregion

    #region ObservableCollection
    ///<summary>
    ///<paramref name="source"/> から <see cref="ObservableCollection{TSource}"/> クラスの新しいインスタンスを作成して返します。
    ///</summary>
    ///<param name="source">作成元の <see cref="IEnumerable{TSource}" />。</param>
    ///<typeparam name="TSource"><paramref name = "source" /> の要素の型。</typeparam>
    ///<returns>
    /// <paramref name="source"/> から作成された <see cref="ObservableCollection{TSource}"/>
    ///</returns>
    public static ObservableCollection<TSource> ToObservableCollection<TSource>(this IEnumerable<TSource> source)
    {
        return source is null ? throw new ArgumentNullException(nameof(source)) : new ObservableCollection<TSource>(source);
    }
    #endregion

    public static IEnumerable<T> Paginate<T>(this IEnumerable<T> source, int pageSize, int currentPage)
    {
        return source.Skip(pageSize * (currentPage - 1)).Take(pageSize);
    }
}
