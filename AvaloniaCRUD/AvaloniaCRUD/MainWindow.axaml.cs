using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Controls;
using AvaloniaCRUD.Models;
using AvaloniaCRUD.UserControls;

namespace AvaloniaCRUD;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        MainControl.Content = new AllUsersUC();
    }

}