namespace MyLibrary.Wpf.Converters;

[ValueConversion(typeof(bool), typeof(Visibility))]
public class BoolToVisibilityConverter : BaseConverter<bool, Visibility>
{
    public Visibility TrueTo { get; set; }
    public Visibility FalseTo { get; set; }

    public override Visibility Convert(bool value, object parameter, CultureInfo culture)
    {
        return value ? TrueTo : FalseTo;
    }

    public override bool ConvertBack(Visibility value, object parameter, CultureInfo culture)
    {
        return value == TrueTo;
    }
}
