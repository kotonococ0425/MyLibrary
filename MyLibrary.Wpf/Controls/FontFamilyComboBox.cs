using System.Windows.Controls.Primitives;
using System.Windows.Markup;

namespace MyLibrary.Wpf.Controls;

public class FontFamilyComboBox : Control
{
    private const string ComboBoxName = "ComboBox";

    private const string TextBlockName = "TextBlock";

    public static readonly DependencyProperty SelectedItemProperty;

    static FontFamilyComboBox()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(FontFamilyComboBox), new FrameworkPropertyMetadata(typeof(FontFamilyComboBox)));
        SelectedItemProperty = DependencyProperty.Register(nameof(SelectedItem), typeof(FontFamily), typeof(FontFamilyComboBox), new FrameworkPropertyMetadata(SystemFonts.MessageFontFamily, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
    }

    public FontFamily SelectedItem { get => (FontFamily)GetValue(SelectedItemProperty); set => SetValue(SelectedItemProperty, value); }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        var textBlock = (TextBlock)GetTemplateChild(TextBlockName);
        textBlock.Text = "フォント";

        Language = XmlLanguage.GetLanguage(Thread.CurrentThread.CurrentCulture.Name);
        var comboBox = (ComboBox)GetTemplateChild(ComboBoxName);
        comboBox.ItemsSource = Fonts.SystemFontFamilies.OrderBy(fontFamily => fontFamily.FamilyNames.FirstOrDefault(name => name.Key == Language).Value ?? fontFamily.Source);
        comboBox.SetBinding(Selector.SelectedItemProperty, new Binding(nameof(SelectedItem)) { RelativeSource = new(RelativeSourceMode.FindAncestor, typeof(FontFamilyComboBox), 1) });
    }
}
