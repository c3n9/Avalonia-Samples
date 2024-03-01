using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ChitChat.Models;

namespace ChitChat.UserControls;

public partial class LoginUC : UserControl
{
    public LoginUC()
    {
        InitializeComponent();
    }

    private void ButtonOk_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
    }

    private void ButtonCancel_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        App.MainWindow.Close();
    }

    private void ButtonRegistration_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        App.MainWindow.MainContentPresenter.Content = new RegistrationUC(new Employee());
    }
}