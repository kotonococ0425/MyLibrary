using Microsoft.Toolkit.Mvvm.Messaging;
using Microsoft.Xaml.Behaviors;
using MyLibrary.Wpf.Messaging.Messages;
using MyLibrary.Wpf.Messaging.Token;
using MyLibrary.Wpf.TriggerBases;

namespace MyLibrary.Wpf.Messaging.TriggerActions;

/// <summary>
/// <see cref="Window"/> を閉じるアクションを登録するための基底クラス
/// </summary>
[TypeConstraint(typeof(Window))]
[DefaultTrigger(typeof(Window), typeof(FrameworkElementLoadedTrigger))]
public class RegisterCloseWindowAction : TriggerAction<Window>
{
    protected override void Invoke(object parameter)
    {
        base.OnAttached();
        var viewModel = (ITokenMessaging)AssociatedObject.DataContext;
        var token = viewModel.MessagingToken;
        WeakReferenceMessenger.Default.Register<CloseWindowMessage, MessagingToken>(this, token, CloseWindow);
    }

    private void CloseWindow(object recipient, CloseWindowMessage message)
    {
        AssociatedObject.Close();
    }
}