using Microsoft.Xaml.Behaviors;
using MyLibrary.Wpf.TriggerBases;
using System.Collections;
using System.ComponentModel;
using System.Windows.Controls.Primitives;

namespace MyLibrary.Wpf.TriggerActions;

/// <summary>
/// <see cref="DataGrid"/> や <see cref="ListBox"/> 内で呼ばれたら自身の行を削除するアクション
/// </summary>
[TypeConstraint(typeof(Button))]
[DefaultTrigger(typeof(Button), typeof(ButtonBaseClickTrigger))]
public class RemoveItemFromItemsAction : TriggerAction<Button>
{
    protected override void Invoke(object parameter)
    {
        var routedEventArgs = (RoutedEventArgs)parameter;
        var source = (DependencyObject)routedEventArgs.Source;
        var parentTree = new List<DependencyObject> { source };

        //指定されたオブジェクトのVisualTree上の親を順番に探索し、ItemsControlを探す。
        //ただし、DataGridは中間にいるDataGridCellsPresenterは無視する
        while (source is (not null and not ItemsControl) or DataGridCellsPresenter)
        {
            source = VisualTreeHelper.GetParent(source);
            parentTree.Add(source);
        }

        if (source is not ItemsControl itemsControl)
        {
            return;
        }

        //ItemsControlの行にあたるオブジェクトを探索履歴の後ろから検索
        var item = parentTree.LastOrDefault(x => itemsControl.IsItemItsOwnContainer(x));

        var removeIndex = itemsControl.ItemContainerGenerator?.IndexFromContainer(item);

        if (removeIndex is null or < 0)
        {
            return;
        }

        var index = removeIndex.Value;

        //Bindingしていた場合はItemsSource、違うならItemsから削除する
        var targetList = itemsControl.ItemsSource ?? itemsControl.Items;

        switch (targetList)
        {
            case IList list:
                list.RemoveAt(index);
                return;
            case IEditableCollectionView editableCollectionView:
                editableCollectionView.RemoveAt(index);
                return;
            default:
                break;
        }
    }
}
