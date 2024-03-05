using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ChitChat.Models;
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
        using(DBConnection db = new DBConnection())
        {
            Employee = App.loginEmploee;
            Chatrooms = db.Chatroom.ToList().Where(c => c.EmployeeChatrooms.Select(emp => emp.Employee).Contains(App.loginEmploee)).ToList();
            DataContext = this;
        }
    }

    private void BEmployeeFinder_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        App.MainWindow.MainContentPresenter.Content = new EmployeeFinderUC();
    }

    private void BCloseApplication_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        App.MainWindow.Close();
    }
}