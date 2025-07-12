using Avalonia.ComboBox.Issue.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;

namespace Avalonia.ComboBox.Issue.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAppCoreServices(this IServiceCollection services)
    {
        services.AddSingleton<ShellViewModel>();
        services.AddSingleton<MainWindowViewModel>();
        services.AddSingleton<IScreen>(sp => sp.GetRequiredService<ShellViewModel>());

        services.AddSingleton<MainViewModel>();

        return services;
    }
}
