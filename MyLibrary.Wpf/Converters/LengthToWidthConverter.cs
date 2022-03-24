namespace MyLibrary.Wpf.Converters;

[ValueConversion(typeof(int), typeof(int))]
public class LengthToWidthConverter : BaseConverter<int, int>
{
    public override int Convert(int value, object parameter, CultureInfo culture) => (value + 1) * 8;

    public override int ConvertBack(int value, object parameter, CultureInfo culture) => (value / 8) - 1;
}