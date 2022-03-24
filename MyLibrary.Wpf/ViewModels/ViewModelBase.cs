using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Messaging;
using MyLibrary.Wpf.Messaging.Messages;
using MyLibrary.Wpf.Messaging.Token;

namespace MyLibrary.Wpf.ViewModels;

public abstract class ViewModelBase : ObservableObject, ITokenMessaging
{
    /// <summary>
    /// ウィンドウを閉じるようにメッセージを送信する。
    /// </summary>
    /// <param name="viewModel"></param>
    protected static void CloseWindow(ITokenMessaging viewModel)
    {
        SendMessage(new CloseWindowMessage(), viewModel.MessagingToken);
    }

    /// <summary>
    /// MessagingパターンでViewにメッセージを送信する。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="message"></param>
    private static void SendMessage<T>(T message, MessagingToken messagingToken) where T : class
    {
        WeakReferenceMessenger.Default.Send(message, messagingToken);
    }

    public MessagingToken MessagingToken { get; set; } = new MessagingToken();

    /// <summary>
    /// MessagingパターンでViewにメッセージを送信する。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="message"></param>
    private void SendMessage<T>(T message) where T : class
    {
        WeakReferenceMessenger.Default.Send(message, MessagingToken);
    }

    /// <summary>
    /// エラーメッセージを表示するようにメッセージを送信する。
    /// </summary>
    /// <param name="messageBoxText"></param>
    protected void ShowErrorMessage(string text)
    {
        SendMessage(ShowMessageBoxMessage.GetErrorMessageBox(text));
    }

    /// <summary>
    /// モーダルウィンドウを表示するようにメッセージを送信する。
    /// </summary>
    /// <param name="viewModel"></param>
    protected void ShowModalWindow<T>(T viewModel) where T : class
    {
        SendMessage(new ShowDialogMessage(viewModel));
    }

    /// <summary>
    /// モードレスウィンドウを表示するようにメッセージを送信する。
    /// </summary>
    /// <param name="viewModel"></param>
    protected void ShowModelessWindow<T>(T viewModel) where T : class
    {
        SendMessage(new ShowDialogMessage(viewModel) { IsModeless = true, AllowOwner = false });
    }
}
