using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Wpf.Controls;

public class CustomLabel : Label
{
    public static readonly DependencyProperty ForProperty;

    static CustomLabel()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomLabel), new FrameworkPropertyMetadata(typeof(CustomLabel)));
        ForProperty = DependencyProperty.Register(nameof(For), typeof(string), typeof(CustomLabel), new PropertyMetadata(""));
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
        }
    }
}
