using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using AvaloniaCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace AvaloniaCRUD.Pages;

public partial class AddUserUC : UserControl
{
    public User User { get; set; }
    public List<Role> Roles { get; set; }

    public AddUserUC(User user)
    {
        InitializeComponent();
        using (var dbContext = new DBConnection())
        {
            Roles = dbContext.Role.ToList();
        }

        User = user;
        DataContext = this;
    }

    private void BSave_OnClick(object? sender, RoutedEventArgs e)
    {
        var error = string.Empty;
        var validationContext = new ValidationContext(User);
        var results = new List<ValidationResult>();
        if (!Validator.TryValidateObject(User, validationContext, results, true))
        {
            foreach (var result in results)
            {
                error += $"{result}";
            }
        }

        if (!string.IsNullOrWhiteSpace(error))
        {
            return;
        }

        using (DBConnection db = new DBConnection())
        {
            
            if (User.Id == 0)
                db.User.Add(User);
            else
            {
                var existingUser = db.User.FirstOrDefault(u => u.Id == User.Id);
                if (existingUser != null)
                {
                    existingUser.Name = User.Name;
                    existingUser.RoleId = User.RoleId;

                    db.Entry(existingUser).State = EntityState.Modified;
                }
            }
            db.SaveChanges();
        }

        App.MainWindow.MainContentControl.Content = new AllUsercUC();
    }

    private void BBack_OnClick(object? sender, RoutedEventArgs e)
    {
        App.MainWindow.MainContentControl.Content = new AllUsercUC();
    }
}