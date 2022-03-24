using System.Windows.Markup;

namespace MyLibrary.Wpf.Converters;

[ValueConversion(typeof(Enum), typeof(bool))]
public class EnumToBooleanConverter : MarkupExtension, IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is not null && parameter is not null && (value.ToString() == parameter.ToString());
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is null || parameter is null || !(bool)value ? Binding.DoNothing : Enum.Parse(targetType, parameter.ToString()!);
    }

    public override object ProvideValue(IServiceProvider serviceProvider) => this;
}