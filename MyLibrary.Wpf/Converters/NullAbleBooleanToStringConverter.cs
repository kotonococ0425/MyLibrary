namespace MyLibrary.Wpf.Converters;

[ValueConversion(typeof(bool?), typeof(string))]
public class NullAbleBooleanToStringConverter : BaseConverter<bool?, string>
{
    public string TrueTo { get; set; } = "";

    public string FalseTo { get; set; } = "";

    public string NullTo { get; set; } = "";

    public override string Convert(bool? value, object parameter, CultureInfo culture)
    {
        if (value is null)
        {
            return NullTo;
        }

        return value.Value ? TrueTo : FalseTo;
    }

    public override bool? ConvertBack(string? value, object parameter, CultureInfo culture)
    {
        if (value is null)
        {
            return null;
        }

        return value == TrueTo;
    }
}