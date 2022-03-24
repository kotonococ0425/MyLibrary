namespace MyLibrary.Wpf.Messaging.Messages;

/// <summary>
/// メッセージボックス用のメッセージ
/// </summary>
public class ShowMessageBoxMessage
{
    public static ShowMessageBoxMessage GetErrorMessageBox(string messageBoxText)
    {
        return new ShowMessageBoxMessage()
        {
            MessageBoxText = messageBoxText,
            Caption = "エラー",
            Button = MessageBoxButton.OK,
            Icon = MessageBoxImage.Error,
        };
    }

    /// <summary>
    /// 表示するテキスト
    /// </summary>
    public string MessageBoxText { get; set; } = "";

    /// <summary>
    /// 表示するタイトルバーキャプション
    /// </summary>
    public string Caption { get; set; } = "";

    /// <summary>
    /// 表示する1つ以上のボタンを指定する値
    /// </summary>
    public MessageBoxButton Button { get; set; } = MessageBoxButton.OK;

    /// <summary>
    /// 表示するアイコンを指定する値
    /// </summary>
    public MessageBoxImage Icon { get; set; } = MessageBoxImage.None;

    /// <summary>
    /// メッセージボックスの既定の結果を指定する値
    /// </summary>
    public MessageBoxResult DefaultResult { get; set; } = MessageBoxResult.None;

    /// <summary>
    /// オプションを指定する値
    /// </summary>
    public MessageBoxOptions Options { get; set; } = MessageBoxOptions.None;

    /// <summary>
    /// 結果
    /// </summary>
    public MessageBoxResult Result { get; set; } = MessageBoxResult.None;
}