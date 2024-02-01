using System.Reactive;
using AvaloniaCRUD.Views;
using ReactiveUI;

namespace AvaloniaCRUD.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
#pragma warning disable CA1822 // Mark members as static
    public RoleViewModel RoleVM { get; } = new RoleViewModel();
    public UserViewModel UserVM { get; } = new UserViewModel();
    
#pragma warning restore CA1822 // Mark members as static
}