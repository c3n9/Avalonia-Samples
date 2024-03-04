using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ChitChat.AppWindows;
using ChitChat.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;

namespace ChitChat.UserControls;

public partial class RegistrationUC : UserControl
{
    public Employee Employee { get; set; }
    public List<Department> Departments { get; set; }
    public RegistrationUC(Employee employee)
    {
        InitializeComponent();
        Employee = employee;
        using (DBConnection db = new DBConnection())
        {
            Departments = db.Department.ToList();
            DataContext = this;
        }

    }

    private void BRegister_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var error = string.Empty;
        var validationContext = new ValidationContext(Employee);
        var results = new List<ValidationResult>();
        if (!Validator.TryValidateObject(Employee, validationContext, results, true))
        {
            foreach (var result in results)
            {
                error += "->" + $"{result.ErrorMessage}\n";
            }
        }
        if (!string.IsNullOrWhiteSpace(error))
        {
            MessageWindow messageWindow = new MessageWindow(error);
            messageWindow.ShowDialog(App.MainWindow);
            return;
        }
        using (DBConnection db = new DBConnection())
        {
            Employee.Password = GetHash(Employee.Password);
            db.Entry(Employee.Department).State = EntityState.Unchanged;
            db.Employee.Add(Employee);
            db.SaveChanges();
        }
        App.MainWindow.MainContentPresenter.Content = new LoginUC();
    }
    private string GetHash(string input)
    {
        var md5 = MD5.Create();
        var hash = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));
        var text = Convert.ToBase64String(hash);
        return Convert.ToBase64String(hash);
    }
    private void BCancel_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        App.MainWindow.MainContentPresenter.Content = new LoginUC();
    }
}