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
        App.MainWindow.MainContentPresenter.Content = new MainUC();
    }

    private void BAddUser_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        App.MainWindow.MainContentPresenter.Content = new EmployeeFinderUC(Chatroom);
    }

    private void BChangeTopic_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        App.MainWindow.MainContentPresenter.Content = new EmployeeFinderUC(new Chatroom());
    }

    private void BLeave_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        using(DBConnection db = new DBConnection())
        {
            var employeeChatroom = db.EmployeeChatroom.FirstOrDefault(x => Chatroom.Id == Chatroom.Id && x.EmployeeId == App.loginEmploee.Id);
            db.EmployeeChatroom.Remove(employeeChatroom);
            db.SaveChanges();
            App.MainWindow.MainContentPresenter.Content = new MainUC();
        }
        
    }

    private void BSend_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        using (DBConnection db = new DBConnection())
        {
            var chatMessage = new ChatMessage() { SenderId = App.loginEmploee.Id, ChatroomId = Chatroom.Id, Date = DateTime.UtcNow, Message = TBMessage.Text };
            db.ChatMessage.Add(chatMessage);
            db.SaveChanges();
        }
        Refresh();
        TBMessage.Text = String.Empty;
    }
}