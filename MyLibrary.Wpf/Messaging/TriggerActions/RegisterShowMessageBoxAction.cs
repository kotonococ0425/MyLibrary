using Microsoft.Toolkit.Mvvm.Messaging;
using Microsoft.Xaml.Behaviors;
using MyLibrary.Wpf.Messaging.Messages;
using MyLibrary.Wpf.Messaging.Token;
using MyLibrary.Wpf.TriggerBases;

namespace MyLibrary.Wpf.Messaging.TriggerActions;

/// <summary>
/// メッセージボックスを表示するアクションを登録するクラス
/// </summary>
[TypeConstraint(typeof(FrameworkElement))]
[DefaultTrigger(typeof(FrameworkElement), typeof(FrameworkElementLoadedTrigger))]
public class RegisterShowMessageBoxAction : TriggerAction<FrameworkElement>
{
    protected override void Invoke(object parameter)
    {
        base.OnAttached();
        var viewModel = (ITokenMessaging)AssociatedObject.DataContext;
        var token = viewModel.MessagingToken;
        WeakReferenceMessenger.Default.Register<ShowMessageBoxMessage, MessagingToken>(this, token, ShowMessageBox);
    }

    private static void ShowMessageBox(object recipient, ShowMessageBoxMessage message)
    {
        message.Result = MessageBox.Show(message.MessageBoxText, message.Caption, message.Button, message.Icon, message.DefaultResult, message.Options);
    }
}
