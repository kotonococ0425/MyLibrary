using Microsoft.Xaml.Behaviors;

namespace MyLibrary.Wpf.TriggerBases;

[TypeConstraint(typeof(UIElement))]
public class UIElementMouseLeftButtonUpTrigger : TriggerBase<UIElement>
{
    protected override void OnAttached() => AssociatedObject.MouseLeftButtonUp += UIElementMouseLeftButtonUp;

    protected override void OnDetaching() => AssociatedObject.MouseLeftButtonUp -= UIElementMouseLeftButtonUp;

    private void UIElementMouseLeftButtonUp(object sender, RoutedEventArgs e) => InvokeActions(e);
}
