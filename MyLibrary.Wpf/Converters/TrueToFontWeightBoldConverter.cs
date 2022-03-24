namespace MyLibrary.Wpf.Converters;

[ValueConversion(typeof(bool), typeof(FontWeight))]
public class TrueToFontWeightBoldConverter : BaseConverter<bool, FontWeight>
{
    public override FontWeight Convert(bool value, object parameter, CultureInfo culture)
    {
        return value ? FontWeights.Bold : FontWeights.Normal;
    }

    public override bool ConvertBack(FontWeight value, object parameter, CultureInfo culture)
    {
        return value == FontWeights.Bold;
    }
}
