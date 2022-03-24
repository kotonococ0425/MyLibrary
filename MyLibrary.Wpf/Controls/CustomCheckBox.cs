using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Wpf.Controls;

public class CustomCheckBox : CheckBox
{
    public static readonly DependencyProperty ForProperty;

    static CustomCheckBox()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomCheckBox), new FrameworkPropertyMetadata(typeof(CustomCheckBox)));
        ForProperty = DependencyProperty.Register(nameof(For), typeof(string), typeof(CustomCheckBox), new PropertyMetadata(""));
    }

    public string For { get => (string)GetValue(ForProperty); set => SetValue(ForProperty, value); }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        DataContextChanged += SetContent;
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

            Content = propertyInfo.GetCustomAttributeOrDefault<DisplayAttribute>()?.Name;
            SetBinding(IsCheckedProperty, new Binding(For));
        }
    }
}
