using System;
using System.Collections.Generic;

namespace ChitChat.Models;

public partial class Chatroom
{
    public int Id { get; set; }

    public string Topic { get; set; } = null!;

    public virtual ICollection<ChatMessage> ChatMessages { get; set; } = new List<ChatMessage>();

    public virtual ICollection<EmployeeChatroom> EmployeeChatrooms { get; set; } = new List<EmployeeChatroom>();
}
