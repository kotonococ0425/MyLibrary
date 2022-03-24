namespace MyLibrary.Extensions;

public static class StringExtension
{
    /// <summary>
    /// 文字列中の各行を文字列の配列で返します。
    /// </summary>
    /// <param name="s">対象文字列</param>
    /// <returns>行で分割された文字列の配列</returns>
    public static string[] Lines(this string source)
    {
        return source.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
    }
}
