using System;
using System.Collections.ObjectModel;
using System.Linq;
using AvaloniaCRUD.Models;
using ReactiveUI;

namespace AvaloniaCRUD.ViewModels;

public partial class RoleViewModel : ReactiveObject
{
    private Role _role;
    public Role Role
    {
        get => _role;
        set => this.RaiseAndSetIfChanged(ref _role, value);
    }
    private ObservableCollection<Role> _roles;
    public ObservableCollection<Role> Roles
    {
        get => _roles;
        set => this.RaiseAndSetIfChanged(ref _roles, value);
    }

    public RoleViewModel()
    {
        _roles = new ObservableCollection<Role>();
        LoadRoles();
    }
    private void LoadRoles()
    {
        try
        {
            using (var context = new GlobalSettings())
            {
                Roles.Clear();
                var roles = context.Role.ToList();
                foreach (var role in roles)
                {
                    Roles.Add(role);
                }
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}