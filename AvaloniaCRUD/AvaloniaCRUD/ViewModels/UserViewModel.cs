using AvaloniaCRUD.Models;
using ReactiveUI;

namespace AvaloniaCRUD.ViewModels;

public class UserViewModel : ReactiveObject
{
    private User _user;

    public User User
    {
        get => _user;
        set => this.RaiseAndSetIfChanged(ref _user, value);
    }
}