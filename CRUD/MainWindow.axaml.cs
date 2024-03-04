using Avalonia.Controls;

namespace CRUD
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            App.MainWindow = this;
            App.MainWindow.MainContentControl.Content = new AllUsersUC();
        }
    }
}