using Microsoft.Xaml.Behaviors;
using System.Windows.Controls.Primitives;

namespace MyLibrary.Wpf.TriggerBases;

[TypeConstraint(typeof(ButtonBase))]
public class ButtonBaseMouseEnterTrigger : TriggerBase<ButtonBase>
{
    protected override void OnAttached() => AssociatedObject.MouseEnter += ButtonBaseMouseEnter;

    protected override void OnDetaching() => AssociatedObject.MouseEnter -= ButtonBaseMouseEnter;

    private void ButtonBaseMouseEnter(object sender, RoutedEventArgs e) => InvokeActions(e);
}
