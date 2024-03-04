using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using CRUD.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CRUD;

public partial class AllUsersUC : UserControl
{
    public List<User> Users { get; set; }
    public AllUsersUC()
    {
        InitializeComponent();
        using (DBConnection db = new DBConnection())
        {
            Users = db.User.Include(x => x.Role).ToList();
            DataContext = this;
        }
    }

    private void BAdd_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        App.MainWindow.MainContentControl.Content = new AddUserUC(new User());
    }

    private void BEdit_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if(DGUsers.SelectedItem is User user)
        {
            App.MainWindow.MainContentControl.Content = new AddUserUC(user);
        }
    }

    private void BRemove_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (DGUsers.SelectedItem is User user)
        {
            using(DBConnection db = new DBConnection())
            {
                db.User.Remove(user);
                db.SaveChanges();
                App.MainWindow.MainContentControl.Content = new AllUsersUC();
            }
        }
    }
}