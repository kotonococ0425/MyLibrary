using MaterialDesignThemes.Wpf;
using Microsoft.Toolkit.Mvvm.Input;
using MyLibrary.Wpf.Controls.DataContexts;
using System.Windows.Controls.Primitives;

namespace MyLibrary.Wpf.Controls;

public class MultiInput : ListBox
{
    /// <summary>
    /// <see cref="ControlTemplate"/> の <see cref="CustomLabel"/> の名前
    /// </summary>
    private const string LabelName = "Label";

    /// <summary>
    /// <see cref="ControlTemplate"/> の <see cref="Button"/> の名前
    /// </summary>
    private const string AddBtnName = "AddBtn";

    public static readonly DependencyProperty ForProperty;

    static MultiInput()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(MultiInput), new FrameworkPropertyMetadata(typeof(MultiInput)));
        ForProperty = DependencyProperty.Register(nameof(For), typeof(string), typeof(MultiInput), new FrameworkPropertyMetadata(""));
    }

    private static FrameworkElementFactory CreateGridFactory()
    {
        var gridFactory = new FrameworkElementFactory(typeof(Grid));
        var columnDefinition1 = new FrameworkElementFactory(typeof(ColumnDefinition));
        columnDefinition1.SetValue(ColumnDefinition.WidthProperty, new GridLength(1, GridUnitType.Star));
        gridFactory.AppendChild(columnDefinition1);
        var columnDefinition2 = new FrameworkElementFactory(typeof(ColumnDefinition));
        columnDefinition2.SetValue(ColumnDefinition.WidthProperty, GridLength.Auto);
        gridFactory.AppendChild(columnDefinition2);
        return gridFactory;
    }

    private static FrameworkElementFactory CreateRemoveButtonFactory(MultiInputDataContext itemDataContexts)
    {
        var removeBtnFactory = new FrameworkElementFactory(typeof(Button));
        removeBtnFactory.SetBinding(IsEnabledProperty, new Binding(nameof(IMultiInputItemDataContext.RemoveBtnIsEnabled)));
        var relativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(ListBoxItem), 1);
        var binding = new Binding() { Path = new PropertyPath(AlternationIndexProperty), RelativeSource = relativeSource };
        removeBtnFactory.SetValue(ButtonBase.CommandParameterProperty, binding);
        var relayCommand = new RelayCommand<int?>((index) => itemDataContexts.RemoveItemAt(index));
        removeBtnFactory.SetValue(ButtonBase.CommandProperty, relayCommand);
        removeBtnFactory.SetValue(WidthProperty, Convert.ToDouble(40));
        removeBtnFactory.SetValue(MarginProperty, new Thickness(8, 0, 8, 0));
        removeBtnFactory.SetValue(PaddingProperty, new Thickness(0));
        removeBtnFactory.SetValue(VerticalAlignmentProperty, VerticalAlignment.Bottom);

        // コンテンツの要素であるマイナスアイコンの作成
        var minuspackIconFactory = new FrameworkElementFactory(typeof(PackIcon));
        minuspackIconFactory.SetValue(PackIcon.KindProperty, PackIconKind.Minus);
        removeBtnFactory.SetValue(Grid.ColumnProperty, 1);
        removeBtnFactory.AppendChild(minuspackIconFactory);
        return removeBtnFactory;
    }

    public string For { get => (string)GetValue(ForProperty); set => SetValue(ForProperty, value); }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        HorizontalContentAlignment = HorizontalAlignment.Stretch;
        AlternationCount = int.MaxValue;

        var label = (CustomLabel)GetTemplateChild(LabelName);
        label.For = For;
        var itemDataContexts = (MultiInputDataContext)ItemsSource;
        label.DataContext = itemDataContexts.First();

        var addBtn = (Button)GetTemplateChild(AddBtnName);
        addBtn.Command = new RelayCommand(() => itemDataContexts.AddNewItem());

        var gridFactory = CreateGridFactory();
        gridFactory.AppendChild(CreateCustomTextBoxFactory());
        gridFactory.AppendChild(CreateRemoveButtonFactory(itemDataContexts));
        ItemTemplate = new DataTemplate() { VisualTree = gridFactory };
    }

    private FrameworkElementFactory CreateCustomTextBoxFactory()
    {
        var textBoxFactory = new FrameworkElementFactory(typeof(CustomTextBox));
        textBoxFactory.SetBinding(TextBox.TextProperty, new Binding(For));
        textBoxFactory.SetValue(CustomTextBox.ForProperty, For);
        textBoxFactory.SetValue(Grid.ColumnProperty, 0);
        return textBoxFactory;
    }
}
