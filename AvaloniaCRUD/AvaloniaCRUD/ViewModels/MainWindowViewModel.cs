using System;
using System.Reactive;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using AvaloniaCRUD.Views;
using ReactiveUI;

namespace AvaloniaCRUD.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
#pragma warning disable CA1822 // Mark members as static
    public RoleViewModel RoleVM { get; } = new RoleViewModel();
    public UserViewModel UserVM { get; } = new UserViewModel();
    
    public ReactiveCommand<Unit,Unit> SubmitCommand { get; }

    public MainWindowViewModel()
    {
        SubmitCommand = ReactiveCommand.Create(() =>
        {
            ShowMessageBox("Нажата кнопка удалить!");
        });
    }

    private void ShowMessageBox(string message)
    {
        var messageBoxWindow = new Window
        {
            Title = "Message",
            Width = 300,
            Height = 300,
            WindowStartupLocation = WindowStartupLocation.CenterScreen,
            Content = new TextBlock()
            {
                Text = message,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            }
        };
        messageBoxWindow.Show();
    }
#pragma warning restore CA1822 // Mark members as static
}