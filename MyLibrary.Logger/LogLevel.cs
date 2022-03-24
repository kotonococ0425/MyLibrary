namespace MyLibrary.Logger;

/// <summary>
/// ログレベル
/// </summary>
public enum LogLevel
{
    /// <summary>
    /// デバッグ情報など
    /// </summary>
    Debug,

    /// <summary>
    /// 一般的な情報
    /// </summary>
    Info,

    /// <summary>
    /// 警告
    /// </summary>
    Warn,

    /// <summary>
    /// 制御可能なエラー
    /// </summary>
    Error,

    /// <summary>
    /// プログラムをクラッシュさせるような制御不可能なエラー
    /// </summary>
    Fatal,

    /// <summary>
    /// 常に記録されるべき不明なエラー
    /// </summary>
    Unknown
}