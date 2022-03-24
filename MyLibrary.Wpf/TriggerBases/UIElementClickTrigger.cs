using Microsoft.Xaml.Behaviors;
using System.Windows.Input;

namespace MyLibrary.Wpf.TriggerBases;

[TypeConstraint(typeof(UIElement))]
public class UIElementClickTrigger : TriggerBase<UIElement>
{
    protected override void OnAttached()
    {
        AssociatedObject.MouseLeftButtonDown += UIElementMouseLeftButtonDown;
        AssociatedObject.MouseLeftButtonUp += UIElementMouseLeftButtonUp;
    }

    protected override void OnDetaching()
    {
        AssociatedObject.MouseLeftButtonDown -= UIElementMouseLeftButtonDown;
        AssociatedObject.MouseLeftButtonUp -= UIElementMouseLeftButtonUp;
    }

    private void UIElementMouseLeftButtonDown(object sender, MouseEventArgs e)
    {
        e.Handled = true;
        AssociatedObject.CaptureMouse();
    }

    private void UIElementMouseLeftButtonUp(object sender, MouseEventArgs e)
    {
        if (!AssociatedObject.IsMouseCaptured)
        {
            return;
        }

        e.Handled = true;
        AssociatedObject.ReleaseMouseCapture();
        if (AssociatedObject.InputHitTest(e.GetPosition(AssociatedObject)) is not null)
        {
            InvokeActions(e);
        }
    }
}
