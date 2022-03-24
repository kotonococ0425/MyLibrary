namespace MyLibrary.Wpf.Controls;

public class CustomDataGrid : DataGrid
{
    static CustomDataGrid()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomDataGrid), new FrameworkPropertyMetadata(typeof(CustomDataGrid)));
    }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
    }
}
