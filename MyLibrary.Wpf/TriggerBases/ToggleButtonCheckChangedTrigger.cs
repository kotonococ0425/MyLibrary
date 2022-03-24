using Microsoft.Xaml.Behaviors;
using System.Windows.Controls.Primitives;

namespace MyLibrary.Wpf.TriggerBases;

[TypeConstraint(typeof(ToggleButton))]
public class ToggleButtonCheckChangedTrigger : TriggerBase<ToggleButton>
{
    protected override void OnAttached()
    {
        AssociatedObject.Checked += ToggleButtonCheckChanged;
        AssociatedObject.Unchecked += ToggleButtonCheckChanged;
        AssociatedObject.Indeterminate += ToggleButtonCheckChanged;
    }

    protected override void OnDetaching()
    {
        AssociatedObject.Checked -= ToggleButtonCheckChanged;
        AssociatedObject.Unchecked -= ToggleButtonCheckChanged;
        AssociatedObject.Indeterminate -= ToggleButtonCheckChanged;
    }

    private void ToggleButtonCheckChanged(object sender, RoutedEventArgs e) => InvokeActions(e);
}
