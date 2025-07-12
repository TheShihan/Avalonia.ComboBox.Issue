using ReactiveUI;

namespace Avalonia.ComboBox.Issue.Utils;

/// <summary>
/// Dummy IScreen for design-time
/// </summary>
internal class StubScreen : IScreen
{
    public RoutingState Router { get; } = new RoutingState();
}