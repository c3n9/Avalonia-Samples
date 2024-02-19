using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using AvaloniaCRUD.Models;

namespace AvaloniaCRUD.Pages;

public partial class AllUsercUC : UserControl
{
    public List<User> Users { get; set; }
    public AllUsercUC()
    {
        InitializeComponent();
        using (var dbContext = new DBConnection())
        {
            Users = dbContext.User.ToList();
        }
        DataContext = this;
    }

    private void BAdd_OnClick(object? sender, RoutedEventArgs e)
    {
        App.MainWindow.MainContentControl.Content = new AddUserUC(new User());
    }

    private void BEdit_OnClick(object? sender, RoutedEventArgs e)
    {
        if (DGUsers.SelectedItem is User user)
        {
            App.MainWindow.MainContentControl.Content = new AddUserUC(user);
        }
    }

    private void BRemove_OnClick(object? sender, RoutedEventArgs e)
    {
        if (DGUsers.SelectedItem is User user)
        {
            using (var db = new DBConnection())
            {
                db.Remove(user);
                db.SaveChanges();
                App.MainWindow.MainContentControl.Content = new AllUsercUC();

            }
        }
        
    }
}