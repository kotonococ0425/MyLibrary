using Microsoft.Xaml.Behaviors;
using System.Windows.Controls.Primitives;

namespace MyLibrary.Wpf.TriggerBases;

[TypeConstraint(typeof(ButtonBase))]
public class ButtonBaseClickTrigger : TriggerBase<ButtonBase>
{
    protected override void OnAttached() => AssociatedObject.Click += ButtonBaseClick;

    protected override void OnDetaching() => AssociatedObject.Click -= ButtonBaseClick;

    private void ButtonBaseClick(object sender, RoutedEventArgs e) => InvokeActions(e);
}
