using System;
using System.Collections;
using System.Linq;
using System.Reactive;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using AvaloniaCRUD.Models;
using AvaloniaCRUD.Views;
using ReactiveUI;

namespace AvaloniaCRUD.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
#pragma warning disable CA1822 // Mark members as static
    public RoleViewModel RoleVM { get; } = new RoleViewModel();
    public UserViewModel UserVM { get; } = new UserViewModel();
    private UserControl _currentControl;

    public UserControl CurrentControl
    {
        get => _currentControl;
        set => this.RaiseAndSetIfChanged(ref _currentControl, value);
    }

    public ReactiveCommand<string, Unit> SubmitCommand { get; }

    private readonly Window _mainWindow;
    private readonly Stack _pageStack = new Stack();
    private User _selectedUser;

    public User SelectedUser
    {
        get => _selectedUser;
        set => this.RaiseAndSetIfChanged(ref _selectedUser, value);
    }
    public MainWindowViewModel(Window mainWindow)
    {
        CurrentControl = new AllUsersUC();
        _mainWindow = mainWindow;

        SubmitCommand = ReactiveCommand.Create<string>(buttonContent =>
        {
            if (buttonContent == "Add")
            {
                _pageStack.Push(CurrentControl);
                var addUserViewModel = new AddUserViewModel(RoleVM.Roles.ToList(), new User());
                CurrentControl = new AddUserUC() { DataContext = addUserViewModel };
            }
            else if (buttonContent == "Edit")
            {
                _pageStack.Push(CurrentControl);
                var addUserViewModel = new AddUserViewModel(RoleVM.Roles.ToList(), SelectedUser);
                CurrentControl = new AddUserUC() { DataContext = addUserViewModel };
            }
            else if (buttonContent == "Remove")
            {
                using (DBConnection db = new DBConnection())
                {
                    db.User.Remove(SelectedUser);
                    db.SaveChanges();
                }
            }
        });
    }
    
    private void ShowMessageBox(string message)
    {
        var messageBoxWindow = new Window
        {
            Title = "Message",
            MinWidth = 300,
            MinHeight = 300,
            WindowStartupLocation = WindowStartupLocation.CenterScreen,
            Content = new TextBlock()
            {
                Text = message,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            }
        };
        messageBoxWindow.ShowDialog(_mainWindow);
    }
#pragma warning restore CA1822 // Mark members as static
}