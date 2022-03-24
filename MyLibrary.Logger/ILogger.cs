namespace MyLibrary.Logger;

public interface ILogger
{
    /// <summary>
    /// デバッグ情報など
    /// </summary>
    public void Debug(string text);

    /// <summary>
    /// 一般的な情報
    /// </summary>
    public void Info(string text);

    /// <summary>
    /// 警告
    /// </summary>
    public void Warn(string text);

    /// <summary>
    /// 制御可能なエラー
    /// </summary>
    public void Error(string text);

    /// <summary>
    /// 制御可能なエラー
    /// </summary>
    public void Error(Exception exception);

    /// <summary>
    /// プログラムをクラッシュさせるような制御不可能なエラー
    /// </summary>
    public void Fatal(string text);

    /// <summary>
    /// 常に記録されるべき不明なエラー
    /// </summary>
    public void Unknown(string text);
}
