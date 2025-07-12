using System;
using Avalonia.ReactiveUI;
using Microsoft.Extensions.DependencyInjection;
using Avalonia.ComboBox.Issue.Infrastructure;

namespace Avalonia.ComboBox.Issue.Windows;

// Windows App Entrypoint
class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
    }

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
    {
        var services = new ServiceCollection()
            .AddAppCoreServices();

        App.Services = services.BuildServiceProvider();

        return AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace()
            .UseReactiveUI();
    }
}
