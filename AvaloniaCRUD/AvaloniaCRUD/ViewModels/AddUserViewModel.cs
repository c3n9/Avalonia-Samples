using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using Avalonia.Controls;
using AvaloniaCRUD.Models;
using AvaloniaCRUD.Views;
using ReactiveUI;

namespace AvaloniaCRUD.ViewModels;

public class AddUserViewModel : ViewModelBase
{
    private string _name;
    private Role _role;

    public string Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }

    public List<Role> Roles { get; }

    public Role Role
    {
        get => _role;
        set => this.RaiseAndSetIfChanged(ref _role, value);
    }

    public ReactiveCommand<Unit, Unit> SaveCommand { get; }
    public ReactiveCommand<Unit, Unit> BackCommand { get; }
    public AddUserViewModel(List<Role> roles, User user)
    {
        Roles = roles;
        Name = user.Name;
        Role = user.Role;
        SaveCommand = ReactiveCommand.Create(() =>
        {
            using (var db = new DBConnection())
            {
                var newUser = new User
                {
                    Name = Name,
                    RoleId = Role.Id,
                };
                db.User.Add(newUser);
                db.SaveChanges();
                
            }
        });
        BackCommand = ReactiveCommand.Create(() =>
        {
            
        });
    }
}