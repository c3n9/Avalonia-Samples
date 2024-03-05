using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ChitChat.AppWindows;
using ChitChat.Models;

namespace ChitChat;

public partial class ChangeTopicUC : UserControl
{
    Employee contextEmployee;
    Chatroom contextChatroom;
    public ChangeTopicUC(Employee employee, Chatroom chatroom)
    {
        InitializeComponent();
        contextEmployee = employee;
        contextChatroom = chatroom;
    }

    private void ButtonOk_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TBChatroomName.Text))
        {
            MessageWindow messageWindow = new MessageWindow("Enter name chatroom!");
            messageWindow.ShowDialog(App.MainWindow);
            return;
        }
        contextChatroom.Topic = TBChatroomName.Text;
        using (DBConnection db = new DBConnection())
        {
            db.Chatroom.Add(contextChatroom);
            db.SaveChanges();
            db.EmployeeChatroom.Add(new EmployeeChatroom() { ChatroomId = contextChatroom.Id, EmployeeId = contextEmployee.Id });
            db.EmployeeChatroom.Add(new EmployeeChatroom() { ChatroomId = contextChatroom.Id, EmployeeId = App.loginEmploee.Id });
            db.SaveChanges();
        }
        App.MainWindow.MainContentPresenter.Content = new MainUC();
    }

    private void ButtonCancel_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        App.MainWindow.MainContentPresenter.Content = new MainUC();
    }
}