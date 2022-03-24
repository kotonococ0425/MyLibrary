namespace MyLibrary.Wpf.Messaging.Messages;

/// <summary>
/// ダイアログ表示用のメッセージ
/// </summary>
public class ShowDialogMessage
{
    public object ViewModel { get; }

    public bool AllowOwner { get; set; } = true;

    public bool IsModeless { get; set; }

    public WindowStartupLocation? WindowStartupLocation { get; set; }

    public bool? ShowInTaskbar { get; set; }

    public ShowDialogMessage(object viewModel)
    {
        ViewModel = viewModel;
    }
}
