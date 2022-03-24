using Microsoft.VisualBasic.FileIO;
using System.Text;

namespace MyLibrary.Csv;

public class CsvContext
{
    private readonly string _path;

    private readonly Encoding _encoding;

    private readonly bool _hasFieldsEnclosedInQuotes;

    private readonly bool _trimWhiteSpace;

    private string[]? _lines;

    public CsvContext(string path, Encoding encoding, bool hasFieldsEnclosedInQuotes = true, bool trimWhiteSpace = true)
    {
        _path = path;
        _encoding = encoding ?? Encoding.UTF8;
        _hasFieldsEnclosedInQuotes = hasFieldsEnclosedInQuotes;
        _trimWhiteSpace = trimWhiteSpace;
    }

    public int GetNumberOfLines()
    {
        return GetLines().Length;
    }

    public IEnumerable<string[]> EnumerateAll()
    {
        for (var i = 0; i < GetNumberOfLines(); i++)
        {
            using var memoryStream = new MemoryStream(Encoding.Default.GetBytes(GetLines()[i]));
            using var textFieldParser = new TextFieldParser(memoryStream, _encoding)
            {
                TextFieldType = FieldType.Delimited,
                Delimiters = new[] { "," },
                HasFieldsEnclosedInQuotes = _hasFieldsEnclosedInQuotes,
                TrimWhiteSpace = _trimWhiteSpace
            };
            yield return textFieldParser.ReadFields() ?? Array.Empty<string>();
        }
    }

    private string[] GetLines()
    {
        return _lines ??= File.ReadAllLines(_path, _encoding);
    }
}
