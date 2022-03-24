namespace MyLibrary.Wpf.Converters;

[ValueConversion(typeof(string), typeof(object))]
public class NullOrEmptyToImageConverter : BaseConverter<string, object>
{
    public override object Convert(string? value, object parameter, CultureInfo culture) => string.IsNullOrEmpty(value) ? DependencyProperty.UnsetValue : value;

    public override string ConvertBack(object? value, object parameter, CultureInfo culture) => throw new NotImplementedException();
}