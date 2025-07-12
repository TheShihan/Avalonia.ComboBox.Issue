using System;

namespace Avalonia.ComboBox.Issue.Utils;

public class StubServiceProvider : IServiceProvider
{
    public object? GetService(Type serviceType) => null;
}