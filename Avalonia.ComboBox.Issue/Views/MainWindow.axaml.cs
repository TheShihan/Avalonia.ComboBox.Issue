using Avalonia.ComboBox.Issue.Utils;
using Avalonia.Controls;
using System;

namespace Avalonia.ComboBox.Issue.Views;

public partial class MainWindow : Window
{
    private readonly IServiceProvider _sp;

    public MainWindow() : this(new StubServiceProvider())
    {
        // Only for XAML Preview
    }

    public MainWindow(IServiceProvider sp)
    {
        _sp = sp;

        InitializeComponent();
        
        //this.AttachDevTools();
    }

    private void Border_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e)
    {
        BeginMoveDrag(e);
    }

    private void CloseButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Close();
    }
}
