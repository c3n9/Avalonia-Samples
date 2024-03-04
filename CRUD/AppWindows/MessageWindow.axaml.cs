using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Tmds.DBus.Protocol;

namespace CRUD;

public partial class MessageWindow : Window
{
    public MessageWindow(string error)
    {
        InitializeComponent();
        TBMessage.Text = error;
    }
}