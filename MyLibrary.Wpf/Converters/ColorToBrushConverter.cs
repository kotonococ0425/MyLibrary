namespace MyLibrary.Wpf.Converters;

[ValueConversion(typeof(Color), typeof(Brush))]
public class ColorToBrushConverter : BaseConverter<Color, Brush>
{
    public override Brush Convert(Color value, object parameter, CultureInfo culture)
    {
        if (value is Color color)
        {
            return new SolidColorBrush(color);
        }

        return (Brush)Binding.DoNothing;
    }

    public override Color ConvertBack(Brush? value, object parameter, CultureInfo culture)
    {
        if (value is SolidColorBrush brush)
        {
            return brush.Color;
        }

        return default;
    }
}
