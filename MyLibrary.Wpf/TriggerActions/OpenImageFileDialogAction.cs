using Microsoft.Win32;
using Microsoft.Xaml.Behaviors;
using MyLibrary.Wpf.TriggerBases;

namespace MyLibrary.Wpf.TriggerActions;

/// <summary>
/// 画像ファイルダイアログを開くためのアクション
/// </summary>
[TypeConstraint(typeof(Button))]
[DefaultTrigger(typeof(Button), typeof(ButtonBaseClickTrigger))]
public class OpenImageFileDialogAction : TriggerAction<Button>
{
    public static readonly DependencyProperty FileNameProperty = DependencyProperty.Register(nameof(FileName), typeof(string), typeof(OpenImageFileDialogAction), new FrameworkPropertyMetadata(null));

    public string FileName { get => (string)GetValue(FileNameProperty); set => SetValue(FileNameProperty, value); }

    protected override void Invoke(object parameter)
    {
        var openFileDialog = new OpenFileDialog() { Filter = "画像|*.png;*.jpg;*.bmp" };
        if (openFileDialog.ShowDialog().GetValueOrDefault())
        {
            FileName = openFileDialog.FileName;
        }
    }
}
