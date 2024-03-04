using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using CRUD.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CRUD;

public partial class AddUserUC : UserControl
{
    public User User { get; set; }
    public List<Role> Roles { get; set; }
    public AddUserUC(User user)
    {
        InitializeComponent();
        using (DBConnection db = new DBConnection())
        {
            Roles = db.Role.ToList();
            User = user;
            User.Role = Roles.FirstOrDefault(x => x.Id == User.RoleId);
            DataContext = this;
        }
    }

    private void BSave_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var error = string.Empty;
        var validationContext = new ValidationContext(User);
        var results = new List<ValidationResult>();
        if (!Validator.TryValidateObject(User, validationContext, results, true))
        {
            foreach (var result in results)
            {
                error += result + "\n";
            }
        }
        if (!string.IsNullOrWhiteSpace(error))
        {
            MessageWindow msgWindow = new MessageWindow(error);
            msgWindow.ShowDialog(App.MainWindow);
            return;
        }
        using (DBConnection db = new DBConnection())
        {
            db.Entry(User.Role).State = EntityState.Unchanged;
            if (User.Id == 0)
                db.User.Add(User);
            else
                db.Entry(User).State = EntityState.Modified;
            db.SaveChanges();
            App.MainWindow.MainContentControl.Content = new AllUsersUC();
        }
    }

    private void BCancel_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        App.MainWindow.MainContentControl.Content = new AllUsersUC();
    }
}