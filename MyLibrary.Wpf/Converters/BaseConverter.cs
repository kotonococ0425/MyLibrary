using System.Windows.Markup;

namespace MyLibrary.Wpf.Converters;

public abstract class BaseConverter<TSource, TTarget> : MarkupExtension, IValueConverter
{
    public abstract TTarget Convert(TSource? value, object parameter, CultureInfo culture);

    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return Convert((TSource)value, parameter, culture);
    }

    public abstract TSource ConvertBack(TTarget? value, object parameter, CultureInfo culture);

    public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return ConvertBack((TTarget)value, parameter, culture);
    }

    public override object ProvideValue(IServiceProvider serviceProvider) => this;
}
