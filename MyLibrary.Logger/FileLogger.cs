using System.Text;

namespace MyLibrary.Logger;

public class FileLogger : ILogger
{
    protected virtual string FilePath { get; set; } = @"Log\Application.log";

    protected virtual LogLevel LogLevel { get; set; } = LogLevel.Error;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public FileLogger()
    {
        var fileInfo = new FileInfo(FilePath);
        var directoryName = fileInfo.DirectoryName;
        if (!Directory.Exists(directoryName))
        {
            Directory.CreateDirectory(directoryName!);
        }
    }

    public void Debug(string text)
    {
        if (LogLevel <= LogLevel.Debug)
        {
            Log(LogLevel.Debug, text);
        }
    }

    public void Info(string text)
    {
        if (LogLevel <= LogLevel.Info)
        {
            Log(LogLevel.Info, text);
        }
    }

    public void Warn(string text)
    {
        if (LogLevel <= LogLevel.Warn)
        {
            Log(LogLevel.Warn, text);
        }
    }

    public void Error(string text)
    {
        if (LogLevel <= LogLevel.Error)
        {
            Log(LogLevel.Error, text);
        }
    }

    /// <summary>
    /// <see cref="LogLevel.Error"/> でスタックトレースログを出力する。
    /// </summary>
    /// <param name="exception">例外オブジェクト</param>
    public void Error(Exception exception)
    {
        if (LogLevel <= LogLevel.Error)
        {
            var text = new StringBuilder(exception.Message).AppendLine(exception.StackTrace).ToString();
            Log(LogLevel.Error, text);
        }
    }

    public void Fatal(string text)
    {
        if (LogLevel <= LogLevel.Fatal)
        {
            Log(LogLevel.Fatal, text);
        }
    }

    public void Unknown(string text)
    {
        if (LogLevel <= LogLevel.Unknown)
        {
            Log(LogLevel.Unknown, text);
        }
    }

    /// <summary>
    /// ログを出力する
    /// </summary>
    /// <param name="level">ログレベル</param>
    /// <param name="msg">メッセージ</param>
    private void Log(LogLevel logLevel, string text)
    {
        var threadId = Environment.CurrentManagedThreadId;
        var fullText = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}][{threadId}][{logLevel}] {text}";
        File.AppendAllText(FilePath, fullText, Encoding.UTF8);
    }
}
