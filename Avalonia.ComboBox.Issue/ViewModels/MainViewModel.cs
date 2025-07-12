using Avalonia.ComboBox.Issue.Utils;
using ReactiveUI;
namespace Avalonia.ComboBox.Issue.ViewModels;

public class MainViewModel : ViewModelBase, IRoutableViewModel
{
    // Constructor
    public MainViewModel() : this(new StubScreen())
    {
        // Only for AXAML preview
    }

    public MainViewModel(IScreen screen)
    {
        HostScreen = screen;
    }

    // Properties
    public string UrlPathSegment => "main";

    public IScreen HostScreen { get; }
}
