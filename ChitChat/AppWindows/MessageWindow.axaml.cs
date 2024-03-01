using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ChitChat.AppWindows;

public partial class MessageWindow : Window
{
    public MessageWindow(string message)
    {
        InitializeComponent();
        TBMessage.Text = message;
    }
}