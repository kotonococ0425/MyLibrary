using Microsoft.Xaml.Behaviors;

namespace MyLibrary.Wpf.TriggerBases;

[TypeConstraint(typeof(FrameworkElement))]
public class FrameworkElementLoadedTrigger : TriggerBase<FrameworkElement>
{
    protected override void OnAttached() => AssociatedObject.Loaded += FrameworkElementLoaded;

    protected override void OnDetaching() => AssociatedObject.Loaded -= FrameworkElementLoaded;

    private void FrameworkElementLoaded(object? sender, RoutedEventArgs e) => InvokeActions(e);
}
