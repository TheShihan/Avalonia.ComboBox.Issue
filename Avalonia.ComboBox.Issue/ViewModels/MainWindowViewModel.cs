using ReactiveUI;
using System;

namespace Avalonia.ComboBox.Issue.ViewModels;

public class MainWindowViewModel : ReactiveObject
{
    public ShellViewModel ShellVM { get; }

    public MainWindowViewModel() : this(new ShellViewModel())
    {
        // Only for AXAML Preview / Design Time
    }

    public MainWindowViewModel(ShellViewModel shellViewModel)
    {
        ShellVM = shellViewModel;
    }
}