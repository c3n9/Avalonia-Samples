namespace AvaloniaCRUD.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public RoleViewModel RoleVM { get; } = new RoleViewModel();
    public UserViewModel UserVM { get; } = new UserViewModel();
}