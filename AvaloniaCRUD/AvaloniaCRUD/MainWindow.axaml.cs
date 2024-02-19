using Avalonia.Controls;
using AvaloniaCRUD.Pages;

namespace AvaloniaCRUD;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        App.MainWindow = this;
        App.MainWindow.MainContentControl.Content = new AllUsercUC();
    }
}