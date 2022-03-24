using Microsoft.Toolkit.Mvvm.Input;

namespace MyLibrary.Wpf.Controls.DataContexts;

public interface ISearchableForm
{
    public string DefaultInputProperyName { get; }

    public string DefaultOutputProperyName { get; }

    public IRelayCommand SearchCommand { get; }
}
