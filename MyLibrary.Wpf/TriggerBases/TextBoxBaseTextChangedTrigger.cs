using Microsoft.Xaml.Behaviors;
using System.Windows.Controls.Primitives;

namespace MyLibrary.Wpf.TriggerBases;

[TypeConstraint(typeof(TextBoxBase))]
public class TextBoxBaseTextChangedTrigger : TriggerBase<TextBoxBase>
{
    protected override void OnAttached() => AssociatedObject.TextChanged += TextBoxBaseTextChanged;

    protected override void OnDetaching() => AssociatedObject.TextChanged -= TextBoxBaseTextChanged;

    private void TextBoxBaseTextChanged(object sender, RoutedEventArgs e) => InvokeActions(e);
}
