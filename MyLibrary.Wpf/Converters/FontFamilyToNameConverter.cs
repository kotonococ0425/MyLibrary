using System.Windows.Markup;

namespace MyLibrary.Wpf.Converters;

[ValueConversion(typeof(FontFamily), typeof(string))]
public class FontFamilyToNameConverter : BaseConverter<FontFamily, string>
{
    public override string Convert(FontFamily? value, object parameter, CultureInfo culture)
    {
        var xmlLanguage = XmlLanguage.GetLanguage(culture.IetfLanguageTag);
        return value!.FamilyNames.FirstOrDefault(languageSpecificStringDictionary => languageSpecificStringDictionary.Key == xmlLanguage).Value ?? value.Source;
    }

    public override FontFamily ConvertBack(string? value, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
