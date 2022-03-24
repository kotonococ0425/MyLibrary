namespace MyLibrary.Wpf.Controls.DataContexts;

public class ColorSelectionDataContext
{
    public Color Color { get; set; }

    public string Name { get; set; } = "";

    public ColorSelectionDataContext(Color color, string name)
    {
        Color = color;
        Name = name;
    }
}
