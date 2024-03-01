using Avalonia.Controls;
using ChitChat.UserControls;

namespace ChitChat
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            App.MainWindow = this;
            MainContentPresenter.Content = new LoginUC();
        }
    }
}