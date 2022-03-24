using MyLibrary.Wpf.Converters;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace MyLibrary.Wpf.Controls;

public class CustomTextBox : TextBox
{
    public static readonly DependencyProperty ForProperty;

    /// <summary>
    /// 数値入力のみかどうか
    /// </summary>
    public static readonly DependencyProperty IsIntegerOnlyProperty;

    /// <summary>
    /// 最小幅を最大入力可能文字数に合わせて自動調整するかどうか
    /// </summary>
    public static readonly DependencyProperty IsMinWidthLinkedToMaxLengthProperty;

    static CustomTextBox()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomTextBox), new FrameworkPropertyMetadata(typeof(CustomTextBox)));
        ForProperty = DependencyProperty.Register(nameof(For), typeof(string), typeof(CustomTextBox), new PropertyMetadata(""));
        IsIntegerOnlyProperty = DependencyProperty.Register(nameof(IsIntegerOnly), typeof(bool), typeof(CustomTextBox), new PropertyMetadata(false));
        IsMinWidthLinkedToMaxLengthProperty = DependencyProperty.Register(nameof(IsMinWidthLinkedToMaxLength), typeof(bool), typeof(CustomTextBox), new FrameworkPropertyMetadata(false));
    }

    public string For { get => (string)GetValue(ForProperty); set => SetValue(ForProperty, value); }

    public bool IsIntegerOnly { get => (bool)GetValue(IsIntegerOnlyProperty); set => SetValue(IsIntegerOnlyProperty, value); }

    public bool IsMinWidthLinkedToMaxLength { get => (bool)GetValue(IsMinWidthLinkedToMaxLengthProperty); set => SetValue(IsMinWidthLinkedToMaxLengthProperty, value); }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        DataContextChanged += SetContent;

        if (IsIntegerOnly)
        {
            /// IME入力不可
            InputMethod.SetIsInputMethodEnabled(this, false);

            /// 数値以外の入力不可
            PreviewTextInput += (sender, e) => e.Handled = !Regex.IsMatch(e.Text.ToString(), @"[0-9]");

            /// 数値以外のペースト不可
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, (sender, e) =>
            {
                if (int.TryParse(Clipboard.GetText(), out _))
                {
                    Paste();
                }
            }));

            MaxLength = int.MaxValue.ToString().Length - 1;
        }

        if (IsMinWidthLinkedToMaxLength)
        {
            var relativeSource = new RelativeSource(RelativeSourceMode.Self);
            var converter = new LengthToWidthConverter();
            var binding = new Binding(nameof(MaxLength)) { RelativeSource = relativeSource, Converter = converter };
            SetBinding(MinWidthProperty, binding);
        }
    }

    private void SetContent(object? sender, DependencyPropertyChangedEventArgs e)
    {
        if (DataContext is not null && !For.IsNullOrEmpty())
        {
            var propertyInfo = DataContext.GetType().GetProperty(For);
            if (propertyInfo is null)
            {
                throw new ArgumentException("指定されたプロパティ名が見つかりませんでした｡", nameof(sender));
            }

            MaxLength = propertyInfo.GetCustomAttributeOrDefault<MaxLengthAttribute>()?.Length ?? 0;
            var propertyType = propertyInfo.PropertyType;
            IsIntegerOnly = propertyType == typeof(int) || propertyType == typeof(int?);
        }
    }
}
