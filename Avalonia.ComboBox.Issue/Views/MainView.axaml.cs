using Avalonia;
using Avalonia.Controls;
using Avalonia.ComboBox.Issue.ViewModels;
using ReactiveUI;

namespace Avalonia.ComboBox.Issue.Views;

public partial class MainView : UserControl, IViewFor<MainViewModel>
{
    public MainView()
    {
        InitializeComponent();
    }

    public MainViewModel? ViewModel
    {
        get => (MainViewModel?)GetValue(ViewModelProperty);
        set => SetValue(ViewModelProperty, value);
    }

    public static readonly StyledProperty<MainViewModel?> ViewModelProperty = AvaloniaProperty.Register<MainView, MainViewModel?>(nameof(ViewModel));

    object? IViewFor.ViewModel
    {
        get => ViewModel;
        set => ViewModel = (MainViewModel?)value;
    }
}
