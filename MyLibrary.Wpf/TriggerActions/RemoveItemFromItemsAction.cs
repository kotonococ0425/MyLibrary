using Microsoft.Xaml.Behaviors;
using MyLibrary.Wpf.TriggerBases;
using System.Collections;
using System.ComponentModel;
using System.Windows.Controls.Primitives;

namespace MyLibrary.Wpf.TriggerActions;

/// <summary>
/// <see cref="DataGrid"/> �� <see cref="ListBox"/> ���ŌĂ΂ꂽ�玩�g�̍s���폜����A�N�V����
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

        //�w�肳�ꂽ�I�u�W�F�N�g��VisualTree��̐e�����ԂɒT�����AItemsControl��T���B
        //�������ADataGrid�͒��Ԃɂ���DataGridCellsPresenter�͖�������
        while (source is (not null and not ItemsControl) or DataGridCellsPresenter)
        {
            source = VisualTreeHelper.GetParent(source);
            parentTree.Add(source);
        }

        if (source is not ItemsControl itemsControl)
        {
            return;
        }

        //ItemsControl�̍s�ɂ�����I�u�W�F�N�g��T�������̌�납�猟��
        var item = parentTree.LastOrDefault(x => itemsControl.IsItemItsOwnContainer(x));

        var removeIndex = itemsControl.ItemContainerGenerator?.IndexFromContainer(item);

        if (removeIndex is null or < 0)
        {
            return;
        }

        var index = removeIndex.Value;

        //Binding���Ă����ꍇ��ItemsSource�A�Ⴄ�Ȃ�Items����폜����
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
