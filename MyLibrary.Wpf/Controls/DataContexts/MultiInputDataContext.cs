using MyLibrary.Util;
using System.Collections.ObjectModel;

namespace MyLibrary.Wpf.Controls.DataContexts;

public class MultiInputDataContext : ObservableCollection<IMultiInputItemDataContext>
{
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="generator">要素を生成するメソッド</param>
    /// <param name="count">生成する数</param>
    public MultiInputDataContext(Func<IMultiInputItemDataContext> generator, int count = 1)
    {
        if (count is 1)
        {
            Add(generator());
            return;
        }

        var items = EnumerableUtil.Repeat(generator, count).ToArray();
        foreach (var item in items)
        {
            item.RemoveBtnIsEnabled = true;
            Add(item);
        }
    }

    //public List<object>? SelectedItems { get; private set; }

    public void AddNewItem()
    {
        var item = (IMultiInputItemDataContext)Activator.CreateInstance(this.First().GetType())!;
        Add(item);
        foreach (var item1 in this)
        {
            item1.RemoveBtnIsEnabled = true;
        }
    }

    public void RemoveItemAt(int? index)
    {
        if (index is null)
        {
            throw new ArgumentNullException(nameof(index));
        }

        if (Count > 1)
        {
            RemoveAt(index.Value);
        }

        if (Count is 1)
        {
            this.First().RemoveBtnIsEnabled = false;
        }
    }

    //public void UpdateSelectedItems()
    //{
    //    var q = Items.Where(x => x.IsSelected.HasValue && (x.IsSelected.Value == true));
    //    SelectedItems = new List<UserForm>(q);
    //    OnPropertyChanged(new PropertyChangedEventArgs(nameof(SelectedItems)));
    //}
}