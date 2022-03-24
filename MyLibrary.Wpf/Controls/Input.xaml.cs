namespace MyLibrary.Wpf.Controls;

public class Input : Control
{
    /// <summary>
    /// <see cref="ControlTemplate"/> の <see cref="Label"/> の名前
    /// </summary>
    private const string LabelName = "Label";

    /// <summary>
    /// <see cref="ControlTemplate"/> の <see cref="CustomTextBox"/> の名前
    /// </summary>
    private const string TextBoxName = "TextBox";

    public static readonly DependencyProperty ForProperty;

    public static readonly DependencyProperty HeaderProperty;

    public static readonly DependencyProperty MaxLengthProperty;

    public static readonly DependencyProperty TextProperty;

    public static readonly DependencyProperty IsReadOnlyProperty;

    public static readonly DependencyProperty IsIntegerOnlyProperty;

    public static readonly DependencyProperty IsMinWidthLinkedToMaxLengthProperty;

    static Input()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(Input), new FrameworkPropertyMetadata(typeof(Input)));
        ForProperty = DependencyProperty.Register(nameof(For), typeof(string), typeof(Input), new FrameworkPropertyMetadata(""));
        HeaderProperty = DependencyProperty.Register(nameof(Header), typeof(string), typeof(Input), new FrameworkPropertyMetadata(null));
        MaxLengthProperty = DependencyProperty.Register(nameof(MaxLength), typeof(int?), typeof(Input), new FrameworkPropertyMetadata(null));
        TextProperty = DependencyProperty.Register(nameof(Text), typeof(string), typeof(Input), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        IsReadOnlyProperty = DependencyProperty.Register(nameof(IsReadOnly), typeof(bool), typeof(Input), new FrameworkPropertyMetadata(false));
        IsIntegerOnlyProperty = DependencyProperty.Register(nameof(IsIntegerOnlyProperty), typeof(bool), typeof(Input), new FrameworkPropertyMetadata(false));
        IsMinWidthLinkedToMaxLengthProperty = DependencyProperty.Register(nameof(IsMinWidthLinkedToMaxLengthProperty), typeof(bool), typeof(Input), new FrameworkPropertyMetadata(false));
    }

    public string For { get => (string)GetValue(ForProperty); set => SetValue(ForProperty, value); }

    public string? Header { get => (string)GetValue(HeaderProperty); set => SetValue(HeaderProperty, value); }

    public int? MaxLength { get => (int?)GetValue(MaxLengthProperty); set => SetValue(MaxLengthProperty, value); }

    public string Text { get => (string)GetValue(TextProperty); set => SetValue(TextProperty, value); }

    public bool IsReadOnly { get => (bool)GetValue(IsReadOnlyProperty); set => SetValue(IsReadOnlyProperty, value); }

    public bool IsIntegerOnly { get => (bool)GetValue(IsIntegerOnlyProperty); set => SetValue(IsIntegerOnlyProperty, value); }

    public bool IsMinWidthLinkedToMaxLength { get => (bool)GetValue(IsMinWidthLinkedToMaxLengthProperty); set => SetValue(IsMinWidthLinkedToMaxLengthProperty, value); }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        var label = (CustomLabel)GetTemplateChild(LabelName);
        label.For = For;
        label.Content = Header;

        var textBox = (CustomTextBox)GetTemplateChild(TextBoxName);
        textBox.For = For;
        textBox.MaxLength = MaxLength ?? 0;
        textBox.IsReadOnly = IsReadOnly;
        textBox.IsIntegerOnly = IsIntegerOnly;
        textBox.IsMinWidthLinkedToMaxLength = IsMinWidthLinkedToMaxLength;
        textBox.SetBinding(TextBox.TextProperty, new Binding($"{nameof(DataContext)}.{For}") { RelativeSource = new(RelativeSourceMode.FindAncestor, typeof(Input), 1), TargetNullValue = "" });
    }
}