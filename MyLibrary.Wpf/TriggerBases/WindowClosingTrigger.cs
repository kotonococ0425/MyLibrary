using Microsoft.Xaml.Behaviors;
using System.ComponentModel;

namespace MyLibrary.Wpf.TriggerBases;

[TypeConstraint(typeof(Window))]
public class WindowClosingTrigger : TriggerBase<Window>
{
    protected override void OnAttached() => AssociatedObject.Closing += WindowClosing;

    protected override void OnDetaching() => AssociatedObject.Closing -= WindowClosing;

    private void WindowClosing(object? sender, CancelEventArgs e) => InvokeActions(e);
}
