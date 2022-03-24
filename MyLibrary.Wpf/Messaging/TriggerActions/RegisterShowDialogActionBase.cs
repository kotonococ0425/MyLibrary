using Microsoft.Toolkit.Mvvm.Messaging;
using Microsoft.Xaml.Behaviors;
using MyLibrary.Wpf.Messaging.Messages;
using MyLibrary.Wpf.Messaging.Token;
using MyLibrary.Wpf.TriggerBases;

namespace MyLibrary.Wpf.Messaging.TriggerActions;

/// <summary>
/// �_�C�A���O��\������A�N�V������o�^���邽�߂̊��N���X
/// </summary>
[TypeConstraint(typeof(Window))]
[DefaultTrigger(typeof(Window), typeof(FrameworkElementLoadedTrigger))]
public abstract class RegisterShowDialogActionBase : TriggerAction<Window>
{
    protected override void Invoke(object parameter)
    {
        base.OnAttached();
        var viewModel = (ITokenMessaging)AssociatedObject.DataContext;
        var token = viewModel.MessagingToken;
        WeakReferenceMessenger.Default.Register<ShowDialogMessage, MessagingToken>(this, token, ShowDialog);
    }

    /// <summary>
    /// ViewModel����Ή�����View�̃C���X�^���X���쐬����B
    /// ���h���N���X�͂��̃��\�b�h�̂݃I�[�o�[���C�h���Ďg�p�ł���B
    /// </summary>
    /// <param name="viewModel"></param>
    /// <returns></returns>
    public abstract Window CreateView(object viewModel);

    private void ShowDialog(object recipient, ShowDialogMessage message)
    {
        var window = CreateView(message.ViewModel);
        window.DataContext = message.ViewModel;

        if (message.AllowOwner)
        {
            window.Owner = AssociatedObject;
        }

        if (message.WindowStartupLocation.HasValue)
        {
            window.WindowStartupLocation = message.WindowStartupLocation.Value;
        }

        if (message.ShowInTaskbar.HasValue)
        {
            window.ShowInTaskbar = message.ShowInTaskbar.Value;
        }

        if (message.IsModeless)
        {
            window.Show();
        }
        else
        {
            window.ShowDialog();
        }
    }
}