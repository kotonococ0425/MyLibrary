namespace MyLibrary.Extensions;

public static class IntExtension
{
    ///<summary>
    ///<paramref name="source"/> 回だけ繰り返します。
    ///<paramref name="source"/> が正の整数でない場合は何もしません。
    ///また <paramref name="action"/> には <see langword="0"/> から <paramref name="source"/> <see langword="- 1"/> までの数値が渡されます。
    ///</summary>
    ///<param name="source">繰り返す回数。</param>
    ///<param name="action">インデックス。</param>
    public static void Times(this int source, Action<int> action)
    {
        if (action is null)
        {
            throw new ArgumentNullException(nameof(action));
        }

        if (source < 1)
        {
            return;
        }

        for (var i = 0; i < source; i++)
        {
            action(i);
        }
    }

    /// <summary>
    /// <paramref name="source"/> が偶数かどうかを返します｡
    /// </summary>
    /// <param name="source">偶数かを判定する数値</param>
    /// <returns><paramref name="source"/> が偶数なら <see langword="true"/> ､ それ以外なら <see langword="false"/></returns>
    public static bool IsEven(this int source)
    {
        return source % 2 is 0;
    }

    /// <summary>
    /// <paramref name="source"/> が奇数かどうかを返します｡
    /// </summary>
    /// <param name="source">奇数かを判定する数値</param>
    /// <returns><paramref name="source"/> が奇数なら <see langword="true"/> ､ それ以外なら <see langword="false"/></returns>
    public static bool IsOdd(this int source)
    {
        return source % 2 is 1;
    }
}
