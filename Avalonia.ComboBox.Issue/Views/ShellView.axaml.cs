using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.ComboBox.Issue.Utils;
using Avalonia.ComboBox.Issue.ViewModels;
using ReactiveUI;

namespace Avalonia.ComboBox.Issue.Views;

public partial class ShellView : UserControl, IViewFor<ShellViewModel>
{
    public ShellView()
    {
        InitializeComponent();
    }

    private void CloseButton_Click(object? sender, RoutedEventArgs e)
    {
        (TopLevel.GetTopLevel(this) as Window)?.Close();
    }

    public ShellViewModel? ViewModel
    {
        get => (ShellViewModel?)GetValue(ViewModelProperty);
        set => SetValue(ViewModelProperty, value);
    }

    public static readonly StyledProperty<ShellViewModel?> ViewModelProperty = AvaloniaProperty.Register<ShellView, ShellViewModel?>(nameof(ViewModel));

    object? IViewFor.ViewModel
    {
        get => ViewModel;
        set => ViewModel = (ShellViewModel?)value;
    }
}