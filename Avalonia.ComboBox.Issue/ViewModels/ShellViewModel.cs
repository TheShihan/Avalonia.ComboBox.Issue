using Microsoft.Extensions.DependencyInjection;
using Avalonia.ComboBox.Issue.Utils;
using ReactiveUI;
using System;
using System.Reactive;

namespace Avalonia.ComboBox.Issue.ViewModels;

public class ShellViewModel : ReactiveObject, IScreen
{
    public RoutingState Router { get; } = new();

    public ReactiveCommand<Unit, IRoutableViewModel> GoBack { get; }

    public bool CanGoBack => Router.NavigationStack.Count > 1;

    public ShellViewModel() : this(new StubServiceProvider())
    {
        // For AXAML preview
    }

    public ShellViewModel(IServiceProvider sp, bool navigateImmediately = true)
    {
        ClosingButtonEnabled = true;
        GoBack = ReactiveCommand.CreateFromObservable(() => Router.NavigateBack.Execute());
        Router.NavigationStack.CollectionChanged += (_, __) => this.RaisePropertyChanged(nameof(CanGoBack));
    }

    public void NavigateToMainView(IServiceProvider sp) => Router.Navigate.Execute(sp.GetRequiredService<MainViewModel>()).Subscribe();

    public bool ShowCloseButton => App.IsDesktopApp;

    public bool ClosingButtonEnabled { get; set; }
}
