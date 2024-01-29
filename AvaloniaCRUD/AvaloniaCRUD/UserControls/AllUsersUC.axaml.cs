using System.Collections.ObjectModel;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using AvaloniaCRUD.Models;

namespace AvaloniaCRUD.UserControls;

public partial class AllUsersUC : UserControl
{
    private string connectionString = "Host=localhost;Username=1;Password=1;Database=CRUD";
    public ObservableCollection<Role> Roles { get; set; }
    public AllUsersUC()
    {
        InitializeComponent();
        using (var dbContext = new GlobalSettings())
        {
            Roles = new ObservableCollection<Role>(dbContext.Role.ToList());
            // var users = dbContext.User;
        }
        DataContext = this;
    }

    private void BAdd_OnClick(object? sender, RoutedEventArgs e)
    {
        
    }

    private void BEdit_OnClick(object? sender, RoutedEventArgs e)
    {
        
    }

    private void BRemove_OnClick(object? sender, RoutedEventArgs e)
    {
        
    }
}