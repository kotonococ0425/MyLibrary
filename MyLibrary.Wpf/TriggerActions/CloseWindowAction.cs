using Microsoft.Xaml.Behaviors;

namespace MyLibrary.Wpf.TriggerActions;

/// <summary>
/// <see cref="Window"/> ‚ð•Â‚¶‚éƒAƒNƒVƒ‡ƒ“
/// </summary>
[TypeConstraint(typeof(UIElement))]
public class CloseWindowAction : TriggerAction<Button>
{
    protected override void Invoke(object parameter)
    {
        var routedEventArgs = (RoutedEventArgs)parameter;
        var source = (DependencyObject)routedEventArgs.Source;

        while (source is not Window)
        {
            source = VisualTreeHelper.GetParent(source);
        }

        ((Window)source).Close();
    }
}
