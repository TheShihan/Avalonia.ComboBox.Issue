using System;
using System.Collections.Concurrent;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using ReactiveUI;

namespace Avalonia.ComboBox.Issue.Utils;

/// <summary>
/// One class – both an IDataTemplate (for design-time preview)
/// *and* an IViewLocator (for RoutedViewHost at run-time).
/// </summary>
public sealed class ViewLocator : IDataTemplate, IViewLocator
{
    private static readonly ConcurrentDictionary<Type, Type?> Cache = new();

    /* ---------- IViewLocator ---------- */
    public IViewFor? ResolveView<T>(T? viewModel, string? contract = null)
    {
        var vmType = viewModel?.GetType();
        if (vmType is null) return null;

        var viewType = Cache.GetOrAdd(vmType, LocateViewType);

        return viewType is not null
            ? Activator.CreateInstance(viewType) as IViewFor
            : null;
    }

    /* ---------- IDataTemplate (designer) ---------- */
    public Control Build(object? data) =>
        ResolveView(data!, null) as Control
        ?? new TextBlock { Text = $"View not found for {data?.GetType().Name}" };

    public bool Match(object? data) => data is IRoutableViewModel;

    /* ---------- helper ---------- */
    private static Type? LocateViewType(Type vmType) =>
        Type.GetType(vmType.FullName!.Replace("ViewModel", "View"));
}