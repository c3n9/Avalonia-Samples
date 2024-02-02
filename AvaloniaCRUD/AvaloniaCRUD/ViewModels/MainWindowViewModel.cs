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
    
    public ReactiveCommand<string,Unit> SubmitCommand { get; }

    private readonly Window _mainWindow;

    public MainWindowViewModel(Window mainWindow)
    {
        _mainWindow = mainWindow;

        SubmitCommand = ReactiveCommand.Create<string>(buttonContent =>
        {
            ShowMessageBox($"Нажата кнопка {buttonContent}!");
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