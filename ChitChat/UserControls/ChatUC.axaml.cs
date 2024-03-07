using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;
using ChitChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChitChat;

public partial class ChatUC : UserControl
{
    public List<Employee> Employees { get; set; }
    public List<ChatMessage> ChatMessages { get; set; }
    public Chatroom Chatroom { get; set; }
    public ChatUC(Chatroom chatroom)
    {
        InitializeComponent();
        Chatroom = chatroom;
        DataContext = this;
        Refresh();
    }

    private void Refresh()
    {
        using(DBConnection db = new DBConnection())
        {
            ICEmployees.ItemsSource = db.EmployeeChatroom.Where(x => x.ChatroomId == Chatroom.Id).Select(x => x.Employee).ToList();
            ICChatMessages.ItemsSource = db.ChatMessage.Where(x => x.ChatroomId == Chatroom.Id).ToList();
        }
    }

    private void BCLose_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
    }

    private void BAddUser_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
    }

    private void BChangeTopic_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
    }

    private void BLeave_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
    }

    private void BSend_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        //using (DBConnection db = new DBConnection())
        //{
        //    var chatMessage = new ChatMessage() { SenderId = App.loginEmploee.Id, ChatroomId = Chatroom.Id, Date = DateTime.Now.Date, Message = TBMessage.Text };
        //}
        //Refresh();
        //TBMessage.Text = String.Empty;
    }
}