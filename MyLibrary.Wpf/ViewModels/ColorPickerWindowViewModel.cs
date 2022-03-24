using Microsoft.Toolkit.Mvvm.Input;
using System.Windows.Input;

namespace MyLibrary.Wpf.ViewModels;

public class ColorPickerWindowViewModel : ViewModelBase
{
    public enum ColorPickerWindowResult
    {
        Ok = 1,
        Cancel = 2,
    }

    public Color SelectedColor { get => _selectedColor; set => SetProperty(ref _selectedColor, value); }
    private Color _selectedColor;

    public ICommand OkCommand { get;}

    public ICommand CancelCommand { get; }

    public ColorPickerWindowResult Result { get; private set; } = ColorPickerWindowResult.Cancel;

    public ColorPickerWindowViewModel()
    {
        OkCommand = new RelayCommand<Window>(Ok);
        CancelCommand = new RelayCommand<Window>(Cancel);
    }

    private void Ok(Window? window)
    {
        Result = ColorPickerWindowResult.Ok;
        window?.Close();
    }

    private void Cancel(Window? window)
    {
        Result = ColorPickerWindowResult.Cancel;
        window?.Close();
    }
}
