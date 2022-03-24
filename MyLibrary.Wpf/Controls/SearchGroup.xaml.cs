using MyLibrary.Wpf.Controls.DataContexts;

namespace MyLibrary.Wpf.Controls;

/// <summary>
/// 検索可能なフォームのカスタムコントロール
/// </summary>
public class SearchGroup : Control
{
    private const string ChildInputFieldName = "InputField";

    private const string ChildOutputFieldName = "OutputField";

    private const string ChildSearchBtnName = "SearchBtn";

    public static readonly DependencyProperty InputForProperty;

    public static readonly DependencyProperty InputHeaderProperty;

    public static readonly DependencyProperty InputTextProperty;

    public static readonly DependencyProperty InputMaxLengthProperty;

    public static readonly DependencyProperty IsIntegerOnlyProperty;

    public static readonly DependencyProperty OutputForProperty;

    public static readonly DependencyProperty OutputHeaderProperty;

    public static readonly DependencyProperty OutputTextProperty;

    private static readonly RelativeSource RelativeSource = new(RelativeSourceMode.FindAncestor, typeof(SearchGroup), 1);

    static SearchGroup()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(SearchGroup), new FrameworkPropertyMetadata(typeof(SearchGroup)));
        InputForProperty = DependencyProperty.Register(nameof(InputForProperty), typeof(string), typeof(SearchGroup), new FrameworkPropertyMetadata(null));
        OutputForProperty = DependencyProperty.Register(nameof(OutputForProperty), typeof(string), typeof(SearchGroup), new PropertyMetadata(null));
        InputHeaderProperty = DependencyProperty.Register(nameof(InputHeader), typeof(string), typeof(SearchGroup), new PropertyMetadata(null));
        InputTextProperty = DependencyProperty.Register(nameof(InputText), typeof(string), typeof(SearchGroup), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        InputMaxLengthProperty = DependencyProperty.Register(nameof(InputMaxLength), typeof(int?), typeof(SearchGroup), new PropertyMetadata(null));
        IsIntegerOnlyProperty = DependencyProperty.Register(nameof(IsIntegerOnlyProperty), typeof(bool), typeof(SearchGroup), new PropertyMetadata(false));
        OutputHeaderProperty = DependencyProperty.Register(nameof(OutputHeader), typeof(string), typeof(SearchGroup), new PropertyMetadata(null));
        OutputTextProperty = DependencyProperty.Register(nameof(OutputText), typeof(string), typeof(SearchGroup), new PropertyMetadata(null));
    }

    public string? InputFor { get => (string)GetValue(InputForProperty); set => SetValue(InputForProperty, value); }

    public string? OutputFor { get => (string)GetValue(OutputForProperty); set => SetValue(OutputForProperty, value); }

    public string? InputHeader { get => (string)GetValue(InputHeaderProperty); set => SetValue(InputHeaderProperty, value); }

    public string? InputText { get => (string)GetValue(InputTextProperty); set => SetValue(InputTextProperty, value); }

    public int? InputMaxLength { get => (int?)GetValue(InputMaxLengthProperty); set => SetValue(InputMaxLengthProperty, value); }

    public bool IsIntegerOnly { get => (bool)GetValue(IsIntegerOnlyProperty); set => SetValue(IsIntegerOnlyProperty, value); }

    public string? OutputHeader { get => (string)GetValue(OutputHeaderProperty); set => SetValue(OutputHeaderProperty, value); }

    public string? OutputText { get => (string)GetValue(OutputTextProperty); set => SetValue(OutputTextProperty, value); }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        IsTabStop = false;

        var searchableForm = (ISearchableForm)DataContext;
        var inputField = (Input)GetTemplateChild(ChildInputFieldName);
        var outputField = (Input)GetTemplateChild(ChildOutputFieldName);
        SetPropertiesToChildren(searchableForm, inputField, outputField);

        inputField.SetBinding(Input.TextProperty, new Binding(nameof(InputText)) { RelativeSource = RelativeSource });
        outputField.SetBinding(Input.TextProperty, new Binding(nameof(OutputText)) { RelativeSource = RelativeSource });

        var searchBtn = (Button)GetTemplateChild(ChildSearchBtnName);
        searchBtn.Command = searchableForm.SearchCommand;
    }

    /// <summary>
    /// Bindingされていない子要素のプロパティ値を設定します｡
    /// </summary>
    /// <param name="inputField">子要素の入力フォームにあたる <see cref="Input"/></param>
    /// <param name="outputField">子要素の出力フォームにあたる <see cref="Input"/></param>
    private void SetPropertiesToChildren(ISearchableForm searchableForm, Input inputField, Input outputField)
    {
        inputField.Header = InputHeader;
        inputField.MaxLength = InputMaxLength;
        inputField.For = InputFor ?? searchableForm.DefaultInputProperyName;

        outputField.Header = OutputHeader;
        outputField.For = OutputFor ?? searchableForm.DefaultOutputProperyName;
    }
}