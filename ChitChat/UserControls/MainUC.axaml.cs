using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ChitChat.Models;
using ChitChat.UserControls;
using System.Collections.Generic;
using System.Linq;

namespace ChitChat;

public partial class MainUC : UserControl
{
    public Employee Employee { get; set; }
    public List<Chatroom> Chatrooms { get; set; }
    public MainUC()
    {
        InitializeComponent();
        using (DBConnection db = new DBConnection())
        {
            Employee = App.loginEmploee;
            Chatrooms = db.EmployeeChatroom.Where(x => x.EmployeeId == App.loginEmploee.Id).Select(x => x.Chatroom).ToList();
            DataContext = this;
        }
    }

    private void BEmployeeFinder_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        App.MainWindow.MainContentPresenter.Content = new EmployeeFinderUC(new Chatroom());
    }

    private void BCloseApplication_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        App.MainWindow.Close();
    }

    private void DataGrid_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        if (DGChatrooms.SelectedItem is Chatroom chatroom)
        {
            App.MainWindow.MainContentPresenter.Content = new ChatUC(chatroom);
        }
    }

    private void BExit_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        App.loginEmploee = null;
        App.MainWindow.MainContentPresenter.Content = new LoginUC();
    }
}