using Microsoft.Xaml.Behaviors;
using System.Windows.Controls.Primitives;

namespace MyLibrary.Wpf.TriggerBases;

[TypeConstraint(typeof(ButtonBase))]
public class ButtonBaseMouseLeaveTrigger : TriggerBase<ButtonBase>
{
    protected override void OnAttached() => AssociatedObject.MouseLeave += ButtonBaseMouseLeave;

    protected override void OnDetaching() => AssociatedObject.MouseLeave -= ButtonBaseMouseLeave;

    private void ButtonBaseMouseLeave(object sender, RoutedEventArgs e) => InvokeActions(e);
}
