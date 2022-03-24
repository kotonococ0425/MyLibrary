using MyLibrary.Wpf.ViewModels;
using MyLibrary.Wpf.Views;

namespace MyLibrary.Wpf.Controls;

public class ColorSelection : Control
{
    private const string TextBlockName = "TextBlock";

    private const string ColorPickerBtnName = "ColorPickerBtn";

    public static readonly DependencyProperty HeaderProperty;

    public static readonly DependencyProperty SelectedColorProperty;

    static ColorSelection()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorSelection), new FrameworkPropertyMetadata(typeof(ColorSelection)));
        SelectedColorProperty = DependencyProperty.Register(nameof(SelectedColor), typeof(Color), typeof(ColorSelection), new FrameworkPropertyMetadata(Colors.Black, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        HeaderProperty = DependencyProperty.Register(nameof(Header), typeof(string), typeof(ColorSelection), new FrameworkPropertyMetadata(""));
    }

    public Color SelectedColor { get => (Color)GetValue(SelectedColorProperty); set => SetValue(SelectedColorProperty, value); }

    public string Header { get => (string)GetValue(HeaderProperty); set => SetValue(HeaderProperty, value); }

    private Button? ColorPickerBtn
    {
        get => _colorPickerBtn;

        set
        {
            if (_colorPickerBtn is not null)
            {
                _colorPickerBtn.Click -= ColorPickerBtn_Click;
            }

            _colorPickerBtn = value;

            if (_colorPickerBtn is not null)
            {
                _colorPickerBtn.Click += ColorPickerBtn_Click;
            }
        }
    }
    private Button? _colorPickerBtn;

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        var textBlock = (TextBlock)GetTemplateChild(TextBlockName);
        textBlock.Text = Header;

        ColorPickerBtn = (Button)GetTemplateChild(ColorPickerBtnName);

        // なぜかxaml側で日本語を使うとエンコードエラーが起きるのでこちらで設定
        ColorPickerBtn.Content = "色を選択";
    }

    private void ColorPickerBtn_Click(object sender, RoutedEventArgs e)
    {
        var viewModel = new ColorPickerWindowViewModel() { SelectedColor = SelectedColor };
        var window = new ColorPickerWindow
        {
            DataContext = viewModel,
            Owner = Window.GetWindow(this),
            WindowStartupLocation = WindowStartupLocation.CenterOwner,
        };
        window.ShowDialog();
        if (viewModel.Result is ColorPickerWindowViewModel.ColorPickerWindowResult.Ok)
        {
            SelectedColor = viewModel.SelectedColor;
        }
    }
}
