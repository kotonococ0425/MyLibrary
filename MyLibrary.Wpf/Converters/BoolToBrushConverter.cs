namespace MyLibrary.Wpf.Converters;

[ValueConversion(typeof(bool), typeof(SolidColorBrush))]
public class BoolToBrushConverter : BaseConverter<bool, SolidColorBrush>
{
    public SolidColorBrush TrueTo { get; set; } = Brushes.White;

    public SolidColorBrush FalseTo { get; set; } = Brushes.White;

    public override SolidColorBrush Convert(bool value, object parameter, CultureInfo culture)
    {
        return value ? TrueTo : FalseTo;
    }

    public override bool ConvertBack(SolidColorBrush? value, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}