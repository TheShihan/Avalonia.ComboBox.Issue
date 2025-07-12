using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.ComboBox.Issue.ViewModels;
using Avalonia.ComboBox.Issue.Views;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace Avalonia.ComboBox.Issue;

public partial class App : Application
{
    public static IServiceProvider Services { get; set; } = null!;

    public static bool IsDesktopApp { get; set; }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        base.OnFrameworkInitializationCompleted();

        var shellViewModel = Services.GetRequiredService<ShellViewModel>();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            IsDesktopApp = true;

            var mainWindowViewModel = Services.GetRequiredService<MainWindowViewModel>();
            desktop.MainWindow = new MainWindow(Services)
            {
                DataContext = mainWindowViewModel,
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new ShellView
            {
                DataContext = shellViewModel
            };
        }

        // Show Main View
        shellViewModel.NavigateToMainView(Services);
    }
}