using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Controls;
using AvaloniaCRUD.Models;
using AvaloniaCRUD.ViewModels;

namespace AvaloniaCRUD;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }
}